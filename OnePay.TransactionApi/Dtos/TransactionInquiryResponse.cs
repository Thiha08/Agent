using OnePay.TransactionApi.Common;

namespace OnePay.TransactionApi.Dtos
{
    public class TransactionInquiryResponse
    {
        /// <summary>
        /// A class that has parameters. See below table for parameter of InquiryDetail
        /// </summary>
        public InquiryDetail InquiryDetail { get; set; }

        /// <summary>
        /// <para>Response Code</para>
        /// <para>Example: 000</para>
        /// </summary>
        public TransactionResponseCode ResponseCode { get; set; }

        /// <summary>
        /// <para>Response Description</para>
        /// <para>Example: Success</para>
        /// </summary>
        public string ResponseDescription { get; set; }

        public string NextAllowedTime { get; set; }
    }
}
