using Blog.Data.Entities;
using Blog.Services.Interfaces;
using Blog.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.UI.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Detail(int id)
        {
            var postDetail = _postRepository.Get(x => x.Id == id && x.IsActive,
                x => x.Include(y => y.Category)
                .Include(y => y.Comments)
                .Include(y => y.PostTags)
                .ThenInclude(y => y.Tag));

            var postDetailVM = new PostViewModel()
            {
                Title = postDetail.Title,
                Content = postDetail.Content,
                PictureStr = Convert.ToBase64String(postDetail.Picture),
                CommentCount = postDetail.Comments.Count,
                CreatedDate = postDetail.CreatedDate,
                Id = postDetail.Id,
                Tags = postDetail.PostTags.Select(x => x.Tag).ToList(),
                CategoryName = postDetail.Category.CategoryName,
                Comments = postDetail.Comments
            };

            var vm = new DetailViewModel()
            {
                PostDetail = postDetailVM,
                Comment = new CommentViewModel()
            };

            return View(vm);
        }
    }
}
