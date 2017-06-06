﻿using GlammyStore.Data.Infrastructure;
using GlammyStore.Data.Models;

namespace GlammyStore.Data.Repositories
{
    public interface IContactDetailRepository : IRepository<ContactDetail>
    {
    }

    public class ContactDetailRepository : RepositoryBase<ContactDetail>, IContactDetailRepository
    {
        public ContactDetailRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}