using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services.Exceptions;
using Application.Services.Global;
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

    public async Task<bool> CreateTaskAsync(TaskDTO taskDTO)
    {
        try
        {
            TaskModel task = taskDTO.Adapt<TaskModel>();

            return await _repository.CreateTaskAsync(task);
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        try
        {
            if (!UtilityService.GreaterThanZero(id)) throw new Exception("The id number cannot be less than zero.");

            TaskModel existingTask = await _repository.GetTaskByIdAsync(id);

            if (existingTask == null) throw new NotFoundException("Task not found.");

            return await _repository.DeleteTaskAsync(id);
        }
        catch (Exception) { throw; }
    }

    public async Task<TaskModel> GetTaskByIdAsync(int id)
    {
        try
        {
            if (!UtilityService.GreaterThanZero(id)) throw new Exception("The id number cannot be less than zero.");

            TaskModel existingTask = await _repository.GetTaskByIdAsync(id);

            if (existingTask == null) throw new NotFoundException("Task not found.");

            return await _repository.GetTaskByIdAsync(id);
        }
        catch (Exception) { throw; }
    }

    public async Task<List<TaskModel>> GetTasksAsync()
    {
        try
        {
            List<TaskModel> tasks = await _repository.GetTasksAsync();

            if (tasks.IsNullOrEmpty()) throw new NotFoundException("No tasks were found.");

            return tasks;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> UpdateTaskAsync(UpdateTaskDTO taskDTO)
    {
        try
        {
            TaskModel task = taskDTO.Adapt<TaskModel>();

            if (!UtilityService.GreaterThanZero(task.Id)) throw new Exception("The id number cannot be less than zero.");

            TaskModel existingTask = await _repository.GetTaskByIdAsync(task.Id);

            if (existingTask == null) throw new Exception("Task not found.");

            return await _repository.UpdateTaskAsync(task);
        }
        catch (Exception) { throw; }
    }
}
