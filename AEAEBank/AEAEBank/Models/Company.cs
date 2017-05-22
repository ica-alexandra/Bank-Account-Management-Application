using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AEAEBank.Models
{
    public class Company
    {
        public Company() { }
        public Company(string CompanyName, string BeneficiaryIBAN, string BeneficiaryName, string BeneficiaryBankName)
        {
            this.CompanyName = CompanyName;
            this.BeneficiaryIBAN = BeneficiaryIBAN;
            this.BeneficiaryName = BeneficiaryName;
            this.BeneficiaryBankName = BeneficiaryBankName;
        }
        [Display(Name = "Company Nanme")]
        public string CompanyName { get; set; }
        
        [Display(Name = "IBAN Beneficiary")]
        public string BeneficiaryIBAN { get; set; }
        
        [Display(Name = "Beneficiary Name")]
        public string BeneficiaryName { get; set; }
        
        [Display(Name = "Beneficiary Bank Name")]
        public string BeneficiaryBankName { get; set; }
    }
}