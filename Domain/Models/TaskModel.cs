using Domain.Enums;

namespace Domain.Models;
public class TaskModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public PriorityEnum Priority { get; set; }
    public DateTime LimitDate { get; set; }
    public StatusEnum Status { get; set; }
}
