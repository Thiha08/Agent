using System.ComponentModel.DataAnnotations;

namespace OnePay.PaymentApi.Dtos
{
    public class PaymentRequest
    {
        /// <summary>
        /// Version
        /// 
        /// Current Version value :02
        /// </summary>
        [Required]
        [StringLength(4)]
        public string Version { get; set; }

        /// <summary>
        /// Channel From Onepay System
        /// 
        /// Use: ONEPAYASSIGNMENT
        /// </summary>
        [Required]
        [StringLength(25)]
        public string Channel { get; set; }

        /// <summary>
        /// Merchant User ID from Onepay System
        /// 
        /// Use: MM202001281001046396353
        /// </summary>
        [Required]
        [StringLength(35)]
        public string MerchantUserId { get; set; }

        /// <summary>
        /// Invoice Number
        /// </summary>
        [Required]
        [StringLength(30)]
        public string InvoiceNo { get; set; }

        /// <summary>
        /// Unique Sequence Number (Length must be between 30 and 50).
        /// eg.
        /// CEF11DB87838433EB9F33394AE98E3E9 or
        /// 100000000000000000000000000121
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 30)]
        public string SequenceNo { get; set; }

        /// <summary>
        /// Must be Number ex (5000) 
        /// </summary>
        [Required]
        [StringLength(12)]
        [RegularExpression("([1-9][0-9]*)")]
        public string Amount { get; set; }

        /// <summary>
        /// Remark from Merchant
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Remark { get; set; }

        /// <summary>
        /// Indirect Approach (Website):
        /// Pass phone-number entered by user in website.
        /// Direct Approach (PWA within Onepay):
        /// </summary>
        [Required]
        [StringLength(36)]
        public string WalletUserID { get; set; }

        /// <summary>
        /// To invoke url after transaction process. 
        /// 
        /// eg. uat.{merchantname}.com/Reponsetransaction
        /// </summary>
        [Required]
        [StringLength(255)]
        public string CallBackUrl { get; set; }

        /// <summary>
        /// To limit transaction expired seconds. 
        /// ExpiredSeconds must be greater than 60 seconds. 
        /// 
        /// eg. 180 seconds, 300 seconds 
        /// </summary>
        [Required]
        [StringLength(3)]
        public int ExpiredSeconds { get; set; }

        /// <summary>
        /// Value must be Upper Case. For 1.0, HMACSHA1 
        /// cryptographic hash value of:
        /// Version + Channel + MerchantUserId + 
        /// WalletUserID + Amount + Remark + InvoiceNo + SequenceNo
        /// + CallBackUrl + ExpiredSeconds.
        /// </summary>
        [Required]
        [StringLength(40)]
        public string HashValue { get; set; }
    }
}
