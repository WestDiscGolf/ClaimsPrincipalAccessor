using System.Security.Claims;

namespace Api
{
    public interface IClaimsPrincipalAccessor
    {
        ClaimsPrincipal? Principal { get; set; }
    }
}