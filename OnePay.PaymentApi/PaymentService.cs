using Agent.Core.Constants.OnePay;
using Agent.Core.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OnePay.PaymentApi.Common;
using OnePay.PaymentApi.Dtos;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnePay.PaymentApi
{
    public class PaymentService : IPaymentService
    {
        private IOnePayApiSettings _onePayApiSettings;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(IOnePayApiSettings onePayApiSettings, ILogger<PaymentService> logger)
        {
            _onePayApiSettings = onePayApiSettings;
            _logger = logger;
        }

        public async Task<PaymentResponse> MakePaymentAsync(PaymentRequest request)
        {
            try
            {
                request.HashValue = Hashing.GetHMAC(request.GetSignatureString(), _onePayApiSettings.Token);

                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                string requestUri = _onePayApiSettings.BaseUrl + _onePayApiSettings.DirectPaymentUrl;

                using var httpClient = new HttpClient();
                using var response = await httpClient.PostAsync(requestUri, content);
                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PaymentResponse>(responseString);
            }
            catch (Exception exception)
            {
                _logger.LogError(
                    "MakePayment  is failed." + Environment.NewLine +
                    exception.Message);

                return request.GetSystemErrorResponse();
            }
        }
    }
}
