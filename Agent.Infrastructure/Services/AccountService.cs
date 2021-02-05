using Agent.Core.Constants.OnePay;
using Agent.Core.Dtos;
using Agent.Core.Extensions;
using Agent.Core.Interfaces;
using AutoMapper;
using OnePay.TransactionApi;
using OnePay.TransactionApi.Common;
using OnePay.TransactionApi.Dtos;
using System;
using System.Threading.Tasks;

namespace Agent.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly ITransactionService _transactionService;
        private readonly IOnePayApiSettings _onePayApiSettings;
        private readonly IMapper _mapper;

        public AccountService(ITransactionService transactionService, IOnePayApiSettings onePayApiSettings, IMapper mapper)
        {
            _transactionService = transactionService;
            _onePayApiSettings = onePayApiSettings;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<InquiryDetailDto>> GetTransactionInquiryAsync()
        {
            var transactionInquiry = new TransactionInquiryRequest
            {
                AgentID = _onePayApiSettings.AgentID,
                SubAgentID = "1994992",
                InvoiceNo = "DEF",
                SequenceNo = "CEF11DB87838433EB9F33394AE98E3E919949914",
                ReceiverNo = "959960526124",
                Amount = "1000",
                ExpiredSeconds = 600
            };
            var response = await _transactionService.GetTransactionInquiryAsync(transactionInquiry);
            return new ServiceResponse<InquiryDetailDto>
            {
                Success = response.ResponseCode == TransactionResponseCode.Success,
                Message = response.ResponseDescription,
                Data = _mapper.Map<InquiryDetailDto>(response.InquiryDetail)
            };
        }

        public async Task<ServiceResponse> MakeTransactionAsync()
        {
            var transaction = new TransactionRequest
            {
                AgentID = _onePayApiSettings.AgentID,
                SubAgentID = "1994992",
                SequenceNo = "CEF11DB87838433EB9F33394AE98E3E919949914",
                ReceiverNo = "959960526124",
                Amount = "1000"
            };
            var response = await _transactionService.MakeTransactionAsync(transaction);
            return new ServiceResponse
            {
                Success = response.ResponseCode == TransactionResponseCode.Success,
                Message = response.ResponseDescription
            };
        }

        public async Task<ServiceResponse<TransactionStatusDto>> CheckTransactionStatusAsync()
        {
            var transactionStatus = new TransactionStatusRequest
            {
                AgentID = _onePayApiSettings.AgentID,
                SubAgentID = "1994992",
                SequenceNo = "CEF11DB87838433EB9F33394AE98E3E919949914"
            };
            var response = await _transactionService.CheckTransactionStatusAsync(transactionStatus);
            return new ServiceResponse<TransactionStatusDto>
            {
                Success = response.ResponseCode == TransactionResponseCode.Success,
                Message = response.ResponseDescription,
                Data = response.ResponseCode == TransactionResponseCode.Success ? new TransactionStatusDto
                {
                    ReceiverNo = response.ReceiverNo,
                    Amount = response.Amount,
                    Status = response.TransactionStatus.ToDescription()
                }
                : new TransactionStatusDto()
            };
        }
    }
}
