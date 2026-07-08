using Application.Dtos.Requests;
using Application.Dtos.Responses;

namespace Application.Interfaces;
public interface ITaskService
{
    Task<List<TaskResponse>> GetTasksAsync();
    Task<TaskResponse> GetTaskByIdAsync(Guid id);
    Task<TaskResponse> CreateTaskAsync(CreateTaskRequest taskDTO);
    Task UpdateTaskAsync(UpdateTaskRequest taskDTO);
    Task DeleteTaskAsync(Guid id);
}
