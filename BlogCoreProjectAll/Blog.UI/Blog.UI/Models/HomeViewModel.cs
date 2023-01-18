using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.UI.Models
{
    public class HomeViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public List<PostViewModel> Posts { get; set; }
    }
}
