namespace Core.Entities;

public class Assessment
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Result { get; set; } = "";
    public DateTime DateTaken { get; set; } = DateTime.UtcNow;
}
