namespace Domain.Notification;

public class Notification
{
    public string Message { get; }

    public Notification(string messsage)
    {
        Message = messsage;
    }
}