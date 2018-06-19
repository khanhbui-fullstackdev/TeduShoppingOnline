using System;
using System.ComponentModel.DataAnnotations;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(6, ErrorMessage = ErrorMessage.MinLengthUserName)]
        [MaxLength(30, ErrorMessage = ErrorMessage.MaxLengthUserName)]
        public string UserName { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        public string LastName { get; set; }

        private string fullName;
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
            private set
            {
                fullName = value;
            }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(8, ErrorMessage = ErrorMessage.MinLengthIdentityNumber)]
        [MaxLength(50, ErrorMessage = ErrorMessage.MaxLengthIdentityNumber)]
        public string IdentityNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(10, ErrorMessage = ErrorMessage.MinLengthPassword)]
        [MaxLength(50, ErrorMessage = ErrorMessage.MaxLengthPassword)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(10, ErrorMessage = ErrorMessage.MinLengthPassword)]
        [MaxLength(50, ErrorMessage = ErrorMessage.MaxLengthPassword)]
        [Compare("Password", ErrorMessage = "Your password doesn't match")]
        public string RepeatPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(12, ErrorMessage = ErrorMessage.MinLengthEmail)]
        [MaxLength(50, ErrorMessage = ErrorMessage.MaxLengthEmail)]
        [EmailAddress(ErrorMessage = ErrorMessage.InvalidEmail)]
        public string Email { get; set; }

        public string Address { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(10, ErrorMessage = ErrorMessage.MinLengthPhone)]
        [MaxLength(20, ErrorMessage = ErrorMessage.MaxLengthPhone)]
        public string PhoneNumber { set; get; }

        [Required(ErrorMessage = ErrorMessage.RequiredBirthday)]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}