using AEAEBank.App_Start;
using AEAEBank.DAL;
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
        public PaymentViewModel()
        {
            CompanyList = new SelectList(new List<Company>());
            MonetaryAccounts = new SelectList(new List<MonetaryAccountModel>());
        }

        [Required]
        public int? CompanyIndex { get; set; }

        [Display(Name = "Company")]
        public SelectList CompanyList { get; set; }

        [Required]
        public int? MonetaryAccountIndex { get; set; }

        [Display(Name = "My Account")]
        public SelectList MonetaryAccounts { get; set; }

        [Display(Name = "My Account(IBAN)")]
        public string AccountIBAN { get; set; }

        [Display(Name = "Account Balance")]
        public decimal Balance { get; set; }

        [Required]
        [Display(Name = "Payment Amount")]
        [NumericLessThan("Balance",AllowEquality = true)]
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

        [Display(Name = "Currency")]
        public CurrencyType Currency { get; set; }
    }
}