using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Student_Info_Web_Api.Controllers
{
    public class ShowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}