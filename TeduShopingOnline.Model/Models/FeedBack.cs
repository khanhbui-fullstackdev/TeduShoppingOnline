using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShopingOnline.Model.Models
{
    [Table("FeedBacks")]
    public class FeedBack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [StringLength(250)]
        [Required, Column(TypeName = "nvarchar")]
        public string Name { set; get; }

        [StringLength(250),
         Column(TypeName = "varchar"), Required]
        public string Email { set; get; }

        [StringLength(500),
         Column(TypeName = "nvarchar")]
        public string Message { set; get; }

        public DateTime CreatedDate { set; get; }
    }
}
