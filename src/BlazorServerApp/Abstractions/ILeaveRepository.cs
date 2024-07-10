using BlazorServerApp.Models;

namespace BlazorServerApp.Abstractions;

public interface ILeaveRepository
{
    List<Leave> GetAll();
}
