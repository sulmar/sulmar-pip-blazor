using BlazorServerApp.Abstractions;
using BlazorServerApp.Models;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace BlazorServerApp.Infrastructure;

public class FakeUserRepository : IUserRepository
{
    private List<User> users = new List<User>();

    public FakeUserRepository()
    {
        users.Add(new User { Id = 1, FirstName = "John", LastName = "Smith" });
        users.Add(new User { Id = 2, FirstName = "Kate", LastName = "Smith" });
        users.Add(new User { Id = 3, FirstName = "Bob", LastName = "Smith" });
        users.Add(new User { Id = 4, FirstName = "Ann", LastName = "Spider" });
        users.Add(new User { Id = 5, FirstName = "John", LastName = "Spider" });
    }

    public List<User> GetAll()
    {
        return users;
    }
}
