using OnePay.PaymentApi.Dtos;
using System;
using System.Threading.Tasks;

namespace OnePay.PaymentApi
{
    public class PaymentService : IPaymentService
    {
        public Task<PaymentResponse> MakePaymentAsync(PaymentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
