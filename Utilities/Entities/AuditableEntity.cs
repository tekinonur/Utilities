using System.ComponentModel;

namespace Utilities.Entities;

public abstract class AuditableEntity : BaseEntity
{
    [DisplayName("Oluşturulma Tarihi")]
    public DateTime CreatedAt { get; set; }
    [DisplayName("Güncellenme Tarihi")]
    public DateTime UpdatedAt { get; set; }
}