using Agent.Core.Dtos;
using System.Threading.Tasks;

namespace Agent.Core.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResponse<InquiryDetailDto>> GetTransactionInquiryAsync();

        Task<ServiceResponse> MakeTransactionAsync();

        Task<ServiceResponse<TransactionStatusDto>> CheckTransactionStatusAsync();
    }
}
