using System;
using System.Collections.Generic;
using System.Text;

namespace OnePay.TransactionApi.Dtos
{
    public class TransactionRequest
    {
        /// <summary>
        /// AgentID from OnePay system. It is received after registered
        /// </summary>
        public string AgentID { get; set; }

        /// <summary>
        /// SubAgentID from Agent system
        /// </summary>
        public string SubAgentID { get; set; }

        /// <summary>
        /// <para>Unique Sequence Number (Length must be between 30 and 50)</para>
        /// <para>Example: CEF11DB87838433EB9F33394AE98E3E9 or 100000000000000000000000000121</para>
        /// </summary>
        public string SequenceNo { get; set; }

        /// <summary>
        /// One Pay User Phone number
        /// </summary>
        public string ReceiverNo { get; set; }

        /// <summary>
        /// Must be Number ex (5000)
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// <para>Put Current DateTime in this field with the following format:</para>
        /// <para>yyyy-MM-dd HH:mm:ss</para>
        /// </summary>
        public string RequestTimeStamp { get; set; }

        /// <summary>
        /// <para>Value must be Upper Case. For 1.0, HMACSHA1 cryptographic hash value of:</para>
        /// <para>AgentID + SubAgentID + InvoiceNo + SequenceNo + ReceiverNo + Amount + ExpiredSeconds + RequestTimeStamp</para>
        /// </summary>
        public string HashValue { get; set; }
    }
}
