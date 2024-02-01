using System.Security.Claims;

namespace Utilities.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetUserID(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value;

    public static int GetUserIDInt(this ClaimsPrincipal claimsPrincipal)
    {
        int userID = -1;
        int.TryParse(claimsPrincipal.GetUserID(), out userID);
        return userID;
    }

    public static string GetUsername(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirst(ClaimTypes.Name).Value;

    public static string GetEmail(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirst(ClaimTypes.Email).Value;

    public static string GetGivenName(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirst(ClaimTypes.GivenName).Value;

    public static List<string> GetRoles(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindAll(ClaimTypes.Role)?.Select(x => x.Value).ToList();

    public static void AddClaim(this ClaimsPrincipal claimsPrincipal, string key, string value)
        => ((ClaimsIdentity)claimsPrincipal.Identity).AddClaim(new Claim(key, value));

    public static Guid GetUserGuid(this ClaimsPrincipal claimsPrincipal)
    {
        string ID = claimsPrincipal.GetUserID();
        return ID.IsNullOrEmpty() ? Guid.Empty : ID.ToGuid();
    }

    public static string GetUserLoginID(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirst("UserLoginID")?.Value;

    public static Guid GetUserLoginIDGuid(this ClaimsPrincipal claimsPrincipal)
    {
        string userLoginID = claimsPrincipal.GetUserLoginID();
        return userLoginID.IsNullOrEmpty() ? Guid.Empty : userLoginID.ToGuid();
    }
}