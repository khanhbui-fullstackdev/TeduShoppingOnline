using TeduShopingOnline.Model.Abstracts;

namespace TeduShopingOnline.Web.ViewModels
{
    public class PostCategoryViewModel : AuditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public int ParentId { get; set; }

        public int DisplayOrder { get; set; }

        public string Image { get; set; }

        public bool HomeFlag { get; set; }
    }
}