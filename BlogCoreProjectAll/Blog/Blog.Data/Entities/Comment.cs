using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Data.Entities
{
    public class Comment : BaseEntity
    {
        public string Nickname { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; }
        public bool IsPublished { get; set; }

        #region Releations
        public int PostId { get; set; }
        public Post Post { get; set; }

        #endregion

    }
}
