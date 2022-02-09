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
        public HomeController( TaskContext someName)
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
            ViewBag.Tasks = blahContext.Tasks.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Tasks(Task task)
        {
            if (ModelState.IsValid)
            {
                blahContext.Add(task);
                blahContext.SaveChanges();
                return View("Confirmation", task);
            }
            else
            {
                ViewBag.Tasks = blahContext.Tasks.ToList();

                return View(task);
            }
        }

        [HttpGet]
        public IActionResult Quadrants()
        {
            var tasks = blahContext.Tasks
                .ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Tasks = blahContext.Tasks.ToList();

            var task = blahContext.Tasks.Single(x => x.TaskId == taskid);

            return View("Tasks", task);
        }

        [HttpPost]
        public IActionResult Edit(Task task)
        {
            blahContext.Update(task);
            blahContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var task = blahContext.Tasks.Single(x => x.TaskId == taskid);

            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(Task task)
        {
            blahContext.Tasks.Remove(task);
            blahContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }
        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }
    }
}
