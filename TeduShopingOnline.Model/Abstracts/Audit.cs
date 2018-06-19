using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopingOnline.Common.Constants;

namespace TeduShopingOnline.Model.Abstracts
{
    public abstract class Audit
    {
        public DateTime? CreatedDate { get; set; }

        [StringLength(255),
         Column(TypeName = "varchar")]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(255),
         Column(TypeName = "varchar")]
        public string UpdatedBy { get; set; }

        [StringLength(500),
         Column(TypeName = "varchar")]
        public string MetaKeywork { get; set; }

        [StringLength(500), 
         Column(TypeName = "varchar")]
        public string MetaDescription { get; set; }

        public bool Status { get; set; }
    }
}
