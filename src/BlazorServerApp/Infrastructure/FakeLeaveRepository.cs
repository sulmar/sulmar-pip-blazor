using BlazorServerApp.Abstractions;
using BlazorServerApp.Models;

namespace BlazorServerApp.Infrastructure;

public class FakeLeaveRepository : ILeaveRepository
{
    private List<Leave> leaves = new List<Leave>();

    public FakeLeaveRepository()
    {
        leaves = new List<Leave>
        {
            new Leave { Id = 1,  Employee = new User { Id = 1, FirstName = "Kate", LastName = "Smith"}, From = DateTime.Parse("2024-07-10"), To =  DateTime.Parse("2024-07-17"), LeaveType = LeaveType.Paid, Status = LeaveStatus.Awaiting },
            new Leave { Id = 2, Employee = new User { Id = 2, FirstName = "Bob", LastName = "Smith"}, From = DateTime.Parse("2024-07-10"), To =  DateTime.Parse("2024-07-17"), LeaveType = LeaveType.Paid, Status = LeaveStatus.Awaiting },
            new Leave { Id = 3, Employee = new User { Id = 3, FirstName = "John", LastName = "Smith"}, From = DateTime.Parse("2024-07-10"), To =  DateTime.Parse("2024-07-17"), LeaveType = LeaveType.Unpaid, Status = LeaveStatus.Accepted },
            new Leave { Id = 4, Employee = new User { Id = 4, FirstName = "Ann", LastName = "Spider"}, From = DateTime.Parse("2024-07-10"), To =  DateTime.Parse("2024-07-17"), LeaveType = LeaveType.Maternity, Status = LeaveStatus.Cancelled},
            new Leave { Id = 5,  Employee = new User { Id = 5, FirstName = "John", LastName = "Spider"}, From = DateTime.Parse("2024-07-10"), To =  DateTime.Parse("2024-07-17"), LeaveType = LeaveType.Paid, Status = LeaveStatus.Accepted},

        };
    }

    public Leave Get(int id)
    {
        return leaves.SingleOrDefault(p => p.Id == id);
    }

    public List<Leave> GetAll()
    {
        return leaves;
    }
}
