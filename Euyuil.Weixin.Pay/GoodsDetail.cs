using Newtonsoft.Json;

namespace Euyuil.Weixin.Pay
{
    public class GoodsDetail
    {
        [JsonProperty("goods_id", Required = Required.Always)]
        public string GoodsId { get; set; }

        [JsonProperty("wxpay_goods_id")]
        public string WxpayGoodsId { get; set; }

        [JsonProperty("goods_name", Required = Required.Always)]
        public string GoodsName { get; set; }

        [JsonProperty("quantity", Required = Required.Always)]
        public int Quantity { get; set; }

        [JsonProperty("price", Required = Required.Always)]
        public int Price { get; set; }

        [JsonProperty("goods_category")]
        public string GoodsCategory { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
