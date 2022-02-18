namespace Saraha.Extensions;
public static class ClaimsPrincipleExtensions
{
    public static string GetUserNameIdentifier(this ClaimsPrincipal user)
        => user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
}