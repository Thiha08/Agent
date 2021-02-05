using OnePay.TransactionApi.Common;
using System.Transactions;

namespace OnePay.TransactionApi.Dtos
{
    public class TransactionStatusResponse
    {
        /// <summary>
        /// One Pay User Phone number
        /// </summary>
        public string ReceiverNo { get; set; }

        /// <summary>
        /// Must be Number ex (5000)
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// <para>Response Code</para>
        /// <para>Example: 000</para>
        /// </summary>
        public TransactionStatus TransactionStatus { get; set; }

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
    }
}
