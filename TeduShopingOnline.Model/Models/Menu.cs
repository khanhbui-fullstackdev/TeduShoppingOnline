using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Model.Models
{
    [Table("Menus")]
    public class Menu
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [
            Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField),
            MinLength(2, ErrorMessage = ErrorMessage.MinLengthField),
            MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField),
            Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        [
            //Required(AllowEmptyStrings = false,
            //ErrorMessage = ErrorMessage.RequiredField),
            Column(TypeName = "varchar"), MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        public string Url { get; set; }

        public int? DisplayOrder { get; set; }

        [Required]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual MenuGroup MenuGroup { get; set; }

        [MaxLength(255)]
        public string Target { get; set; }

        public bool? Status { get; set; }
    }
}
