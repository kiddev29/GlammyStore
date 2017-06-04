namespace GlammyStore.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}