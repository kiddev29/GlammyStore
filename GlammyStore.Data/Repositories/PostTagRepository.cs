﻿using GlammyStore.Data.Infrastructure;
using GlammyStore.Model.Models;

namespace GlammyStore.Data.Repositories
{
    public interface IPostTagRepository : IRepository<PostTag> { }

    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}