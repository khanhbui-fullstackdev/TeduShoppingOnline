using System;
using TeduShopingOnline.Model.Abstracts;

namespace TeduShopingOnline.Web.ViewModels
{
    [Serializable]
    public class ProductViewModel : Audit
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Alias { get; set; }

        public int ProductCategoryId { get; set; }

        public virtual ProductCategoryViewModel ProductCategoryViewModel { get; set; }

        public int BrandId { get; set; }

        public virtual BrandViewModel BrandViewModel { get; set; }

        public string Image { get; set; }

        public string MoreImage { get; set; }

        public decimal? Price { get; set; }

        public decimal? Promotion { get; set; }

        public int? Warranty { get; set; }
       
        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }
    }
}