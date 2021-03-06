﻿using GlammyStore.Data.Infrastructure;
using GlammyStore.Data.Models;

namespace GlammyStore.Data.Repositories
{
    public interface IVisitorStatisticRepository : IRepository<VisitorStatistic> { }

    internal class VisitorStatisticRepository : RepositoryBase<VisitorStatistic>,IVisitorStatisticRepository
    {
        public VisitorStatisticRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}