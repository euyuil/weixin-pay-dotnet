namespace Euyuil.Weixin.Pay
{
    public class RequestProperties
    {
        [WeixinPayProperty("appid", true)]
        public string AppId { get; set; }

        [WeixinPayProperty("mch_id", true)]
        public string MerchantId { get; set; }
    }
}
