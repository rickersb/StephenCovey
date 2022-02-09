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

        private TaskContext TContext { get; set; }
        //Constructor
        public HomeController( TaskContext someName)
        {
            TContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(Task task)
        {
            if (ModelState.IsValid)
            {
                TContext.Add(task);
                TContext.SaveChanges();
                return View("Confirmation");
            }
            else
            {
                return View(task);
            }
        }

        [HttpGet]
        public IActionResult Quadrants()
        {
            var tasks = TContext.Tasks
                .ToList();

            return View(tasks);
        }
        public IActionResult Done(int taskid)
        {
            var task = TContext.Tasks.Single(x => x.TaskId == taskid);

            task.Completed = true;

            TContext.Update(task);
            TContext.SaveChanges();

            return RedirectToAction("Quadrants");

        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            var task = TContext.Tasks.Single(x => x.TaskId == taskid);

            return View("AddTask", task);
        }

        [HttpPost]
        public IActionResult Edit(Task task)
        {
            TContext.Update(task);
            TContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var task = TContext.Tasks.Single(x => x.TaskId == taskid);

            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(Task task)
        {
            TContext.Tasks.Remove(task);
            TContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}
