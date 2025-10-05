namespace Core.Entities;

public enum MilestoneStatus { Pending, Completed, Skipped }

public class Milestone
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public DateTime? DueDate { get; set; }
    public MilestoneStatus Status { get; set; } = MilestoneStatus.Pending;
}
