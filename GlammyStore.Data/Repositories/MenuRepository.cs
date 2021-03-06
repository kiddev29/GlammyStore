﻿using GlammyStore.Data.Infrastructure;
using GlammyStore.Data.Models;

namespace GlammyStore.Data.Repositories
{
    public interface IMenuRepository : IRepository<Menu>
    {
    }

    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}