using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShopingOnline.Common.Constants;
using TeduShopingOnline.Model.Abstracts;

namespace TeduShopingOnline.Model.Models
{
    [Table("Pages")]
    public class Page : Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        [Column(TypeName = "nvarchar")]
        public string Name { set; get; }

        [Column(TypeName = "varchar")]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        public string Alias { set; get; }

        public string Content { set; get; }
    }
}