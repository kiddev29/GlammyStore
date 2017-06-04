namespace GlammyStore.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private GlammyStoreDbContext dbContext;

        public GlammyStoreDbContext Init()
        {
            return dbContext ?? (dbContext = new GlammyStoreDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}