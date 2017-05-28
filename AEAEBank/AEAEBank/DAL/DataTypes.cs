using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AEAEBank.DAL
{
    public enum CurrencyType
    {
        USD,
        Euro,
        RON
    }
    public enum TransactionType
    {
        Withdrawal,
        Deposit
    }
    public enum Status
    {
        Blocked,
        Unblocked
    }
}