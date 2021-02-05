using OnePay.TransactionApi.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnePay.TransactionApi.Common
{
    public static class SignatureString
    {
        public static string GetSignatureString(this TransactionInquiryRequest value)
        {
            return value.AgentID +
                   value.SubAgentID +
                   value.InvoiceNo +
                   value.SequenceNo +
                   value.ReceiverNo +
                   value.Amount +
                   value.ExpiredSeconds +
                   value.RequestTimeStamp;
        }

        public static string GetSignatureString(this InquiryDetail value)
        {
            return value.AgentID +
                   value.SubAgentID +
                   value.AgentName +
                   value.OriginalAmount +
                   value.AgentCommission +
                   value.TotalAmount +
                   value.CustomerCharges +
                   value.InvoiceNo +
                   value.SequenceNo +
                   value.ReceiverNo;
        }

        public static string GetSignatureString(this TransactionRequest value)
        {
            return value.AgentID +
                   value.SubAgentID +
                   value.SequenceNo +
                   value.ReceiverNo +
                   value.Amount +
                   value.RequestTimeStamp;
        }

        public static string GetSignatureString(this TransactionStatusRequest value)
        {
            return value.AgentID +
                   value.SubAgentID +
                   value.SequenceNo;
        }
    }
}
