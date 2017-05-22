using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AEAEBank.Models
{
    public class TransactionReportViewModel
    {
        public TransactionReportViewModel() { }

        public int SelectedValue { get; set; }

        public SelectList MonetaryAccounts { get; set; }

        public List<TransactionModel> Transactions { get; set; }
    }
}