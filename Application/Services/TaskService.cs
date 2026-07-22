using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Interfaces;
using Domain.Models;
using FluentValidation;
using Infrastructure.Interfaces;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Application.Services;
public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;
    private readonly IValidator<CreateTaskRequest> _createValidator;
    private readonly IValidator<UpdateTaskRequest> _updateValidator;
    private readonly IValidator<TaskFilterRequest> _getValidator;
    private readonly ILogger<TaskService> _logger;

    public TaskService(ITaskRepository repository, IValidator<CreateTaskRequest> createValidator, IValidator<UpdateTaskRequest> updateValidator, 
                            ILogger<TaskService> logger, IValidator<TaskFilterRequest> getValidator)
    {
        _repository = repository;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        _logger = logger;
        _getValidator = getValidator;
    }

    public async Task<TaskResponse> CreateTaskAsync(CreateTaskRequest taskRequest)
    {
        _logger.LogInformation("Creating a new task.");

        var validation = await _createValidator.ValidateAsync(taskRequest);

        if (!validation.IsValid)
        {
            _logger.LogWarning("Task validation failed.");
            throw new ValidationException(validation.Errors);
        }

        TaskModel task = taskRequest.Adapt<TaskModel>();
        task.Id = Guid.CreateVersion7();

        await _repository.CreateTaskAsync(task);

        _logger.LogInformation("Task {TaskId} created successfully", task.Id);

        return task.Adapt<TaskResponse>();
    }

    public async Task DeleteTaskAsync(Guid id)
    {
        _logger.LogInformation("Deleting task {TaskId}", id);

        if (id == Guid.Empty) throw new ArgumentException("Invalid id.");

        TaskModel? existingTask = await _repository.GetTaskByIdAsync(id);

        if (existingTask == null)
        {
            _logger.LogWarning("Task {TaskId} was not found.", id);
            throw new KeyNotFoundException("Task not found.");
        }

        await _repository.DeleteTaskAsync(id);

        _logger.LogInformation("Task {TaskId} deleted successfully", id);
    }

    public async Task<TaskResponse> GetTaskByIdAsync(Guid id)
    {
        _logger.LogInformation("Retrieving task {TaskId}.", id);

        if (id == Guid.Empty) throw new ArgumentException("Invalid id.");

        TaskModel? existingTask = await _repository.GetTaskByIdAsync(id);

        if (existingTask == null)
        {
            _logger.LogWarning("Task {TaskId} was not found.", id);
            throw new KeyNotFoundException("Task not found.");
        }

        var response = existingTask.Adapt<TaskResponse>();

        _logger.LogInformation("Task {TaskId} retrieved successfully.", id);
        return response;
    }

    public async Task<PaginatedResponse<TaskModel>> GetTasksAsync(TaskFilterRequest request)
    {
        _logger.LogInformation("Retrieving all tasks.");

        var validation = await _getValidator.ValidateAsync(request);

        if(!validation.IsValid)
        {
            _logger.LogWarning("Task filter validation failed.");
            throw new ValidationException(validation.Errors);
        }

        TaskFilterModel filter = request.Adapt<TaskFilterModel>();

        var tasks = await _repository.GetTasksAsync(filter);

        var response = tasks.Adapt<PaginatedResponse<TaskModel>>();

        _logger.LogInformation("Tasks retrieved successfully.");
        return response;
    }

    public async Task UpdateTaskAsync(UpdateTaskRequest taskRequest)
    {
        _logger.LogInformation("Updating task with id: {TaskId}.", taskRequest.Id);

        var validation = await _updateValidator.ValidateAsync(taskRequest);

        if (!validation.IsValid)
        {
            _logger.LogWarning("Task validation failed.");
            throw new ValidationException(validation.Errors);
        }

        TaskModel task = taskRequest.Adapt<TaskModel>();

        TaskModel? existingTask = await _repository.GetTaskByIdAsync(task.Id);

        if (existingTask == null)
        {
            _logger.LogWarning("Task {TaskId} was not found.", taskRequest.Id);
            throw new KeyNotFoundException("Task not found.");
        }

        await _repository.UpdateTaskAsync(task);

        _logger.LogInformation("Task {TaskId} updated successfully.", taskRequest.Id);
    }
}
