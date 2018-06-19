using TeduShopingOnline.Model.Abstracts;

namespace TeduShopingOnline.Web.ViewModels
{
    public class PostViewModel : AuditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PostCategoryId { get; set; }

        public virtual PostCategoryViewModel PostCategoryViewModel { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool HotFlag { get; set; }

        public bool HomeFlag { get; set; }

        public int ViewCount { get; set; }
    }
}