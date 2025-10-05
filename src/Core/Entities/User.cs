namespace Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = "";
    public string Role { get; set; } = "Student"; // Student, Counselor, Admin
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
}
