using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AEAEBank.Models
{
    public class PaymentViewModel
    {
        [Required]
        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "My Account(IBAN)")]
        public string AccountIBAN { get; set; }

        //javascript TO-DO X_X
        [Display(Name = "Account Balance")]
        public decimal Balance { get; set; }

        [Required]
        [Display(Name = "Payment Amount")]
        public string Amount { get; set; }

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
        [Display(Name = "Invoice Number(Bill Code)")]
        public string Invoice { get; set; }
    }
}