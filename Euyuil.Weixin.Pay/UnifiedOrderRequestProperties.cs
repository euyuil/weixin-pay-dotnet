using System;

namespace Euyuil.Weixin.Pay
{
    public class UnifiedOrderRequestProperties
    {
        [WeixinPayProperty("notify_url", true)]
        public Uri NotifyUrl { get; set; }

        [WeixinPayProperty("trade_type", true)]
        public string TradeType { get; set; }
    }
}
