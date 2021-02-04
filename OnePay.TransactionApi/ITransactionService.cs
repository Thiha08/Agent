using OnePay.TransactionApi.Dtos;
using System.Threading.Tasks;

namespace OnePay.TransactionApi
{
    public interface ITransactionService
    {
        Task<TransactionInquiryResponse> GetTransactionInquiry(TransactionInquiryRequest request);

        Task<TransactionResponse> MakeTransactionAsync(TransactionRequest request);

        Task<TransactionStatusResponse> CheckTransactionStatusAsync(TransactionStatusRequest request);
    }
}
