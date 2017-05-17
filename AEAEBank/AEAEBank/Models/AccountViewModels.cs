using AEAEBank.DAL;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AEAEBank.Models
    {
        public class ExternalLoginConfirmationViewModel
        {
            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        public class ExternalLoginListViewModel
        {
            public string ReturnUrl { get; set; }
        }

        public class SendCodeViewModel
        {
            public string SelectedProvider { get; set; }
            public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
            public string ReturnUrl { get; set; }
            public bool RememberMe { get; set; }
        }

        public class VerifyCodeViewModel
        {
            [Required]
            public string Provider { get; set; }

            [Required]
            [Display(Name = "Code")]
            public string Code { get; set; }
            public string ReturnUrl { get; set; }

            [Display(Name = "Remember this browser?")]
            public bool RememberBrowser { get; set; }

            public bool RememberMe { get; set; }
        }

        public class ForgotViewModel
        {
            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        public class ManageUserViewModel
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Current password")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage =
                "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage =
                "The new password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public class LoginViewModel
        {
            [Required]
            [Display(Name = "User Code")]
            public string UserCode { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
        }

        public class RegisterViewModel
        {
            [Required]
            [Display(Name = "First name")]
            //[RegularExpression(@"^([a-zA-Z])$", ErrorMessage = "Invalid First Name")]
            [MaxLength(20, ErrorMessage = "The field must have a maximum of {1} characters")]
            [MinLength(3, ErrorMessage = "The field must have a minimum of {1} characters")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last name")]
            //[RegularExpression(@"^([a-zA-Z])$", ErrorMessage = "Invalid Last Name")]
            [MaxLength(30, ErrorMessage = "The field must have a maximum of {1} characters")]
            [MinLength(3, ErrorMessage = "The field must have a minimum of {1} characters")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "CNP")]
            //[RegularExpression(@"^([0-9])$", ErrorMessage = "Invalid CNP")]
            [MaxLength(13, ErrorMessage = "The field must have {1} characters")]
            [MinLength(13, ErrorMessage = "The field must have {1} characters")]
            public string CNP { get; set; }

            [Required]
            [Display(Name = "ID Card series")]
            //[RegularExpression(@"^([A-Z])$", ErrorMessage = "Invalid ID Card Series")]
            [MaxLength(2, ErrorMessage = "The field must have {1} characters")]
            [MinLength(2, ErrorMessage = "The field must have {1} characters")]
            public string IDCardSeries { get; set; }

            [Required]
            [Display(Name = "ID Card number")]
            //[RegularExpression(@"^([0-9])$", ErrorMessage = "Invalid ID Card number")]
            [MaxLength(6, ErrorMessage = "The field must have {1} characters")]
            [MinLength(6, ErrorMessage = "The field must have {1} characters")]
            public string IDCardNumber { get; set; }

            [Required]
            [Display(Name = "Telephone number")]
            [DataType(DataType.PhoneNumber)]
            public string TelephoneNumber { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Address")]
            [MaxLength(50, ErrorMessage = "The field must have {1} characters")]
            public string Address { get; set; }

            [Display(Name = "Terms and Conditions")]
            public bool Terms { get; set; }

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
                };
                return user;
            }
        }

        public class EditUserViewModel
        {


            public EditUserViewModel() { }

            // Allow Initialization with an instance of ApplicationUser:
            public EditUserViewModel(ApplicationUser user)
            {
                this.UserName = user.UserName;
                this.IDCardSeries = user.IDCardSeries;
                this.IDCardNumber = user.IDCardNumber;
                this.TelephoneNumber = user.TelephoneNumber;
                this.CNP = user.CNP;
                this.Address = user.Address;
                this.FirstName = user.FirstName;
                this.LastName = user.LastName;
                this.Email = user.Email;
            }

            [Required]
            public string UserName { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            public string Email { get; set; }

            [Required]
            public string CNP { get; set; }

            [Required]
            public string IDCardSeries { get; set; }

            [Required]
            public string IDCardNumber { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            public string TelephoneNumber { get; set; }

            [Required]
            public string Address { get; set; }
            
            public List<MonetaryAccountModel> MonetaryAccounts { get; set; }
        }


        public class SelectUserRolesViewModel
        {
            public SelectUserRolesViewModel()
            {
                this.Roles = new List<SelectRoleEditorViewModel>();
            }


            // Enable initialization with an instance of ApplicationUser:
            public SelectUserRolesViewModel(ApplicationUser user) : this()
            {
                this.UserName = user.UserName;
                this.FirstName = user.FirstName;
                this.LastName = user.LastName;

                var Db = new ApplicationDbContext();

                // Add all available roles to the list of EditorViewModels:
                var allRoles = Db.Roles;
                foreach (var role in allRoles)
                {
                    // An EditorViewModel will be used by Editor Template:
                    var rvm = new SelectRoleEditorViewModel(role);
                    this.Roles.Add(rvm);
                }

                // Set the Selected property to true for those roles for 
                // which the current user is a member:

                foreach (var userRole in allRoles)
                {
                    var checkUserRole =
                        this.Roles.Find(r => r.RoleName == userRole.Name);
                    checkUserRole.Selected = true;
                }
            }

            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<SelectRoleEditorViewModel> Roles { get; set; }
        }

        // Used to display a single role with a checkbox, within a list structure:
        public class SelectRoleEditorViewModel
        {
            public SelectRoleEditorViewModel() { }
            public SelectRoleEditorViewModel(IdentityRole role)
            {
                this.RoleName = role.Name;
            }

            public bool Selected { get; set; }

            [Required]
            public string RoleName { get; set; }
        }

        public class ResetPasswordViewModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Code { get; set; }
        }

        public class ForgotPasswordViewModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }
 }

