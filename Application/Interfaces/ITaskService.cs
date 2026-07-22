using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Domain.Models;

namespace Application.Interfaces;
public interface ITaskService
{
    Task<PaginatedResponse<TaskModel>> GetTasksAsync(TaskFilterRequest request);
    Task<TaskResponse> GetTaskByIdAsync(Guid id);
    Task<TaskResponse> CreateTaskAsync(CreateTaskRequest taskDTO);
    Task UpdateTaskAsync(UpdateTaskRequest taskDTO);
    Task DeleteTaskAsync(Guid id);
}
