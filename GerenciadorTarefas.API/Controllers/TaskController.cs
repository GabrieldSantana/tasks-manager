using Application.Interfaces;
using Application.Interfaces.IMainService;
using Application.Services.Exceptions;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace TasksManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : MainController
{
    private readonly ITaskService _service;

    public TaskController(INotifier notifier, ITaskService service) : base(notifier)
    {
        _service = service;
    }

    /// <summary>
    /// Get all tasks
    /// </summary>
    /// <returns>Returns a list of tasks</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetTasksAsync()
    {
        try
        {
            List<TaskResponse> tasks = await _service.GetTasksAsync();
            return CustomResponse(tasks);
        }
        catch (NotFoundException ex)
        {
            NotifyError(ex.Message);
            return CustomResponse(null, 404);
        }
        catch (Exception ex)
        {
            NotifyError(ex.Message);
            return CustomResponse();
        }
    }

    /// <summary>
    /// Get a task by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Returns a task object</returns>
    [HttpGet("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetTaskByIdAsync(Guid id)
    {
        try
        {
            TaskResponse task = await _service.GetTaskByIdAsync(id);
            return CustomResponse(task);
        }
        catch (NotFoundException ex)
        {
            NotifyError(ex.Message);
            return CustomResponse(null, 404);
        }
        catch (Exception ex)
        {
            NotifyError(ex.Message);
            return CustomResponse();
        }
    }

    /// <summary>
    /// Creates a task
    /// </summary>
    /// <param name="task"></param>
    /// <returns>Returns a success message</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateTaskAsync([FromBody] CreateTaskRequest task)
    {
        try
        {
            bool result = await _service.CreateTaskAsync(task);
            return CustomResponse("Task created successfully!");
        }
        catch (NotFoundException ex)
        {
            NotifyError(ex.Message);
            return CustomResponse(null, 404);
        }
        catch (Exception ex)
        {
            NotifyError(ex.Message);
            return CustomResponse();
        }
    }

    /// <summary>
    /// Updates a task by Id
    /// </summary>
    /// <param name="task"></param>
    /// <returns>Returns a success message</returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateTaskAsync([FromBody] UpdateTaskRequest task)
    {
        try
        {
            bool result = await _service.UpdateTaskAsync(task);
            return CustomResponse("Task updated successfully");
        }
        catch (NotFoundException ex)
        {
            NotifyError(ex.Message);
            return CustomResponse(null, 404);
        }
        catch (Exception ex)
        {
            NotifyError(ex.Message);
            return CustomResponse();
        }
    }

    /// <summary>
    /// Deletes a task by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Returns a success message</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteTaskAsync(Guid id)
    {
        try
        {
            bool result = await _service.DeleteTaskAsync(id);
            return CustomResponse("Task deleted successfully!");
        }
        catch (NotFoundException ex)
        {
            NotifyError(ex.Message);
            return CustomResponse(null, 404);
        }
        catch (Exception ex)
        {
            NotifyError(ex.Message);
            return CustomResponse();
        }
    }
}
