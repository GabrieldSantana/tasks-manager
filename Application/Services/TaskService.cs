using Application.Interfaces;
using Application.Services.Exceptions;
using Domain.Dtos;
using Domain.Models;
using Infrastructure.Interfaces;
using Mapster;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;
public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;
    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> CreateTaskAsync(CreateTaskRequest taskDTO)
    {
        try
        {
            TaskModel task = taskDTO.Adapt<TaskModel>();
            task.Id = Guid.CreateVersion7();

            return await _repository.CreateTaskAsync(task);
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> DeleteTaskAsync(Guid id)
    {
        try
        {
            if (id == Guid.Empty) throw new ArgumentException("Invalid id.");

            TaskModel? existingTask = await _repository.GetTaskByIdAsync(id);

            if (existingTask == null) throw new NotFoundException("Task not found.");

            return await _repository.DeleteTaskAsync(id);
        }
        catch (Exception) { throw; }
    }

    public async Task<TaskResponse> GetTaskByIdAsync(Guid id)
    {
        try
        {
            if (id == Guid.Empty) throw new ArgumentException("Invalid id.");

            TaskModel? existingTask = await _repository.GetTaskByIdAsync(id);

            if (existingTask == null) throw new KeyNotFoundException($"Task {id} not found.");

            var response = new TaskResponse
            {
                Id = existingTask.Id,
                Name = existingTask.Name,
                Description = existingTask.Description,
                Priority = existingTask.Priority.ToString(),
                LimitDate = existingTask.LimitDate,
                Status = existingTask.Status.ToString()
            };

            return response;
        }
        catch (Exception) { throw; }
    }

    public async Task<List<TaskResponse>> GetTasksAsync()
    {
        try
        {
            List<TaskModel> tasks = await _repository.GetTasksAsync();

            if (tasks.IsNullOrEmpty()) throw new NotFoundException("No tasks were found.");

            var response = tasks.Select(task => new TaskResponse
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Priority = task.Priority.ToString(),
                LimitDate = task.LimitDate,
                Status = task.Status.ToString()
            });

            return response.ToList();
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> UpdateTaskAsync(UpdateTaskRequest taskDTO)
    {
        try
        {
            if (taskDTO.Id == Guid.Empty) throw new ArgumentException("Invalid id.");

            TaskModel task = taskDTO.Adapt<TaskModel>();

            TaskModel? existingTask = await _repository.GetTaskByIdAsync(task.Id);

            if (existingTask == null) throw new NotFoundException("Task not found.");

            return await _repository.UpdateTaskAsync(task);
        }
        catch (Exception) { throw; }
    }
}
