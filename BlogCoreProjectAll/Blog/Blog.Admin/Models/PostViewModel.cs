using Blog.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Admin.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Zorunlu alan")]
        [StringLength(100,ErrorMessage ="En fazla 100 karakter girilebilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(5000, ErrorMessage = "En fazla 5000 karakter girilebilir.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public IFormFile Picture { get; set; }
        public string PictureStr { get; set; }
        public bool IsPublished { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<PostTag> PostTags { get; set; }
        public List<Comment> Comments { get; set; }
        public string Tags { get; set; }
    }
}
