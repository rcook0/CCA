namespace Core.Entities;

public class TargetEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Type { get; set; } = "College"; // College, Employer, Grant, etc.
}
