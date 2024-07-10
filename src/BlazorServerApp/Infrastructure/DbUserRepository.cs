using BlazorServerApp.Abstractions;
using BlazorServerApp.Models;

namespace BlazorServerApp.Infrastructure;

public class DbUserRepository : IUserRepository
{
    public DbUserRepository(string connectionString)
    {
        
    }

    public List<User> GetAll()
    {
        throw new NotImplementedException();
    }
}