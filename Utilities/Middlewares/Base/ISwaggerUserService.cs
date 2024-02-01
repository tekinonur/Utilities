namespace Utilities.Middlewares.Base;

public interface ISwaggerUserService
{
    Task<bool> IsAuthorized(string username, string password);
}