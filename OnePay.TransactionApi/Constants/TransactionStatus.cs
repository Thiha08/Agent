using System.ComponentModel;

namespace OnePay.TransactionApi.Constants
{
    public enum TransactionStatus
    {
        [Description("Success")]
        Success = 000,

        [Description("Cancel Transaction")]
        CancelTransaction = 012,

        [Description("Transaction Time Out")]
        TransactionTimeOut = 013,

        [Description(" System Error")]
        SystemError = 014,
    }
}
