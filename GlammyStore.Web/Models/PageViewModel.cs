﻿using GlammyStore.Model.Abstracts;

namespace GlammyStore.Web.Models
{
    public class PageViewModel : Auditable
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Content { set; get; }
    }
}