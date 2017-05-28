using AEAEBank.App_Start;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AEAEBank.Models
{
    public class TransferViewModel
    {
        public TransferViewModel() { }

        [Required]
        public int? SelectedValue { get; set; }

        public SelectList MonetaryAccounts { get; set; }

        [Required]
        [Display(Name = "My Account(IBAN)")]
        public string AccountIBAN { get; set; }

        
        [Display(Name = "Account Balance")]
        public decimal Balance { get; set; }

        [Required]
        [NumericLessThan("Balance", AllowEquality = true)]
        [Display(Name = "Transfer Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "IBAN Beneficiary")]
        public string BeneficiaryIBAN { get; set; }
    }
}
