namespace Application.Dtos.Responses;
public class TaskResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Priority { get; set; }
    public DateTime LimitDate { get; set; }
    public string Status { get; set; }
}