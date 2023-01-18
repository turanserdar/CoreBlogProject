using Blog.Admin.Models;
using Blog.Data.Entities;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog.Admin.Controllers
{
    public class TagController : BaseController
    {
        private readonly IRepository<Tag> _tagRepository;
        public TagController(IRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public ActionResult List()
        {
            var vm = _tagRepository.GetAll()
                .Select(x => new TagViewModel()
                {
                    Name = x.Name,
                    Id = x.Id
                }).ToList();

            return View(vm);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(TagViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.Id == 0)
                    return View("Add", model);
                else
                    return View("Edit", model);
            }

            var entity = new Tag()
            {
                Id = model.Id,
                Name = model.Name
            };

            var currentUserId = GetCurrentUserId();

            bool result;

            if (model.Id == 0)
            {
                entity.CreatedById = currentUserId;
                result = _tagRepository.Add(entity);
            }
            else
            {
                entity.UpdatedById = currentUserId;
                result = _tagRepository.Edit(entity);
            }

            if (result)
            {
                return RedirectToAction("List");
            }

            if (model.Id == 0)
                return View("Add", model);
            else
                return View("Edit", model);
        }

        public ActionResult Edit(int id)
        {
            var entity = _tagRepository.Get(x => x.Id == id);

            if (entity != null)
            {
                var vm = new TagViewModel()
                {
                    Id = entity.Id,
                    Name = entity.Name
                };

                return View(vm);
            }
            // Mesaj
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var result = _tagRepository.Delete(id);

            TempData["Message"] = result ? "Silindi" : "İşlem başarısız oldu";

            return RedirectToAction("List");
        }

    }
}
