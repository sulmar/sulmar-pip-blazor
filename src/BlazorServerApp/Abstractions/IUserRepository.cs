using BlazorServerApp.Models;

namespace BlazorServerApp.Abstractions;

public interface IUserRepository
{
    List<User> GetAll();
}
