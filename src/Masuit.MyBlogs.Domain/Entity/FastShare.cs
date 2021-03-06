﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Masuit.MyBlogs.Domain.Entity
{
    [Table("fastshare")]
    public class FastShare : BaseEntity
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public int Sort { get; set; }
    }
}