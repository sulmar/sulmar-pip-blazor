namespace BlazorServerApp.Models;

public class Leave : BaseEntity
{
    public User Employee { get; set; }
    public LeaveType LeaveType { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public LeaveStatus Status { get; set; }
}

public enum LeaveStatus
{
    Awaiting,
    Accepted,
    Cancelled
}
