using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShopingOnline.Common.Constants;
using TeduShopingOnline.Model.Abstracts;

namespace TeduShopingOnline.Model.Models
{
    [Table("Products")]
    public class Product : Audit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [
            Required(AllowEmptyStrings = false,
            ErrorMessage = ErrorMessage.RequiredField),
            MinLength(2, ErrorMessage = ErrorMessage.MinLengthField),
            MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField),
            Column(TypeName = "nvarchar")
        ]
        public string Name { get; set; }

        [Column(TypeName = "varchar")]
        public string Alias { get; set; }

        public int ProductCategoryId { get; set; }

        [ForeignKey("ProductCategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }

        [Column(TypeName = "varchar"), MaxLength(255)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public decimal? OriginalPrice { get; set; }

        public int? Warranty { get; set; }

        [
            Column(TypeName = "nvarchar"),
            MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField),
            MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)
        ]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public bool? TopSale { get; set; }

        /// <summary>
        /// Male is true
        /// Women is false
        /// </summary>
        public bool? Gender { get; set; }

        public int? Quantity { get; set; }

        public virtual IEnumerable<ProductTag> ProductTags { set; get; }
    }
}
