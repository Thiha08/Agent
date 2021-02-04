using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Agent.Core.Constants.OnePay
{
    public enum OnePayResponseCode
    {
        [Description("Success")]
        Success = 000,

        [Description("Field Required / Field Length is too long")]
        FieldRequiredFieldLengthIsTooLong = 012,

        [Description(" System Error")]
        SystemError = 014,

        [Description("Wallet User ID is Invalid")]
        WalletUserIdIsInvalid = 062,

        [Description("Limited Count Exceeded")]
        LimitedCountExceeded = 062,

        [Description("Invalid Sequence Number")]
        InvalidSequenceNumber = 558,

        [Description("Reversal Success")]
        ReversalSuccess = 559,

        [Description("Invalid Merchant Channel")]
        InvalidMerchantChannel = 905,

        [Description("Duplicate Sequence No")]
        DuplicateSequenceNo = 906,

        [Description("Invalid Merchant Account")]
        InvalidMerchantAccount = 907,

        [Description("Invalid Security")]
        InvalidSecurity = 060,

        [Description("Invalid Version")]
        InvalidVersion = 910,

        [Description("Inactive Merchant User")]
        InactiveMerchantUser = 105,

        [Description("Need to Update App Message")]
        NeedToUpdateAppMessage = 106
    }
}
