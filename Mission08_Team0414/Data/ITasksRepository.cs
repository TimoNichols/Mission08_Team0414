using System.Linq;
using Mission08_Team0414.Models;
using TaskModel = Mission08_Team0414.Models.Task;

namespace Mission08_Team0414.Data
{
    public interface ITasksRepository
    {
        IQueryable<TaskModel> Tasks { get; }
        IQueryable<Category> Categories { get; }

        void AddTask(TaskModel task);
        void UpdateTask(TaskModel task);
        void DeleteTask(TaskModel task);

        void SaveChanges();
    }
}