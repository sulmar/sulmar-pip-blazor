using BlazorServerApp.Abstractions;
using BlazorServerApp.Models;
using Microsoft.Data.SqlClient;

namespace BlazorServerApp.Infrastructure;

public class DbLeaveRepository : ILeaveRepository
{
    private readonly SqlConnection _connection;

    public DbLeaveRepository(SqlConnection connection)
    {
        _connection = connection;
    }

    public void Add(Leave leave)
    {
        string sql = "INSERT INTO dbo.Leaves(UserId, LeaveType, DateFrom, DateTo, LeaveStatus) VALUES(@UserId, @LeaveType, @DateFrom, @DateTo, @LeaveStatus); SELECT SCOPE_IDENTITY();";

        SqlCommand command = new SqlCommand(sql, _connection);
        command.Parameters.AddWithValue("@UserId", leave.Employee.Id);
        command.Parameters.AddWithValue("@LeaveType", leave.LeaveType);
        command.Parameters.AddWithValue("@DateFrom", leave.From);
        command.Parameters.AddWithValue("@DateTo", leave.To);
        command.Parameters.AddWithValue("@LeaveStatus", leave.Status);

        _connection.Open();

        object primaryKeyValue = command.ExecuteScalar();

        _connection.Close();

        if (primaryKeyValue != null)
        {
            leave.Id = Convert.ToInt32(primaryKeyValue);
        }
    }

    public Leave Get(int id)
    {
        string sql = "SELECT LeaveId, LeaveType, DateFrom, DateTo, LeaveStatus, l.UserId, FirstName, LastName FROM dbo.Leaves as l INNER JOIN dbo.Users as u on l.UserId = u.UserId Where LeaveId=@LeaveId";

        Leave leave = null;

        SqlCommand command = new SqlCommand(sql, _connection);
        command.Parameters.AddWithValue("@LeaveId", id);
        _connection.Open();

        var reader = command.ExecuteReader();

        if (reader.Read())
        {
            leave = Map(reader);
        }

        _connection.Close();

        return leave;
    }

    public List<Leave> GetAll()
    {
        string sql = "SELECT LeaveId, LeaveType, DateFrom, DateTo, LeaveStatus, l.UserId, FirstName, LastName FROM dbo.Leaves as l INNER JOIN dbo.Users as u on l.UserId = u.UserId";

        List<Leave> leaves = new List<Leave>();

        SqlCommand command = new SqlCommand(sql, _connection);
        _connection.Open();

        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var leave = Map(reader);

            leaves.Add(leave);
        }

        _connection.Close();

        return leaves;
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Leave leave)
    {
        string sql = "update dbo.Leaves set LeaveStatus = @LeaveStatus where LeaveId = @LeaveId;";

        SqlCommand command = new SqlCommand(sql, _connection);
        command.Parameters.AddWithValue("@LeaveStatus", leave.Status);
        command.Parameters.AddWithValue("@LeaveId", leave.Id);

        _connection.Open();
        object primaryKeyValue = command.ExecuteScalar();
        _connection.Close();
    }

    private Leave Map(SqlDataReader reader)
    {

        var leave = new Leave();
        leave.Id = reader.GetInt32(reader.GetOrdinal("LeaveId"));
        leave.Employee = new User();
        leave.Employee.Id = reader.GetInt32(reader.GetOrdinal("UserId"));
        leave.Employee.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
        leave.Employee.LastName = reader.GetString(reader.GetOrdinal("LastName"));
        leave.LeaveType = (LeaveType)reader.GetInt16(reader.GetOrdinal("LeaveType"));
        leave.From = reader.GetDateTime(reader.GetOrdinal("DateFrom"));
        leave.To = reader.GetDateTime(reader.GetOrdinal("DateTo"));
        leave.Status = (LeaveStatus)reader.GetInt16(reader.GetOrdinal("LeaveStatus"));

        return leave;
    }
}
