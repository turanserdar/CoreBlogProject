using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Entities
{
    public class PostTag
    {
        // EF Core'da ara tablolardaki keyleri belirtmek için OnModelCreating'e Fluent olarak yazılması gerekir. 
        public int PostId { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public Post Post { get; set; }

    }
}
