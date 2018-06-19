using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopingOnline.Common.Constants;
using TeduShopingOnline.Model.Abstracts;

namespace TeduShopingOnline.Model.Models
{
    [Table("Posts")]
    public class Post : Audit
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }
        
        public int PostCategoryId { get; set; }

        [ForeignKey("PostCategoryId")]
        public virtual PostCategory PostCategory { get; set; }

        [Column(TypeName = "varchar")]
        public string Image { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Content { get; set; }

        public bool HotFlag { get; set; }

        public bool HomeFlag { get; set; }

        public int ViewCount { get; set; }
    }
}
