using System;
using System.Collections.Generic;
using System.Text;

namespace OnePay.TransactionApi.Dtos
{
    public class InquiryDetail
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
        /// Agent Name
        /// </summary>
        public string AgentName { get; set; }

        /// <summary>
        /// Original Amount Receiver cash in
        /// </summary>
        public string OriginalAmount { get; set; }

        /// <summary>
        /// Agent Commission charges
        /// </summary>
        public string AgentCommission { get; set; }

        /// <summary>
        /// Customer Charges
        /// </summary>
        public string CustomerCharges { get; set; }

        /// <summary>
        /// Total Amount : OriginalAmount + AgentCommission + CustomerCharges
        /// </summary>
        public string TotalAmount { get; set; }

        /// <summary>
        /// Invoice Number
        /// </summary>
        public string nvoiceNo { get; set; }

        /// <summary>
        /// Need this to request transaction API after inquiry is success
        /// </summary>
        public string SequenceNo { get; set; }

        /// <summary>
        /// Number of receiver
        /// </summary>
        public string ReceiverNo { get; set; }

        /// <summary>
        /// <para>For Security purpose, Agent must compare hash. The value of hash is consist of:</para>
        /// <para>AgentID + SubAgentID + AgentName + OriginalAmount + AgentCommission + TotalAmount + CustomerCharges + InvoiceNo + SequenceNo + ReceiverNo</para>
        /// </summary>
        public string HashValue { get; set; }
    }
}
