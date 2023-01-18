using Blog.Admin.Models;
using Blog.Data.Entities;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Admin.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostRepository _postRepository;
        private readonly IRepository<Category> _categoryRepository;
        public PostController(IPostRepository postRepository, IRepository<Category> categoryRepository)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
        }

        public ActionResult List()
        {
            var vm = _postRepository.GetAll(include: x => x.Include(y => y.Category)).Select(x => new PostViewModel()
            {
                CategoryName = x.Category.CategoryName,
                Id = x.Id,
                IsPublished = x.IsPublished,
                Title = x.Title
            }).ToList();

            return View(vm);
        }
        public IActionResult Detail(int id)
        {
            var post = _postRepository.Get(x => x.Id == id, x => x.Include(y => y.Category));

            var vm = new PostViewModel()
            {
                CategoryName = post.Category.CategoryName,
                Content = post.Content,
                IsPublished = post.IsPublished,
                PictureStr = Convert.ToBase64String(post.Picture),
                Title = post.Title,
                Tags = string.Join(',', post.PostTags.Select(x => x.Tag.Name))
            };

            return View(vm);
        }
        public ActionResult Add()
        {
            ViewBag.Categories = _categoryRepository.GetAll()
                .Select(x => new SelectListItem()
                {
                    Text = x.CategoryName,
                    Value = x.Id.ToString()
                }).ToList();

            return View("AddOrEdit");
        }
        public IActionResult Edit(int id)
        {
            var uptPost = _postRepository.Get(x => x.Id == id);

            if (uptPost != null)
            {
                ViewBag.Categories = _categoryRepository.GetAll().Select(x => new SelectListItem()
                {
                    Text = x.CategoryName,
                    Value = x.Id.ToString()
                }).ToList();

                var vm = new PostViewModel()
                {
                    Title = uptPost.Title,
                    Content = uptPost.Content,
                    Tags = string.Join(',', uptPost.PostTags.Select(x => x.Tag.Name)),
                    CategoryId = uptPost.CategoryId,
                    IsPublished = uptPost.IsPublished
                };

                return View("AddOrEdit", vm);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(PostViewModel model)
        {
            if (model.Id == 0)// add
            {
                if (ModelState.ContainsKey("Id"))
                    ModelState.Remove("Id");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _categoryRepository.GetAll()
                 .Select(x => new SelectListItem()
                 {
                     Text = x.CategoryName,
                     Value = x.Id.ToString()
                 }).ToList();

                return View(model);
            }

            var post = new Post()
            {
                Id = model.Id,
                CategoryId = model.CategoryId,
                Content = model.Content,
                Title = model.Title,
                IsPublished = model.IsPublished
            };

            #region Picture ekleme

            if (model.Picture.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    model.Picture.CopyTo(ms);
                    post.Picture = ms.ToArray();
                }
            }

            #endregion

            #region Tag'leri ekleme

            if (!string.IsNullOrEmpty(model.Tags))
            {
                var tagList = model.Tags.Split(',').ToList();
                post.PostTags = tagList.Select(x => new PostTag()
                {
                    Tag = new Tag() { Name = x.Trim().ToLower() }
                }).ToList();
            }

            #endregion

            var currentUserId = GetCurrentUserId();

            bool result;

            if (model.Id == 0)
            {
                post.CreatedById = currentUserId;
                result = _postRepository.Add(post);
            }
            else
            {
                post.UpdatedById = currentUserId;
                result = _postRepository.Edit(post);
            }

            if (result)
            {
                return RedirectToAction("List");
            }

            ViewBag.Categories = _categoryRepository.GetAll()
              .Select(x => new SelectListItem()
              {
                  Text = x.CategoryName,
                  Value = x.Id.ToString()
              }).ToList();

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var result = _postRepository.Delete(id);

            TempData["Message"] = result ? "Silindi" : "İşlem başarısız oldu";

            return RedirectToAction("List");
        }

    }
}
