using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [StringLength(50)]
        [MaxLength(30, ErrorMessage = ErrorMessage.MaxLengthUserName)]
        [MinLength(6, ErrorMessage = ErrorMessage.MinLengthUserName)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [StringLength(50)]
        [MaxLength(50, ErrorMessage = ErrorMessage.MaxLengthPassword)]
        [MinLength(10, ErrorMessage = ErrorMessage.MinLengthPassword)]
        public string Password { get; set; } // P@ssword1234

        public bool RememberMe { get; set; }
    }
}