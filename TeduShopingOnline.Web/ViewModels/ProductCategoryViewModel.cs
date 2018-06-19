using System.Collections.Generic;
using TeduShopingOnline.Model.Abstracts;

namespace TeduShopingOnline.Web.ViewModels
{
    public class ProductCategoryViewModel : Audit
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public bool? HomeFlag { get; set; }

        public int? DisplayOrder { get; set; }

        public virtual ICollection<ProductViewModel> Products { get; set; }
        public virtual ICollection<BrandViewModel> Brands { get; set; }
    }
}
