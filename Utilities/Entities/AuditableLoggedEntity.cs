namespace Utilities.Entities;

public abstract class AuditableLoggedEntity : AuditableEntity
{
    public int CreatedById { get; set; }
    public string CreatedBy { get; set; }
    public int UpdatedById { get; set; }
    public string UpdatedBy { get; set; }
}