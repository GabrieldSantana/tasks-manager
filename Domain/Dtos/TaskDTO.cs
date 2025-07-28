using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Dtos;

public class TaskDTO
{
    [Required(ErrorMessage = "The task name is required.")]
    [StringLength(150, ErrorMessage = "The task name must be at most 150 characters long.")]
    public string Name { get; set; }

    [StringLength(200, ErrorMessage = "The description must be at most 200 characters long.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Priority is required.")]
    public PriorityEnum Priority { get; set; }

    public DateTime LimitDate { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    public StatusEnum Status { get; set; }
}

public class UpdateTaskDTO
{
    [Required(ErrorMessage = "Task ID is required.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "The task name is required.")]
    [StringLength(150, ErrorMessage = "The task name must be at most 150 characters long.")]
    public string Name { get; set; }

    [StringLength(200, ErrorMessage = "The description must be at most 200 characters long.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Priority is required.")]
    public PriorityEnum Priority { get; set; }

    [Required(ErrorMessage = "Limit date is required.")]
    public DateTime LimitDate { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    public StatusEnum Status { get; set; }
}
