using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Covey.Models;

namespace Covey.Controllers
{
    public class HomeController : Controller
    {

        private TaskContext blahContext { get; set; }
        public HomeController(ILogger<HomeController> logger, TaskContext someName)
        {
            blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Tasks()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Tasks(Task task)
        {
            blahContext.Add(task);
            blahContext.SaveChanges();
            return View("Confirmation", task);
        }

        [HttpGet]
        public IActionResult Quadrants()
        {
            var tasks = blahContext.Tasks
                .ToList();

            return View();
        }
    }
}
