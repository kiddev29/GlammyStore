﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GlammyStore.Data.Abstracts;

namespace GlammyStore.Data.Models
{
    [Table("Brands")]
    public class Brand : Auditable
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(150)]
        [Required]
        public string Name { get; set; }

        [MaxLength(150)]
        [Required]
        public string Alias { get; set; }

        [MaxLength(150)]
        public string Country { get; set; }

        [MaxLength(750)]
        public string Description { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        [MaxLength(300)]
        [Column(TypeName = "varchar")]
        public string Website { get; set; }

        public bool? HotFlag { get; set; }

        public bool IsDeleted { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}