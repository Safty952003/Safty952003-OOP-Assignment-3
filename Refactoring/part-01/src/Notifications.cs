namespace RefactoringLab;

public interface INotificationChannel
{
    void Send(string to, string message);
}

public class EmailChannel : INotificationChannel
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"[email] {to}: {message}");
    }
}

public class SmsChannel : INotificationChannel
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"[sms] {to}: {message}");
    }
}
public class PushChannel : INotificationChannel
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"[push] {to}: {message}");
    }
}

public interface INotificationBehavior
{
    string Apply(string message);
}

public class UrgentBehavior : INotificationBehavior
{
    public string Apply(string message)
    {
        return $"[URGENT] {message}";
    }
}

public class ScheduledBehavior : INotificationBehavior
{
    private readonly DateTime _sendAt;

    public ScheduledBehavior(DateTime sendAt)
    {
        _sendAt = sendAt;
    }

    public string Apply(string message)
    {
        return $"[scheduled {_sendAt:g}] {message}";
    }
}

public class Notification
{
    private readonly INotificationChannel _channel;
    private readonly List<INotificationBehavior> _behaviors;

    public Notification(
        INotificationChannel channel,
        params INotificationBehavior[] behaviors)
    {
        _channel = channel;
        _behaviors = behaviors.ToList();
    }

    public void Send(string to, string message)
    {
        foreach (var behavior in _behaviors)
        {
            message = behavior.Apply(message);
        }

        _channel.Send(to, message);
    }
}