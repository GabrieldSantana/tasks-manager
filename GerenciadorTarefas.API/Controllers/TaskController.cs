using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TasksManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _service;

    public TaskController(ITaskService service)
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
    public async Task<IActionResult> GetTasksAsync([FromQuery] TaskFilterRequest request)
    {
        var tasks = await _service.GetTasksAsync(request);
        return Ok(tasks);
    }

    /// <summary>
    /// Get a task by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Returns a task object</returns>
    [HttpGet("{id:guid}", Name = nameof(GetTaskByIdAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetTaskByIdAsync(Guid id)
    {
        TaskResponse task = await _service.GetTaskByIdAsync(id);
        return Ok(task);
    }

    /// <summary>
    /// Creates a task
    /// </summary>
    /// <param name="task"></param>
    /// <returns>Returns a success message</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateTaskAsync([FromBody] CreateTaskRequest request)
    {
        var task = await _service.CreateTaskAsync(request);

        return CreatedAtRoute(
            nameof(GetTaskByIdAsync),
            new { id = task.Id },
            task);

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
        await _service.UpdateTaskAsync(task);
        return NoContent();
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
        await _service.DeleteTaskAsync(id);
        return NoContent();
    }
}
