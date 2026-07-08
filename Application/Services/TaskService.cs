using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Interfaces;
using Domain.Models;
using FluentValidation;
using Infrastructure.Interfaces;
using Mapster;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;
public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;
    private readonly IValidator<CreateTaskRequest> _createValidator;
    private readonly IValidator<UpdateTaskRequest> _updateValidator;
    public TaskService(ITaskRepository repository, IValidator<CreateTaskRequest> createValidator, IValidator<UpdateTaskRequest> updateValidator)
    {
        _repository = repository;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<TaskResponse> CreateTaskAsync(CreateTaskRequest taskRequest)
    {
        var validation = await _createValidator.ValidateAsync(taskRequest);

        if (!validation.IsValid) throw new ValidationException(validation.Errors);

        TaskModel task = taskRequest.Adapt<TaskModel>();
        task.Id = Guid.CreateVersion7();

        await _repository.CreateTaskAsync(task);

        return task.Adapt<TaskResponse>();
    }

    public async Task DeleteTaskAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Invalid id.");

        TaskModel? existingTask = await _repository.GetTaskByIdAsync(id);

        if (existingTask == null) throw new KeyNotFoundException("Task not found.");

        await _repository.DeleteTaskAsync(id);
    }

    public async Task<TaskResponse> GetTaskByIdAsync(Guid id)
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

    public async Task<List<TaskResponse>> GetTasksAsync()
    {
        List<TaskModel> tasks = await _repository.GetTasksAsync();

        if (tasks.IsNullOrEmpty()) throw new KeyNotFoundException("No tasks were found.");

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

    public async Task UpdateTaskAsync(UpdateTaskRequest taskRequest)
    {
        var validation = await _updateValidator.ValidateAsync(taskRequest);

        if (taskRequest.Id == Guid.Empty) throw new ArgumentException("Invalid id.");

        TaskModel task = taskRequest.Adapt<TaskModel>();

        TaskModel? existingTask = await _repository.GetTaskByIdAsync(task.Id);

        if (existingTask == null) throw new KeyNotFoundException("Task not found.");

        await _repository.UpdateTaskAsync(task);
    }
}
