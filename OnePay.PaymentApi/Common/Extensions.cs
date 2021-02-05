using OnePay.PaymentApi.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnePay.PaymentApi.Common
{
    public static class Extensions
    {
        public static PaymentResponse GetSystemErrorResponse(this PaymentRequest value)
        {
            return new PaymentResponse
            {
                RespCode = PaymentResponseCode.SystemError
            };
        }
    }
}
