namespace Core.Entities;

public enum DecisionType { Admit, Deny, Waitlist, Offer, Custom }

public class Decision
{
    public Guid Id { get; set; }
    public Guid ApplicationId { get; set; }
    public DecisionType Type { get; set; }
    public string Notes { get; set; } = "";
}
