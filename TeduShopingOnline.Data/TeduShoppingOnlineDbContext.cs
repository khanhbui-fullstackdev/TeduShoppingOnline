using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Data
{
    public class TeduShoppingOnlineDbContext : IdentityDbContext<ApplicationUser>
    {
        #region TeduShoppingOnlineDbContext
        public TeduShoppingOnlineDbContext() : base("TeduShoppingOnlineConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        #endregion

        #region Entity Set
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }

        public DbSet<Slide> Slides { set; get; }
        public DbSet<SupportOnline> SupportOnlines { set; get; }
        public DbSet<SystemConfig> SystemConfigs { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<VisitorStatistic> VisitorStatistics { set; get; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Error> Errors { set; get; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }

        public DbSet<ApplicationGroup> ApplicationGroups { set; get; }
        public DbSet<ApplicationRole> ApplicationRoles { set; get; }
        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { set; get; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { set; get; }
        #endregion

        #region Create
        public static TeduShoppingOnlineDbContext Create()
        {
            return new TeduShoppingOnlineDbContext();
        }

        #endregion

        #region On Model Creating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            //modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);

            // Change table name to ApplicationUserRoles
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            // Change table name to ApplicationUserLogins
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            // Change table name to ApplicationRoles
            modelBuilder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            // Change table name to ApplicationUserClaims
            modelBuilder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");
        }
        #endregion
    }
}
