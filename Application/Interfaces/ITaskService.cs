using Domain.Dtos;
using Domain.Models;

namespace Application.Interfaces;
public interface ITaskService
{
    Task<List<TaskResponse>> GetTasksAsync();
    Task<TaskResponse> GetTaskByIdAsync(Guid id);
    Task<bool> CreateTaskAsync(CreateTaskRequest taskDTO);
    Task<bool> UpdateTaskAsync(UpdateTaskRequest taskDTO);
    Task<bool> DeleteTaskAsync(Guid id);
}
