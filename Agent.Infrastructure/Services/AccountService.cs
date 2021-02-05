using Agent.Core.Constants.Cache;
using Agent.Core.Constants.OnePay;
using Agent.Core.Dtos;
using Agent.Core.Extensions;
using Agent.Core.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public AccountService(ITransactionService transactionService, IOnePayApiSettings onePayApiSettings, IMemoryCache memoryCache, IMapper mapper)
        {
            _transactionService = transactionService;
            _onePayApiSettings = onePayApiSettings;
            _memoryCache = memoryCache;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<InquiryDetailDto>> GetTransactionInquiryAsync()
        {
            var transactionInquiry = new TransactionInquiryRequest
            {
                AgentID = _onePayApiSettings.AgentID,
                SubAgentID = "1010",
                InvoiceNo = "149vv456lh2o1p8896823658119253412",
                SequenceNo = Guid.NewGuid().ToString(),
                ReceiverNo = "959960526124",
                Amount = "1000",
                ExpiredSeconds = 900,
                RequestTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") // "2020-10-21 10:39:14.109"
            };
            var response = await _transactionService.GetTransactionInquiryAsync(transactionInquiry);

            // USE CACHE FOR TESTING
            if (response.ResponseCode == TransactionResponseCode.Success)
            {
                _memoryCache.Set(CacheKeys.InquiryDetail, response.InquiryDetail);
            }

            return new ServiceResponse<InquiryDetailDto>
            {
                Success = response.ResponseCode == TransactionResponseCode.Success,
                Message = response.ResponseDescription,
                Data = _mapper.Map<InquiryDetailDto>(response.InquiryDetail)
            };
        }

        public async Task<ServiceResponse> MakeTransactionAsync()
        {
            _memoryCache.TryGetValue(CacheKeys.InquiryDetail, out InquiryDetail inquiryDetail);

            if(inquiryDetail == null)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "No ongoing transaction",
                };
            }

            var transaction = new TransactionRequest
            {
                AgentID = inquiryDetail.AgentID,
                SubAgentID = inquiryDetail.SubAgentID,
                SequenceNo = inquiryDetail.SequenceNo,
                ReceiverNo = inquiryDetail.ReceiverNo,
                Amount = inquiryDetail.OriginalAmount,
                RequestTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
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
            _memoryCache.TryGetValue(CacheKeys.InquiryDetail, out InquiryDetail inquiryDetail);

            if (inquiryDetail == null)
            {
                return new ServiceResponse<TransactionStatusDto>
                {
                    Success = false,
                    Message = "No ongoing transaction",
                    Data = new TransactionStatusDto()
                };
            }

            var transactionStatus = new TransactionStatusRequest
            {
                AgentID = inquiryDetail.AgentID,
                SubAgentID = inquiryDetail.SubAgentID,
                SequenceNo = inquiryDetail.SequenceNo
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
                    Status = response.TransactionStatus
                }
                : new TransactionStatusDto()
            };
        }
    }
}
