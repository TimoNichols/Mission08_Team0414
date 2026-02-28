namespace Mission08_Team0414.Models
{
    public class TaskRepository : ITaskRepository
    {
        private Mission08_Team0414Context _context;

        public TaskRepository(Mission08_Team0414Context context)
        {
            _context = context;
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        public Task GetTaskById(int id)
        {
            return _context.Tasks.FirstOrDefault(t => t.TaskId == id);
        }

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public void MarkTaskComplete(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task != null)
            {
                task.Completed = true;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}