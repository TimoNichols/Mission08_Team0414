using Microsoft.AspNetCore.Mvc;
using Mission08_Team0101.Models;

namespace Mission08_Team0101.Controllers
{
    public class TasksController : Controller
    {
        private ITaskRepository _repo;

        public TasksController(ITaskRepository repo)
        {
            _repo = repo;
        }

        // GET: /Tasks/ — Quadrants View (only shows incomplete tasks)
        public IActionResult Index()
        {
            // TODO: Get tasks from repo and pass to view
            return View();
        }

        // GET: /Tasks/Create
        public IActionResult Create()
        {
            // TODO: Pass categories to ViewBag for dropdown
            return View();
        }

        // POST: /Tasks/Create
        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add task to repo
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: /Tasks/Edit/5
        public IActionResult Edit(int id)
        {
            // TODO: Get task by id from repo
            // TODO: Pass categories to ViewBag for dropdown
            return View();
        }

        // POST: /Tasks/Edit/5
        [HttpPost]
        public IActionResult Edit(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                // TODO: Update task in repo
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: /Tasks/Delete/5
        public IActionResult Delete(int id)
        {
            // TODO: Get task by id from repo
            return View();
        }

        // POST: /Tasks/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Delete task from repo
            return RedirectToAction("Index");
        }

        // POST: /Tasks/MarkComplete/5
        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
            // TODO: Set task Completed = true in repo
            return RedirectToAction("Index");
        }
    }
}