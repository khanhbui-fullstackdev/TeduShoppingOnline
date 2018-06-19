using System.ComponentModel.DataAnnotations;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Web.ViewModels
{
    public class ContactDetailViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
         MinLength(2, ErrorMessage = ErrorMessage.MinLengthField),
         MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
         MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField),
         MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
         MaxLength(20, ErrorMessage = ErrorMessage.MaxLengthPhone),
         MinLength(10, ErrorMessage = ErrorMessage.MinLengthPhone)]
        public string PhoneNumber { get; set; }

        [EmailAddress,
         Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.InvalidEmail),
         MinLength(12, ErrorMessage = ErrorMessage.MinLengthEmail),
         MaxLength(50, ErrorMessage = ErrorMessage.MaxLengthEmail)]
        public string Email { get; set; }

        public string Website { get; set; }

        public string MoreDetail { get; set; }

        public double? Latitude { get; set; }// Vi do

        public double? Longitude { get; set; } // Kinh do

        public bool Status { get; set; }

        public string Telephone { get; set; }

        public string Fax { get; set; }
    }
}
