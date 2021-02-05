using System;
using System.Collections.Generic;
using System.Text;

namespace Agent.Core.Constants.OnePay
{
    public interface IOnePayApiSettings
    {
        string BaseUrl { get; set; }

        string DirectPaymentUrl { get; set; }

        string TransactionInquiryUrl { get; set; }

        string TransactionUrl { get; set; }

        string TransactionStatusUrl { get; set; }

        string MerchantUserId { get; set; }

        string Token { get; set; }

        string WalletUserID { get; set; }

        string Channel { get; set; }

        string Version { get; set; }
    }
}
