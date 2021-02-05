using OnePay.TransactionApi.Common;

namespace OnePay.TransactionApi.Dtos
{
    public class TransactionStatusResponse
    {
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

        /// <summary>
        /// <para>Unique Sequence Number (Length must be between 30 and 50)</para>
        /// <para>Example: CEF11DB87838433EB9F33394AE98E3E9 or 100000000000000000000000000121</para>
        /// </summary>
        public string SequenceNo { get; set; }
    }
}
