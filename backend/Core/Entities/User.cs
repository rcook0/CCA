namespace Core.Entities;
public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = "";
    public string Role { get; set; } = "student";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateTime LastSynced { get; set; } = DateTime.UtcNow;
}