using System.Collections.Generic;

namespace GlammyStore.Web.Models
{
    public class ApplicationGroupViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<ApplicationRoleViewModel> Roles { set; get; }
    }
}