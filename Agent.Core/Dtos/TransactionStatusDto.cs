using System;
using System.Collections.Generic;
using System.Text;

namespace Agent.Core.Dtos
{
    public class TransactionStatusDto
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
        public string Status { get; set; }
    }
}
