using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlammyStore.Web.Models
{
    public class FeaturedProductViewModel
    {
        public IEnumerable<ProductViewModel> TopViews { get; set; }
        public IEnumerable<ProductViewModel> TopSaleProducts { get; set; }
    }
}