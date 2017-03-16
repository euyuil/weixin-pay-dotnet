using System;
using System.Collections.Generic;

namespace Euyuil.Weixin.Pay
{
    public class UnifiedOrderRequest
    {
        [WeixinPayProperty("device_info")]
        public string DeviceInfo { get; set; }

        [WeixinPayProperty("body", true)]
        public string Body { get; set; }

        [WeixinPayProperty("detail", 8192)]
        public IReadOnlyList<GoodsDetail> Detail { get; set; }

        [WeixinPayProperty("attach")]
        public string Attach { get; set; }

        [WeixinPayProperty("out_trade_no", true)]
        public string OutTradeNo { get; set; }

        [WeixinPayProperty("fee_type")]
        public string FeeType { get; set; }

        [WeixinPayProperty("total_fee", true)]
        public int TotalFee { get; set; }

        [WeixinPayProperty("spbill_create_ip", true)]
        public string SpbillCreateIp { get; set; }

        [WeixinPayProperty("time_start", "yyyyMMddHHmmss")]
        public DateTime? TimeStart { get; set; }

        [WeixinPayProperty("time_expire", "yyyyMMddHHmmss")]
        public DateTime? TimeExpire { get; set; }

        [WeixinPayProperty("goods_tag", 32)]
        public string GoodsTag { get; set; }

        [WeixinPayProperty("notify_url", 256, true)]
        public Uri NotifyUrl { get; set; }

        [WeixinPayProperty("trade_type", 16, true)]
        public string TradeType { get; set; }

        [WeixinPayProperty("limit_pay", 32)]
        public string LimitPay { get; set; }
    }
}
