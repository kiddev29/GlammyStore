﻿using GlammyStore.Data.Infrastructure;
using GlammyStore.Data.Models;

namespace GlammyStore.Data.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory> { }

    public class PostCategoryRepository : RepositoryBase<PostCategory>,IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}