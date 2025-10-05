namespace Core.Entities;

public class Application
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TargetEntityId { get; set; }

    public List<Milestone> Milestones { get; set; } = new();
    public List<Decision> Decisions { get; set; } = new();
}
