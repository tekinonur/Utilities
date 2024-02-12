namespace Utilities.Entities.Common;

public abstract class SwaggerUser : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}