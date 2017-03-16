using System;
using System.Collections.Generic;
using System.Text;

namespace Euyuil.Weixin.Pay
{
    [Message]
    public class UnifiedOrderRequest
    {
        [Property("appid", true)]
        public string ApplicationId { get; set; }

        [Property("mch_id", true)]
        public string MerchantId { get; set; }
    }
}
