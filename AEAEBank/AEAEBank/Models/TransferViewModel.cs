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


        public int SelectedValue { get; set; }

        public SelectList MonetaryAccounts { get; set; }

        [Required]
        [Display(Name = "My Account(IBAN)")]
        public string AccountIBAN { get; set; }

        //javascript TO-DO X_X
        [Display(Name = "Account Balance")]
        public decimal Balance { get; set; }

        [Required]
        [Display(Name = "Transfer Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "IBAN Beneficiary")]
        public string BeneficiaryIBAN { get; set; }

        [Required]
        [Display(Name = "Beneficiary Name")]
        public string BeneficiaryName { get; set; }

        [Required]
        [Display(Name = "Beneficiary Bank Name")]
        public string BeneficiaryBankName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Invoice Number(Bill Code)")]
        public string Details { get; set; }
    }
}
