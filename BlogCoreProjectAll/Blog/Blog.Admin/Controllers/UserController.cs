using Blog.Admin.Models;
using Blog.Data.Entities;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : BaseController
    {
        private readonly IRepository<User> _userRepository;
        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult List()
        {
            var vm = _userRepository.GetAll().Select(x => new UserViewModel()
            {
                Firstname = x.Name,
                Lastname = x.Surname,
                Email = x.Email,
                Id = x.Id,
                Role = x.Role,
                Password = x.Password
            }).ToList();

            return View(vm);
        }
        public IActionResult Add()
        {
            return View("AddOrEdit");
        }

        public IActionResult Edit(int id)
        {
            var uptUser = _userRepository.Get(x=>x.Id == id);

            if (uptUser != null)
            {
                var vm = new UserViewModel()
                {
                    Id = uptUser.Id,
                    Email = uptUser.Email,
                    Firstname = uptUser.Name,
                    Lastname = uptUser.Surname,
                    Password = uptUser.Password,
                    Role = uptUser.Role
                };
                return View("AddOrEdit", vm);
            }

            TempData["Message"] = "Güncellenecek kullanıcı bulunamadı.";

            return RedirectToAction("List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(UserViewModel model)
        {
            if (model.Id == 0)
            {
                if (ModelState.ContainsKey("Id"))
                    ModelState.Remove("Id");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                Id = model.Id,
                Name = model.Firstname,
                Surname = model.Lastname,
                Email = model.Email,
                Password = model.Password,
                Role = model.Role
            };

            var currentUserId = GetCurrentUserId();

            bool result;
            if (model.Id == 0)
            {
                user.CreatedById = currentUserId;
                result = _userRepository.Add(user);
            }
            else
            {
                user.UpdatedById = currentUserId;
                result = _userRepository.Edit(user);
            }

            if (result)
            {
                return RedirectToAction("List");
            }

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var result = _userRepository.Delete(id);

            TempData["Message"] = result ? "Silindi" : "İşlem başarısız oldu";

            return RedirectToAction("List");
        }
    }
}
