using System;
using System.Collections.Generic;
using System.Text;

namespace Agent.Core.Constants.OnePay
{
    public class OnePayApiSettings : IOnePayApiSettings
    {
        public string Url { get; set; }

        public string MerchantUserId { get; set; }

        public string Token { get; set; }

        public string WalletUserID { get; set; }

        public string Channel { get; set; }

        public string Version { get; set; }
    }
}
