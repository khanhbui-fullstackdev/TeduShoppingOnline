using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        [Column(TypeName = "nvarchar")]
        public string CustomerName { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        [Column(TypeName = "nvarchar")]
        public string CustomerAddress { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [DataType(DataType.EmailAddress, ErrorMessage = ErrorMessage.InvalidEmail)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        [Column(TypeName = "varchar")]
        public string CustomerEmail { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(8, ErrorMessage = "Mobile requires from 8 to 12 characters")]
        [MaxLength(12, ErrorMessage = "Mobile requires from 8 to 12 characters")]
        [Column(TypeName = "varchar")]
        public string CustomerMobile { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        [Column(TypeName = "nvarchar")]
        public string CustomerMessage { set; get; }

        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        [Column(TypeName = "varchar")]
        public string PaymentMethod { set; get; }

        public DateTime? CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public string PaymentStatus { set; get; }
        public bool Status { set; get; }

        [StringLength(128)]
        [Column(TypeName = "nvarchar")]
        public string CustomerId { set; get; }

        [StringLength(256)]
        [Column(TypeName = "varchar")]
        public string CustomerIdentityNumber { set; get; }

        public decimal? Total { get; set; }

        [ForeignKey("CustomerId")]
        public virtual ApplicationUser User { set; get; }

        public virtual IEnumerable<OrderDetail> OrderDetails { set; get; }
    }
}