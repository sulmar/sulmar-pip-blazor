namespace BlazorServerApp.Models;

public class Leave : BaseEntity
{
    public User Employee { get; set; }
    public LeaveType LeaveType { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public LeaveStatus Status { get; set; }

    public void Cancel()
    {
        Status = LeaveStatus.Cancelled;
    }

    public bool CanCancel()
    {
        return Status == LeaveStatus.Awaiting || Status == LeaveStatus.Accepted;
    }

    public void Accept()
    {
        Status = LeaveStatus.Accepted;
    }

    public bool CanAccept()
    {
        return Status == LeaveStatus.Awaiting || Status == LeaveStatus.Cancelled;
    }
}

public enum LeaveStatus
{
    Awaiting,
    Accepted,
    Cancelled
}
