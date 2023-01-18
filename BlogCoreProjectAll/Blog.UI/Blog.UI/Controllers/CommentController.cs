using Blog.Data.Entities;
using Blog.Services.Interfaces;
using Blog.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.UI.Controllers
{
    public class CommentController : Controller
    {
        private readonly IRepository<Comment> _commentRepository;
        public CommentController(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CommentViewModel model)
        {
            //_logger.LogInformation("selam");

            if (!ModelState.IsValid)
            {
                // mesaj
                return Redirect("/post/detail/" + model.PostId);
            }

            var result = _commentRepository.Add(new Comment()
            {
                Content = model.CommentText,
                Nickname = model.Nickname,
                PostId = model.PostId,
                CreatedDate = DateTime.Now,
                IsActive = true,
                CreatedById = -1
            });

            return Redirect("/post/detail/" + model.PostId);
        }
    }
}
