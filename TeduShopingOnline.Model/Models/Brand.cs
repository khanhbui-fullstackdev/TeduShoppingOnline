using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Model.Models
{
    [Table("Brands")]
    public class Brand
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        public string Name { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? TopBrand { get; set; }

        public int CountStart { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }

        public int ProductCategoryId { get; set; }

        [ForeignKey("ProductCategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
