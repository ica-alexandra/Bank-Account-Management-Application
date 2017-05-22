using AEAEBank.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AEAEBank.Models
{
    public class TransactionModel
    {
        public TransactionModel() { }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "My Account(IBAN)")]
        public string SourceIBAN { get; set; }


        [Required]
        [Display(Name = "IBAN Beneficiary")]
        public string DestinationIBAN { get; set; }


        [Required]
        [Display(Name = "Transaction Type")]
        public TransactionType TType { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }


        [Display(Name = "Status")]
        public TransactionStatus Status { get; set; }
    }
}
