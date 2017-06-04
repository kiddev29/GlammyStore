using MvcPaging;
using System;

namespace GlammyStore.Web.Models
{
    [Serializable]
    public class ShoppingCartViewModel
    {
        public long ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }

        public IPagedList<ProductViewModel> ListProducts { get; set; }
    }
}