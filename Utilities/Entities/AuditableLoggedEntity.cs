using System.ComponentModel;

namespace Utilities.Entities;

public abstract class AuditableLoggedEntity : AuditableEntity
{
    public int? CreatedById { get; set; }
    [DisplayName("Ekleyen")]
    public string? CreatedBy { get; set; }
    public int? UpdatedById { get; set; }
    [DisplayName("Güncelleyen")]
    public string? UpdatedBy { get; set; }
}