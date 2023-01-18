using Blog.Data;
using Blog.Data.Entities;
using Blog.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Services.Concrete
{
    public class PostRepository : EFRepository<Post>, IPostRepository
    {
        private readonly BlogDbContext _blogDbContext;
        public PostRepository(BlogDbContext blogDbContext) : base(blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public List<Post> GetLatest5Posts()
        {
            return _blogDbContext.Posts
                       .Include(x => x.Comments)
                       .Include(x => x.PostTags).ThenInclude(x => x.Tag)
                       .Where(x => x.IsActive && x.IsPublished)
                       .OrderByDescending(x => x.CreatedDate)
                       .Take(5) // Sql'deki top(5)
                       .ToList();
        }
    }
}
