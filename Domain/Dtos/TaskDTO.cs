using Domain.Enums;

namespace Domain.Dtos;
public class TaskDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public PriorityEnum Priority { get; set; }
    public DateTime LimitDate { get; set; }
    public StatusEnum Status { get; set; }
}

public class UpdateTaskDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public PriorityEnum Priority { get; set; }
    public DateTime LimitDate { get; set; }
    public StatusEnum Status { get; set; }
}
