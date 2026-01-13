namespace SyncUp.ClickUp.Api.V2.List.Item.TaskNamespace;

public partial class TaskGetResponse_tasks
{
    public string? StatusName => Status.AsDictionary()?["status"]?.AsString();

    public bool InitiativeTask => Parent != null;
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
