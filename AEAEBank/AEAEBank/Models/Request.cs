using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AEAEBank.Models
{
    public class Request
    {
        public Request() { }

        public Request(ApplicationUser user, string UserPassword)
        {
            UserName = user.UserName;
            CNP = user.CNP;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Address = user.Address;
            Email = user.Email;
            IDCardSeries = user.IDCardSeries;
            IDCardNumber = user.IDCardNumber;
            TelephoneNumber = user.TelephoneNumber;
            RequestType = "User Registration";
            this.UserPassword = UserPassword;
        }

        [Key]
        public int Id { get; set; }
        
        public string UserName { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string CNP { get; set; }
        
        public string IDCardSeries { get; set; }
        
        public string IDCardNumber { get; set; }
        
        public string TelephoneNumber { get; set; }
        
        public string Address { get; set; }

        public string UserPassword { get; set; }

        [Display(Name = "Request Type")]
        public string RequestType { get; set; }

        public ApplicationUser GetUser()
        {
            var user = new ApplicationUser()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                CNP = this.CNP,
                IDCardSeries = this.IDCardSeries,
                IDCardNumber = this.IDCardNumber,
                TelephoneNumber = this.TelephoneNumber,
                Email = this.Email,
                Address = this.Address,
                UserName = this.UserName,
            };
            return user;
        }
    }
}