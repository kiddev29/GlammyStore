using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlammyStore.Data.Abstracts;

namespace GlammyStore.Data.Models
{
    [Table("Slides")]
    public class Slide :Auditable
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        
        public string Content { get; set; }

        [Required]
        [MaxLength(256)]
        public string Image { get; set; }

        [MaxLength(256)]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }
    }
}