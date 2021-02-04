using OnePay.TransactionApi.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnePay.TransactionApi
{
    public class TransactionService : ITransactionService
    {
        public Task<TransactionStatusResponse> CheckTransactionStatusAsync(TransactionStatusRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionInquiryResponse> GetTransactionInquiry(TransactionInquiryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponse> MakeTransactionAsync(TransactionRequest request)
        {
            throw new NotImplementedException();
        }

        
    }
}
