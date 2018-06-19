using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Model.Models
{
    [Table("ContactDetails")]
    public class ContactDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(255),
         Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
         MinLength(2, ErrorMessage = ErrorMessage.MinLengthField),
         MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField),
         Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
         MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField),
         MinLength(2, ErrorMessage = ErrorMessage.MinLengthField),
         StringLength(255),
         Column(TypeName = "nvarchar")]        
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
         Column(TypeName = "varchar"),
         StringLength(20)]
        public string PhoneNumber { get; set; }

        [EmailAddress,
         Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.InvalidEmail),
         StringLength(50), Column(TypeName = "varchar")]         
        public string Email { get; set; }

        [StringLength(255), Column(TypeName = "varchar")]
        public string Website { get; set; }

        [StringLength(500), Column(TypeName = "nvarchar")]
        public string MoreDetail { get; set; }
        
        public double? Latitude { get; set; }// Vi do

        public double? Longitude { get; set; } // Kinh do

        public bool Status { get; set; }

        [StringLength(50), Column(TypeName = "varchar")]
        public string Telephone { get; set; }

        [StringLength(50), Column(TypeName = "varchar")]
        public string Fax { get; set; }
    }
}
