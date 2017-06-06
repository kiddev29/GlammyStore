using GlammyStore.Data.Infrastructure;
using GlammyStore.Data.Models;

namespace GlammyStore.Data.Repositories
{
    public interface ITagRepository : IRepository<Tag> { }

    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}