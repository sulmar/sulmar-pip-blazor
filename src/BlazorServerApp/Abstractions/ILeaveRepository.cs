using BlazorServerApp.Models;

namespace BlazorServerApp.Abstractions;

public interface ILeaveRepository
{
    List<Leave> GetAll();
    Leave Get(int id);
    void Add(Leave leave);
    void Remove(int id);
    void Update(Leave leave);
}
