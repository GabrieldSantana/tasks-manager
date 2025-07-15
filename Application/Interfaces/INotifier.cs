using Domain.Notification;

namespace Application.Interfaces.IMainService;
public interface INotifier
{
    bool HaveNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notification);
}
