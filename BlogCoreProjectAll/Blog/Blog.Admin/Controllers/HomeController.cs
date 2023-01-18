using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Admin.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {  
        public IActionResult Index()
        { 
            return View();
        }
    }
}