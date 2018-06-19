using System;
using System.ComponentModel.DataAnnotations;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Web.ViewModels
{
    public class FeedBackViewModel
    {
        public int Id { get; set; }

        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = ErrorMessage.MaxLengthEmail),
         Required(ErrorMessage = ErrorMessage.RequiredField),
         EmailAddress(ErrorMessage = ErrorMessage.InvalidEmail),
         MinLength(3, ErrorMessage = ErrorMessage.MinLengthField)]
        public string Email { get; set; }

        [MaxLength(500, ErrorMessage = ErrorMessage.MaxLengthMessage),
         Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
         MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        public string Message { set; get; }

        public DateTime CreatedDate { get; set; }

        public ContactDetailViewModel ContactDetailViewModel { get; set; }
    }
}