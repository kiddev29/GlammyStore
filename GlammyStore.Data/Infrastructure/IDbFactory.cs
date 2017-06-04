using System;

namespace GlammyStore.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        GlammyStoreDbContext Init();
    }
}