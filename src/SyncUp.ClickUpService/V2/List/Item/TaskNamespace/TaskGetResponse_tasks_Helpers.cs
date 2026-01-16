namespace SyncUp.ClickUp.Api.V2.List.Item.TaskNamespace;

public partial class TaskGetResponse_tasks
{
    public string? StatusName => Status.AsDictionary()?["status"]?.AsString();

    public string? AssignmentUsername => Assignees.AsArray().FirstOrDefault()?.AsDictionary()["username"]?.AsString();
    
    public bool InitiativeTask => Parent != null;

    public DateTime? DueDateDateTime => FromClickUpTime(DueDate);
    
    public DateTime? DateDoneDateTime => FromClickUpTime(DateDone);
    
    public DateTime? DateClosedDateTime => FromClickUpTime(DateClosed);
    
    public static DateTime FromClickUpTime(long unixMilliseconds)
    {
        // DateTimeOffset is safer than DateTime for API work as it preserves offset info
        return DateTimeOffset.FromUnixTimeMilliseconds(unixMilliseconds).LocalDateTime;
    }
    
    public static DateTime? FromClickUpTime(string? unixMillisecondsString)
    {
        if (unixMillisecondsString == null) 
            return null;
        
        if (long.TryParse(unixMillisecondsString, out long result))
        {
            return FromClickUpTime(result);
        }
        
        return null;
    }
}

public static class Statuses
{
    public const string Open = "Open";
    public const string Queued = "queued";
    public const string ReadyToStart = "ready to start";
    public const string Blocked = "blocked";
    public const string InProgress = "in progress";
    public const string Pending = "pending";
    public const string Done = "done";
    public const string Complete = "complete";
    
}
