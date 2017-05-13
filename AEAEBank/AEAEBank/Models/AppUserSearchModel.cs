using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AEAEBank.Models
{
    public class AppUserSearchModel
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public string CNP { get; set; }
        
        public string IDCardSeries { get; set; }
        
        public string IDCardNumber { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public string TelephoneNumber { get; set; }
        
        public string Address { get; set; }
    }
}