using Domain.Models;

namespace Infrastructure.Interfaces;
public interface ITaskRepository
{
    Task<List<TaskModel>> GetTasksAsync();
    Task<TaskModel?> GetTaskByIdAsync(Guid id);
    Task CreateTaskAsync(TaskModel task);
    Task UpdateTaskAsync(TaskModel task);
    Task DeleteTaskAsync(Guid id);
}
