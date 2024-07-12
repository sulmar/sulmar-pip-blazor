using BlazorServerApp.Models;

namespace BlazorServerApp.Abstractions;

public interface IUserRepository
{
    List<User> GetAll();
    User Get(int id);
    void Add(User user);
    void Update(User user);
    void Remove(int id);
}
