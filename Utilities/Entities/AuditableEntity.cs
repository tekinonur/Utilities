namespace Utilities.Entities;

public abstract class AuditableEntity : BaseEntitiy
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}