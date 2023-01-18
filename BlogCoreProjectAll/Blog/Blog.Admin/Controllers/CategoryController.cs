using Blog.Admin.Models;
using Blog.Data.Entities;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog.Admin.Controllers
{
    [Authorize]
    public class CategoryController : BaseController
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [Authorize(Roles = "admin")]
        public IActionResult List()
        {
            var categories = _categoryRepository.GetAll().Select(x =>
            new CategoryViewModel()
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Description = x.Description,
                PictureStr = Convert.ToBase64String(x.Picture)
            }).ToList();

            return View(categories);
        }

        [Authorize(Roles = "editor")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    return View("Add", model);
                }
                else
                {
                    return View("Edit", model);
                }
            }

            var currentUserIdStr = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var currentUserId = Convert.ToInt32(currentUserIdStr);

            Category entity = new Category()
            {
                CategoryName = model.CategoryName,
                Description = model.Description
            };

            #region Picture için düzenleme

            if (model.Picture.Length > 0) // lenght = 0 ise dosyanın içi boştur
            {
                using (var ms = new MemoryStream())
                {
                    model.Picture.CopyTo(ms);
                    var fileByteArray = ms.ToArray();

                    entity.Picture = fileByteArray;
                }
            }
            else
            {
                ViewBag.Message = "Boş dosya yükleyemezsiniz";
            }

            #endregion

            bool result;

            if (model.Id == 0)
            {
                // new
                entity.CreatedById = currentUserId;
                result = _categoryRepository.Add(entity);
            }
            else
            {
                //edit
                entity.Id = model.Id;
                entity.UpdatedById = currentUserId;
                result = _categoryRepository.Edit(entity);
            }

            if (result)
            {
                return RedirectToAction("List");
            }

            if (model.Id == 0)
            {
                return View("Add", model);
            }
            else
            {
                return View("Edit", model);
            }
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryRepository.Get(x => x.Id == id);

            if (category != null)
            {
                var vm = new CategoryViewModel()
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };

                return View(vm);
            }

            // mesaj

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var result = _categoryRepository.Delete(id);

            TempData["Message"] = result ? "İşlem başarılı" : "Silme yapılamadı";

            return RedirectToAction("List");
        }
    }
}
