using Blog.Admin.Models;
using Blog.Data.Entities;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Admin.Controllers
{
    public class CommentController : BaseController
    {
        private readonly IRepository<Comment> _commentRepository;
        public CommentController(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public ActionResult List()
        {
            var vm = _commentRepository.GetAll()
                .Select(x => new CommentViewModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    Nickname = x.Nickname
                }).ToList();

            return View(vm);
        }

        public ActionResult Edit(int id)
        {
            var entity = _commentRepository.Get(x=>x.Id == id);

            if (entity != null)
            {
                var vm = new CommentViewModel()
                {
                    Id = entity.Id,
                    Content = entity.Content,
                    Nickname = entity.Nickname
                };

                return View(vm);
            }
            // Mesaj
            return RedirectToAction("List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            var currentUserId = GetCurrentUserId();

            var entity = new Comment()
            {
                Id = model.Id,
                Nickname = model.Nickname,
                Content = model.Content,
                UpdatedById = currentUserId
            };

            var result = _commentRepository.Edit(entity);

            if (result)
            {
                return RedirectToAction("List");
            }

            return View("Edit", model);
        }

        public ActionResult Delete(int id)
        {
            var result = _commentRepository.Delete(id);

            TempData["Message"] = result ? "Silindi" : "İşlem başarısız oldu";

            return RedirectToAction("List");
        }
    }
}
