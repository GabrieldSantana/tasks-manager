using Domain.Dtos;
using Domain.Models;

namespace Application.Interfaces;
public interface ITaskService
{
    Task<List<TaskModel>> GetTasksAsync();
    Task<TaskModel> GetTaskByIdAsync(int id);
    Task<bool> CreateTaskAsync(TaskDTO taskDTO);
    Task<bool> UpdateTaskAsync(UpdateTaskDTO taskDTO);
    Task<bool> DeleteTaskAsync(int id);
}
