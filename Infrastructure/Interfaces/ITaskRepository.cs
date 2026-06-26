using Domain.Models;

namespace Infrastructure.Interfaces;
public interface ITaskRepository
{
    Task<List<TaskModel>> GetTasksAsync();
    Task<TaskModel?> GetTaskByIdAsync(Guid id);
    Task<bool> CreateTaskAsync(TaskModel task);
    Task<bool> UpdateTaskAsync(TaskModel task);
    Task<bool> DeleteTaskAsync(Guid id);
}
