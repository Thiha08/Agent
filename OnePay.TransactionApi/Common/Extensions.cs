using Agent.Core.Extensions;
using OnePay.TransactionApi.Dtos;

namespace OnePay.TransactionApi.Common
{
    public static class Extensions
    {
        public static TransactionInquiryResponse GetSystemErrorResponse(this TransactionInquiryRequest value)
        {
            return new TransactionInquiryResponse
            {
                ResponseCode = TransactionResponseCode.SomethingWentWrong,
                ResponseDescription = TransactionResponseCode.SomethingWentWrong.ToDescription()
            };
        }

        public static TransactionResponse GetSystemErrorResponse(this TransactionRequest value)
        {
            return new TransactionResponse
            {
                ResponseCode = TransactionResponseCode.SomethingWentWrong,
                ResponseDescription = TransactionResponseCode.SomethingWentWrong.ToDescription(),
                SequenceNo = value.SequenceNo
            };
        }

        public static TransactionStatusResponse GetSystemErrorResponse(this TransactionStatusRequest value)
        {
            return new TransactionStatusResponse
            {
                ResponseCode = TransactionResponseCode.SomethingWentWrong,
                ResponseDescription = TransactionResponseCode.SomethingWentWrong.ToDescription(),
                SequenceNo = value.SequenceNo
            };
        }
    }
}
