using System;
using System.Collections.Generic;
using System.Text;

namespace Euyuil.Weixin.Pay
{
    public class UnifiedOrderResponse
    {
        [WeixinPayProperty("prepay_id", 64, true)]
        public string PrepayId { get; set; }
    }
}
