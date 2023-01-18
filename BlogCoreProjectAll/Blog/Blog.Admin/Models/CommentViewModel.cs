using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Admin.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; }

        [Required(ErrorMessage ="Zorunlu alan")]
        [StringLength(500,ErrorMessage ="En fazla 500 karakter girilebilir.")]
        public string Content { get; set; }

    }
}
