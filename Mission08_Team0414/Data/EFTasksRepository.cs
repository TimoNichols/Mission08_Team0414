using System.Linq;
using Mission08_Team0414.Models;
using TaskModel = Mission08_Team0414.Models.Task;

namespace Mission08_Team0414.Data
{
    public class EFTasksRepository : ITasksRepository
    {
        private readonly TasksContext _context;

        public EFTasksRepository(TasksContext context)
        {
            _context = context;
        }

        public IQueryable<TaskModel> Tasks => _context.Tasks;

        public IQueryable<Category> Categories => _context.Categories;

        public void AddTask(TaskModel task)
        {
            _context.Tasks.Add(task);
        }

        public void UpdateTask(TaskModel task)
        {
            _context.Tasks.Update(task);
        }

        public void DeleteTask(TaskModel task)
        {
            _context.Tasks.Remove(task);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}