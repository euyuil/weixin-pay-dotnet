using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Euyuil.Weixin.Pay
{
    public class WeixinPayClient
    {
        private static readonly Func<HttpClient> DefaultHttpClientFactory = () => new HttpClient();

        private readonly Func<HttpClient> _httpClientFactory;

        public WeixinPayClient() : this(null, null, null, DefaultHttpClientFactory)
        {
        }

        public WeixinPayClient(string appId, string merchantId, Uri notifyUrl) : this(appId, merchantId, notifyUrl, DefaultHttpClientFactory)
        {
        }

        internal WeixinPayClient(string appId, string merchantId, Uri notifyUrl, Func<HttpClient> httpClientFactory)
        {
            RequestProperties.AppId = appId;
            RequestProperties.MerchantId = merchantId;
            UnifiedOrderRequestProperties.NotifyUrl = notifyUrl;
            UnifiedOrderRequestProperties.TradeType = "APP";
            _httpClientFactory = httpClientFactory;
        }

        public RequestProperties RequestProperties { get; } = new RequestProperties();

        public UnifiedOrderRequestProperties UnifiedOrderRequestProperties { get; } = new UnifiedOrderRequestProperties();

        /// <summary>
        /// 商户系统先调用该接口在微信支付服务后台生成预支付交易单，返回正确的预支付交易回话标识后再在App里面调起支付。
        /// </summary>
        /// <param name="orderId">商户系统内部的订单号，32个字符内、可包含字母，其他说明见商户订单号。</param>
        /// <param name="orderName">商品描述交易字段格式根据不同的应用场景按照以下格式：App——需传入应用市场上的App名字-实际商品名称，天天爱消除-游戏充值。</param>
        /// <param name="orderPrice">订单总金额，单位为分。</param>
        /// <param name="clientIp">用户端实际IP。</param>
        /// <returns>微信生成的预支付回话标识，用于后续接口调用中使用，该值有效期为2小时。</returns>
        public async Task<string> UnifiedOrderAsync(string orderId, string orderName, int orderPrice, string clientIp)
        {
            var request = new UnifiedOrderRequest
            {
                Body = orderName,
                OutTradeNo = orderId,
                TotalFee = orderPrice,
                SpbillCreateIp = clientIp
            };

            var response = await UnifiedOrderAsync(request).ConfigureAwait(false);
            return response.PrepayId;
        }

        /// <summary>
        /// 商户系统先调用该接口在微信支付服务后台生成预支付交易单，返回正确的预支付交易回话标识后再在App里面调起支付。
        /// </summary>
        /// <param name="orderId">商户系统内部的订单号，32个字符内、可包含字母，其他说明见商户订单号。</param>
        /// <param name="orderName">商品描述交易字段格式根据不同的应用场景按照以下格式：App——需传入应用市场上的App名字-实际商品名称，天天爱消除-游戏充值。</param>
        /// <param name="productId">32个字符以内的商品编号。</param>
        /// <param name="productName">商品名称。</param>
        /// <param name="productPrice">商品单价，单位为分。</param>
        /// <param name="productQuantity">商品数量。</param>
        /// <param name="clientIp">用户端实际IP。</param>
        /// <returns>微信生成的预支付回话标识，用于后续接口调用中使用，该值有效期为2小时。</returns>
        public async Task<string> UnifiedOrderAsync(string orderId, string orderName, string productId, string productName, int productPrice, int productQuantity, string clientIp)
        {
            var request = new UnifiedOrderRequest
            {
                Body = orderName,
                Detail = new List<GoodsDetail>
                {
                    new GoodsDetail
                    {
                        GoodsId = productId,
                        GoodsName = productName,
                        Quantity = productQuantity,
                        Price = productPrice
                    }
                },
                OutTradeNo = orderId,
                TotalFee = productPrice * productQuantity,
                SpbillCreateIp = clientIp
            };

            var response = await UnifiedOrderAsync(request).ConfigureAwait(false);
            return response.PrepayId;
        }

        public Task<UnifiedOrderResponse> UnifiedOrderAsync(UnifiedOrderRequest request)
        {
            return RequestAsync<UnifiedOrderResponse>("https://api.mch.weixin.qq.com/pay/unifiedorder", RequestProperties, UnifiedOrderRequestProperties, request);
        }

        public Task<ResultNotifyResponse> ResultNotifyAsync(ResultNotifyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<OrderQueryResponse> OrderQueryAsync(OrderQueryRequest request)
        {
            return RequestAsync<OrderQueryResponse>("https://api.mch.weixin.qq.com/pay/orderquery", RequestProperties, request);
        }

        public Task<CloseOrderResponse> CloseOrderAsync(CloseOrderRequest request)
        {
            return RequestAsync<CloseOrderResponse>("https://api.mch.weixin.qq.com/pay/closeorder", RequestProperties, request);
        }

        public Task<RefundResponse> RefundAsync(RefundRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RefundQueryResponse> RefundQueryAsync(RefundQueryRequest request)
        {
            return RequestAsync<RefundQueryResponse>("https://api.mch.weixin.qq.com/pay/refundquery", RequestProperties, request);
        }

        public Task<DownloadBillResponse> DownloadBillAsync(DownloadBillRequest request)
        {
            return RequestAsync<DownloadBillResponse>("https://api.mch.weixin.qq.com/pay/downloadbill", RequestProperties, request);
        }

        public Task<ReportResponse> ReportAsync(ReportRequest request)
        {
            return RequestAsync<ReportResponse>("https://api.mch.weixin.qq.com/payitil/report", RequestProperties, request);
        }

        private async Task<T> RequestAsync<T>(string url, params object[] requests) where T : new()
        {
            var requestMessage = new WeixinPayMessage();
            foreach (var request in requests)
            {
                requestMessage.ReadFromObject(request);
            }

            // TODO Validate requestMessage by the last request.
            var responseMessage = new WeixinPayMessage();
            using (var httpClient = _httpClientFactory.Invoke())
            using (var requestStream = new MemoryStream())
            {
                requestMessage.WriteToStream(requestStream);
                requestStream.Position = 0;
                var httpResponse = await httpClient.PostAsync(url, new StreamContent(requestStream)).ConfigureAwait(false);
                var responseStream = await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
                responseMessage.ReadFromStream(responseStream);
            }

            var response = new T();
            responseMessage.WriteToObject(response);

            // TODO Validate responseMessage by response.
            return response;
        }
    }
}
