using Blog.Data.Entities;
using Blog.Services.Interfaces;
using Blog.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IPostRepository _postRepository;
        public HomeController(IRepository<Category> categoryRepository, IPostRepository postRepository)
        {
            _categoryRepository = categoryRepository;
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel();

            #region Kategoriler bölümü için
            var categories = _categoryRepository.GetAll(include: x => x.Include(y => y.Posts))
                  .Select(x => new CategoryViewModel()
                  {
                      CategoryName = x.CategoryName,
                      Id = x.Id,
                      PostCount = x.Posts.Count(y => y.IsActive)
                  }).ToList();

            //  ViewBag.Categories = categories;
            homeViewModel.Categories = categories;
            #endregion

            #region Postlar için

            var posts = _postRepository.GetLatest5Posts()
                .Select(x => new PostViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CommentCount = x.Comments.Count(y => y.IsActive && y.IsPublished),
                    CreatedDate = x.CreatedDate,
                    PictureStr = Convert.ToBase64String(x.Picture),
                    Tags = x.PostTags.Select(y => y.Tag).ToList()
                }).ToList();

            //  ViewBag.Posts = posts;
            homeViewModel.Posts = posts;

            #endregion

            return View(homeViewModel);
        }

    }
}
