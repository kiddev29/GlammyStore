using MvcPaging;
using System;
using GlammyStore.Data.Abstracts;

namespace GlammyStore.Web.Models
{
    [Serializable]
    public class WishlistViewModel: Auditable
    {
        public int ID { get; set; }
        public string UserId { get; set; }

        public long ProductId { get; set; }

        public virtual ApplicationUserViewModel ApplicationUser { get; set; }

        public virtual ProductViewModel Product { get; set; }

        public IPagedList<ProductViewModel> ListProducts { get; set; }
    }
}