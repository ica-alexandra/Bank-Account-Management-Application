using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AEAEBank.Models
{
    public class PaymentViewModel
    {
        public PaymentViewModel() { }
        
        public int CompanySelectedValue { get; set; }

        [Display(Name = "Company")]
        public SelectList CompanyList { get; set; }

        public int MAccountsSelectedValue { get; set; }

        [Display(Name = "My Account")]
        public SelectList MonetaryAccounts { get; set; }

        [Display(Name = "My Account(IBAN)")]
        public string AccountIBAN { get; set; }

        //javascript TO-DO X_X
        [Display(Name = "Account Balance")]
        public decimal Balance { get; set; }

        [Required]
        [Display(Name = "Payment Amount")]
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
        
        [Display(Name = "Invoice Number(Bill Code)")]
        public string Invoice { get; set; }
    }
}