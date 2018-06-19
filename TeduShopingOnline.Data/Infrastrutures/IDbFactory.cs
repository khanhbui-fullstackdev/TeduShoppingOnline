using System;

namespace TeduShopingOnline.Data.Infrastructures
{
    public interface IDbFactory : IDisposable
    {
        TeduShoppingOnlineDbContext Init();
    }
}