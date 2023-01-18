﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog.Admin.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public int GetCurrentUserId()
        {
            var id = Convert.ToInt32(HttpContext.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            return id;
        }

    }
}
