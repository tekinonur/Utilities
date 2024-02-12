namespace Utilities.Entities.Common;

public abstract class Feedback : AuditableLoggedEntity
{
    public string Message { get; set; }
    public string Email { get; set; }
}
