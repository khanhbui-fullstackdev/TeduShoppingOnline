using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Web.ViewModels
{
    public class OrderViewModel
    {
        public int ID { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        public string CustomerName { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        public string CustomerAddress { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthEmail)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthEmail)]
        [EmailAddress(ErrorMessage = ErrorMessage.InvalidEmail)]
        public string CustomerEmail { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthPhone)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthPhone)]
        public string CustomerMobile { set; get; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequiredField)]
        [MinLength(2, ErrorMessage = ErrorMessage.MinLengthField)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLengthField)]
        public string CustomerMessage { set; get; }

        public string PaymentMethod { set; get; }

        public DateTime? CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public string PaymentStatus { set; get; }
        public bool Status { set; get; }

        [StringLength(128)]
        public string CustomerId { set; get; }

        [StringLength(256)]
        [Column(TypeName = "varchar")]
        [MinLength(8, ErrorMessage = ErrorMessage.MinLengthIdentityNumber)]
        [MaxLength(50, ErrorMessage = ErrorMessage.MaxLengthIdentityNumber)]
        public string CustomerIdentityNumber { set; get; }

        public virtual IEnumerable<OrderDetailViewModel> OrderDetails { set; get; }
    }
}