using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Model.Models
{
    [Table("Footers")]
    public class Footer
    {
        [Key, MaxLength(50, ErrorMessage = "This field requires 50 characters")]
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField), Column(TypeName = "varchar")]
        public string Content { get; set; }
    }
}
