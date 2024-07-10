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
            new Leave { Employee = new User { Id = 1, FirstName = "Kate", LastName = "Smith"}, From = DateTime.Parse("2024-07-10"), To =  DateTime.Parse("2024-07-17"), LeaveType = LeaveType.Paid},
            new Leave { Employee = new User { Id = 2, FirstName = "Bob", LastName = "Smith"}, From = DateTime.Parse("2024-07-10"), To =  DateTime.Parse("2024-07-17"), LeaveType = LeaveType.Paid},
            new Leave { Employee = new User { Id = 3, FirstName = "John", LastName = "Smith"}, From = DateTime.Parse("2024-07-10"), To =  DateTime.Parse("2024-07-17"), LeaveType = LeaveType.Unpaid},
            new Leave { Employee = new User { Id = 4, FirstName = "Ann", LastName = "Spider"}, From = DateTime.Parse("2024-07-10"), To =  DateTime.Parse("2024-07-17"), LeaveType = LeaveType.Maternity},
            new Leave { Employee = new User { Id = 5, FirstName = "John", LastName = "Spider"}, From = DateTime.Parse("2024-07-10"), To =  DateTime.Parse("2024-07-17"), LeaveType = LeaveType.Paid},

        };
    }

    public List<Leave> GetAll()
    {
        return leaves;
    }
}
