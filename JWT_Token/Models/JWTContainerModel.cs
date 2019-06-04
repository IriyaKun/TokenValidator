using System;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace JWT_Token.Models
{
    public class JWTContainerModel : IAuthContainerModel
    {
        public int Expires { get; set; }
        public string SecretKey { get; set; } = GenerateKey();
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;

        public Claim[] Claims { get; set; }

        private static string GenerateKey()
        {
            var hmac = new HMACSHA256();
            return Convert.ToBase64String(hmac.Key);
        }
    }
}