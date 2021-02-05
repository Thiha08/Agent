using Agent.Core.Extensions;
using OnePay.PaymentApi.Common;
using System.ComponentModel.DataAnnotations;

namespace OnePay.PaymentApi.Dtos
{
    public class PaymentResponse
    {
        /// <summary>
        /// Channel From Onepay System
        /// </summary>
        [StringLength(25)]
        public string Channel { get; set; }

        /// <summary>
        /// Sequence No From Reques
        /// </summary>
        [StringLength(50)]
        public string ReferIntegrationId { get; set; }

        /// <summary>
        /// Merchant User ID from Onepay System
        /// </summary>
        [StringLength(25)]
        public string MerchantUserId { get; set; }

        /// <summary>
        /// Must be Number ex (5000) 
        /// </summary>
        [StringLength(12)]
        [RegularExpression("([1-9][0-9]*)")]
        public string Amount { get; set; }

        /// <summary>
        /// Response Description
        /// eg. Success , Fail 
        /// </summary>
        [Required]
        [StringLength(255)]
        public string RespDescription => RespCode.ToDescription();

        /// <summary>
        /// Response Code
        /// eg. 000, 001,002,012,909
        /// </summary>
        [StringLength(4)]
        public PaymentResponseCode RespCode { get; set; }

        /// <summary>
        /// Value must be Upper Case. For 1.0, HMACSHA1 
        /// cryptographic hash value of:
        /// Channel + ReferIntegrationId + 
        /// MerchantUserId + Amount + Remark +
        /// RespDescription + RespCode.
        /// </summary>
        [StringLength(40)]
        public string HashValue { get; set; }


    }
}
