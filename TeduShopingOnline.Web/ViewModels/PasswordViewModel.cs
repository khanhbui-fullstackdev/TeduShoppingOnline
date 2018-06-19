using System.ComponentModel.DataAnnotations;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Web.ViewModels
{
    public class PasswordViewModel
    {
        [MinLength(6, ErrorMessage = ErrorMessage.MinLengthUserName)]
        [MaxLength(30, ErrorMessage = ErrorMessage.MaxLengthUserName)]
        public string UserName { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(10, ErrorMessage = ErrorMessage.MinLengthPassword)]
        [MaxLength(50, ErrorMessage = ErrorMessage.MaxLengthPassword)]
        public string OldPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(10, ErrorMessage = ErrorMessage.MinLengthPassword)]
        [MaxLength(50, ErrorMessage = ErrorMessage.MaxLengthPassword)]
        public string NewPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(10, ErrorMessage = ErrorMessage.MinLengthPassword)]
        [MaxLength(50, ErrorMessage = ErrorMessage.MaxLengthPassword)]
        [Compare("NewPassword", ErrorMessage = "Your password doesn't match")]
        public string RepeatNewPassword { get; set; }
    }
}