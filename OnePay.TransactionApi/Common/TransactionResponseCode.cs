using System.ComponentModel;

namespace OnePay.TransactionApi.Common
{
    public enum TransactionResponseCode
    {
        [Description("Success")]
        Success = 000,

        [Description("We are undergoing maintenance. We will be online soon. Thank you for your patience")]
        UndergoingMaintenance = 011,

        [Description("Field Required / Field Length is too long")]
        FieldRequiredFieldLengthIsTooLong = 012,

        [Description("Transaction Expired")]
        TransactionExpired = 013,

        [Description("System Error")]
        SystemError = 014,

        [Description("Receiver Account is frozen")]
        ReceiverAccountIsFrozen = 008,

        [Description("User Account is Locked")]
        UserAccountIsLocked = 009,

        [Description("Invalid Security")]
        InvalidSecurity = 060,

        [Description("Invalid Agent ID")]
        InvalidAgentID = 062,

        [Description("Duplicate SequenceNo")]
        DuplicateSequenceNo = 409,

        [Description("Invalid Mater AgentID")]
        InvalidMaterAgentID = 501,

        [Description("You should try 'X' Ks at least transaction amount.(X mean minimum transaction limit as 1000)")]
        MinimumTransactionAmount = 502,

        [Description("Your Inquiry count was exceeded. Try again after (Date Time). Thanks for using OnePay")]
        ExceededInquiryCount = 503,

        [Description("Your transaction count was exceeded. Try again after (Date Time). Thanks for using OnePay")]
        ExceededTransactionCount = 504,

        [Description("Onepay user doesn’t exist. Please re-enter user phone number")]
        InvalidUser = 505,

        [Description("Amount exceeds transaction limit. Please enter an amount less than or equal to ‘X’ .(X mean per transaction limit as 1000 or 10000)")]
        ExceededTransactionLimit = 506,

        [Description("Amount will exceed daily transaction limit. Please enter a lower amount or try again tomorrow")]
        ExceededDailyTransactionLimit = 507,

        [Description("Amount will exceed wallet balance limit. Please enter a lower amount or try again later")]
        ExceededWalletBalanceLimit = 508,

        [Description("Invalid Transaction")]
        InvalidTransaction = 509,

        [Description("Something went wrong. Please try again")]
        SomethingWentWrong = 510,

        [Description("The receiver has exceeded the daily transaction limit. Please try again")]
        ExceededReceiverDailyTransactionLimit = 511,

        [Description("Reversal Success")]
        ReversalSuccess = 559,

        [Description("Invalid Merchant Channel")]
        InvalidMerchantChannel = 905
    }
}
