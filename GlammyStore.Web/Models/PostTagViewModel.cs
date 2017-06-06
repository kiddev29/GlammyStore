using GlammyStore.Data.Abstracts;

namespace GlammyStore.Web.Models
{
    public class PostTagViewModel : Auditable
    {
        public long PostID { get; set; }

        public string TagID { get; set; }

        public virtual PostViewModel Post { get; set; }

        public virtual TagViewModel Tag { get; set; }
    }
}