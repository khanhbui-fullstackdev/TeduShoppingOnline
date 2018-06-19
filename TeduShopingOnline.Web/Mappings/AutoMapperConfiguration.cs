using AutoMapper;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Web.ViewModels;

namespace TeduShopingOnline.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                cfg.CreateMap<Brand, BrandViewModel>();
                cfg.CreateMap<Slide, SlideViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<ContactDetail, ContactDetailViewModel>();
            });
        }
    }
}
