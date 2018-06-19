namespace TeduShopingOnline.Data.Infrastructures
{
    public class DbFactory : Disposable, IDbFactory
    {
        private TeduShoppingOnlineDbContext dbContext;

        public TeduShoppingOnlineDbContext Init()
        {
            return dbContext ?? (dbContext = new TeduShoppingOnlineDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}