namespace Utilities.Entities.Common;

public abstract class SessionLog : BaseEntity
{
    public string UserId { get; set; }
    public string Username { get; set; }
    public string IP { get; set; }
    public string UserAgent { get; set; }
    public DateTime LoginTime { get; set; }
    public DateTime? LogoutTime { get; set; }
}
