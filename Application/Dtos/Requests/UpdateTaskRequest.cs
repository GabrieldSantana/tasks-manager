using Domain.Enums;

namespace Application.Dtos.Requests;
public class UpdateTaskRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public PriorityEnum Priority { get; set; }
    public DateTime LimitDate { get; set; }
    public StatusEnum Status { get; set; }
}
