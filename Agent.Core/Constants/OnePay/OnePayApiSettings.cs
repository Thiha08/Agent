﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Agent.Core.Constants.OnePay
{
    public class OnePayApiSettings : IOnePayApiSettings
    {
        public string BaseUrl { get; set; }

        public string DirectPaymentUrl { get; set; }

        public string TransactionInquiryUrl { get; set; }

        public string TransactionUrl { get; set; }

        public string TransactionStatusUrl { get; set; }

        public string MerchantUserId { get; set; }

        public string Token { get; set; }

        public string WalletUserID { get; set; }

        public string Channel { get; set; }

        public string Version { get; set; }

        public string AgentID { get; set; }

        public string AgentSecretKey { get; set; }
    }
}
