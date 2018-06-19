using System;

namespace TeduShopingOnline.Model.Abstracts
{
    public abstract class AuditViewModel
    {
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public string MetaKeywork { get; set; }
        public string MetaDescription { get; set; }

        public bool Status { get; set; }
    }
}
