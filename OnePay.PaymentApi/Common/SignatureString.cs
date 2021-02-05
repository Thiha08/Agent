using OnePay.PaymentApi.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnePay.PaymentApi.Common
{
    public static class SignatureString
    {
        public static string GetSignatureString(this PaymentRequest value)
        {
            return value.Version +
                   value.Channel +
                   value.MerchantUserId +
                   value.InvoiceNo +
                   value.Amount +
                   value.Remark +
                   value.SequenceNo;
        }
    }
}
