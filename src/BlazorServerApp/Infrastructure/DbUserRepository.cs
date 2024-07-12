using BlazorServerApp.Abstractions;
using BlazorServerApp.Models;
using Microsoft.Data.SqlClient;

namespace BlazorServerApp.Infrastructure;

public class DbUserRepository : IUserRepository
{
    // Microsoft.Data.SqlClient

    private readonly SqlConnection _connection;

    public DbUserRepository(SqlConnection connection)
    {
        _connection = connection;
    }

    public void Add(User user)
    {
        string sql = "INSERT INTO dbo.Users(FirstName, LastName) VALUES(@FirstName, @LastName); SELECT SCOPE_IDENTITY();";

        SqlCommand command = new SqlCommand(sql, _connection);
        command.Parameters.AddWithValue("@FirstName", user.FirstName);
        command.Parameters.AddWithValue("@LastName", user.LastName);

        _connection.Open();

        object primaryKeyValue = command.ExecuteScalar();

        _connection.Close();

        if (primaryKeyValue != null)
        {
            user.Id = Convert.ToInt32(primaryKeyValue);
        }
    }

    public User Get(int id)
    {
        string sql = "SELECT UserId, FirstName, LastName FROM dbo.Users WHERE UserId = @UserId";

        User user = null;

        SqlCommand command = new SqlCommand(sql, _connection);
        command.Parameters.AddWithValue("@UserId", id);
        _connection.Open();

        var reader = command.ExecuteReader();
        
        if (reader.Read())
        {            
            user = Map(reader);    
        }

        _connection.Close();

        return user;
    }

    private User Map(SqlDataReader reader)
    {
        var user = new User();
        user.Id = reader.GetInt32(reader.GetOrdinal("UserId"));
        user.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
        user.LastName = reader.GetString(reader.GetOrdinal("LastName"));

        return user;
    }

    public List<User> GetAll()
    {
        string sql = "SELECT UserId, FirstName, LastName FROM dbo.Users";

        List<User> users = new List<User>();

        SqlCommand command = new SqlCommand(sql, _connection);
        _connection.Open();

        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var user = Map(reader);

            users.Add(user);
        }

        _connection.Close();

        return users;
    }

    public void Remove(int id)
    {
        string sql = "DELETE dbo.Users WHERE UserId = @UserId";

        SqlCommand command = new SqlCommand(sql, _connection);
        command.Parameters.AddWithValue("@UserId", id);

        _connection.Open();

        command.ExecuteNonQuery();

        _connection.Close();
    }

    public void Update(User user)
    {
        string sql = "UPDATE dbo.Users SET FirstName = @FirstName, LastName = @LastName WHERE UserId = @UserId";

        SqlCommand command = new SqlCommand(sql, _connection);
        command.Parameters.AddWithValue("@UserId", user.Id);
        command.Parameters.AddWithValue("@FirstName", user.FirstName);
        command.Parameters.AddWithValue("@LastName", user.LastName);

        _connection.Open();

        object primaryKeyValue = command.ExecuteScalar();

        _connection.Close();
    }
}