using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

using TeduShopingOnline.Model.Abstracts;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Model.Models
{
    [Table("ProductCategories")]
    public class ProductCategory : Audit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = ErrorMessage.RequiredField),
            MinLength(2, ErrorMessage = ErrorMessage.MinLengthField),
            MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField),
            Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        [Column(TypeName = "varchar")]
        public string Alias { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Description { get; set; }

        public int? ParentId { get; set; }

        public bool? HomeFlag { get; set; }

        public int? DisplayOrder { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
    }
}
