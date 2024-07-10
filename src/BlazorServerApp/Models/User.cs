namespace BlazorServerApp.Models;

public abstract class Base
{
}

public abstract class BaseEntity
{
    public int Id { get; set; }
}

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
