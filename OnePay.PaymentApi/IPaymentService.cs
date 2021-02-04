using OnePay.PaymentApi.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnePay.PaymentApi
{
    public interface IPaymentService
    {
        Task<PaymentResponse> MakePaymentAsync(PaymentRequest request);
    }
}
