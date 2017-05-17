using AEAEBank.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AEAEBank.Models
{
    public class MonetaryAccountModel
    {
        public MonetaryAccountModel() { }

        [Key]
        public int Id { get; set; }

        
        public string UserId { get; set; }


        [Required]
        [Display(Name = "IBAN")]
        public string IBAN { get; set; }

        [Required]
        [Display(Name = "Currency")]
        public CurrencyType Currency { get; set; }

        
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        
        [Display(Name = "Status")]
        public bool Blocked  { get; set; }
    }
}