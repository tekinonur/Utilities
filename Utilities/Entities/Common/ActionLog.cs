namespace Utilities.Entities.Common;

public abstract class ActionLog : BaseEntity
{
    public string UserId { get; set; }
    public string Username { get; set; }
    public string ActionName { get; set; }
    public string? ActionDescription { get; set; }
    public DateTime ActionTime { get; set; }
}
