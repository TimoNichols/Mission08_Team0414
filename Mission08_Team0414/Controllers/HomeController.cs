using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0414.Models;
using TaskModel = Mission08_Team0414.Models.Task;

namespace Mission08_Team0414.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository repo)
        {
            _repo = repo;
        }

        // GET: / — Home page
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/Quadrants
        public IActionResult Quadrants()
        {
            var tasks = _repo.GetAllTasks();
            return View(tasks);
        }

        // GET: /Home/AddEditTask
        public IActionResult AddEditTask()
        {
            ViewBag.Title = "Add Task";
            ViewBag.Categories = _repo.GetCategories();
            return View(null);
        }

        // POST: /Home/AddEditTask
        [HttpPost]
        public IActionResult AddEditTask(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(task);
                return RedirectToAction("Quadrants");
            }
            ViewBag.Title = "Add Task";
            ViewBag.Categories = _repo.GetCategories();
            return View(task);
        }

        // GET: /Home/Edit/5
        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit Task";
            ViewBag.Categories = _repo.GetCategories();
            var task = _repo.GetTaskById(id);
            return View("AddEditTask", task);
        }

        // POST: /Home/Edit/5
        [HttpPost]
        public IActionResult Edit(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(task);
                return RedirectToAction("Quadrants");
            }
            ViewBag.Title = "Edit Task";
            ViewBag.Categories = _repo.GetCategories();
            return View("AddEditTask", task);
        }

        // GET: /Home/Delete/5
        public IActionResult Delete(int id)
        {
            _repo.DeleteTask(id);
            return RedirectToAction("Quadrants");
        }

        // POST: /Home/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteTask(id);
            return RedirectToAction("Quadrants");
        }

        // POST: /Home/MarkComplete/5
        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
            _repo.MarkTaskComplete(id);
            return RedirectToAction("Quadrants");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}