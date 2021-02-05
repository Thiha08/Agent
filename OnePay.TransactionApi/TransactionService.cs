using Agent.Core.Constants.OnePay;
using Agent.Core.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OnePay.TransactionApi.Common;
using OnePay.TransactionApi.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnePay.TransactionApi
{
    public class TransactionService : ITransactionService
    {
        private IOnePayApiSettings _onePayApiSettings;
        private readonly ILogger<TransactionService> _logger;

        public TransactionService(IOnePayApiSettings onePayApiSettings, ILogger<TransactionService> logger)
        {
            _onePayApiSettings = onePayApiSettings;
            _logger = logger;
        }

        public async Task<TransactionInquiryResponse> GetTransactionInquiryAsync(TransactionInquiryRequest request)
        {
            try
            {
                request.HashValue = Hashing.GetHMAC(request.GetSignatureString(), _onePayApiSettings.AgentSecretKey);

                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                string requestUri = _onePayApiSettings.BaseUrl + _onePayApiSettings.TransactionInquiryUrl;

                using var httpClient = new HttpClient();
                using var response = await httpClient.PostAsync(requestUri, content);
                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TransactionInquiryResponse>(responseString);
            }
            catch (Exception exception)
            {
                _logger.LogError(
                    "GetTransactionInquiry  is failed." + Environment.NewLine +
                    exception.Message);

                return request.GetSystemErrorResponse();
            }
        }

        public async Task<TransactionResponse> MakeTransactionAsync(TransactionRequest request)
        {
            try
            {
                request.HashValue = Hashing.GetHMAC(request.GetSignatureString(), _onePayApiSettings.AgentSecretKey);

                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                string requestUri = _onePayApiSettings.BaseUrl + _onePayApiSettings.TransactionUrl;

                using var httpClient = new HttpClient();
                using var response = await httpClient.PostAsync(requestUri, content);
                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TransactionResponse>(responseString);
            }
            catch (Exception exception)
            {
                _logger.LogError(
                    "MakeTransaction  is failed." + Environment.NewLine +
                    exception.Message);

                return request.GetSystemErrorResponse();
            }
        }

        public async Task<TransactionStatusResponse> CheckTransactionStatusAsync(TransactionStatusRequest request)
        {
            try
            {
                request.HashValue = Hashing.GetHMAC(request.GetSignatureString(), _onePayApiSettings.AgentSecretKey);

                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                string requestUri = _onePayApiSettings.BaseUrl + _onePayApiSettings.TransactionStatusUrl;

                using var httpClient = new HttpClient();
                using var response = await httpClient.PostAsync(requestUri, content);
                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TransactionStatusResponse>(responseString);
            }
            catch (Exception exception)
            {
                _logger.LogError(
                    "CheckTransactionStatus  is failed." + Environment.NewLine +
                    exception.Message);

                return request.GetSystemErrorResponse();
            }
        }

    }
}
