using Domain.Common;
using Domain.Models;

namespace Infrastructure.Interfaces;
public interface ITaskRepository
{
    Task<PaginatedResult<TaskModel>> GetTasksAsync(TaskFilterModel filter);
    Task<TaskModel?> GetTaskByIdAsync(Guid id);
    Task CreateTaskAsync(TaskModel task);
    Task UpdateTaskAsync(TaskModel task);
    Task DeleteTaskAsync(Guid id);
}
