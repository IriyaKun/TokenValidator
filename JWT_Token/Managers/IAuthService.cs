using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using JWT_Token.Models;

namespace JWT_Token.Managers
{
    public interface IAuthService
    {
        string SecretKey { get; set; }

        bool IsValid(string token);
        string GenerateToken(IAuthContainerModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}