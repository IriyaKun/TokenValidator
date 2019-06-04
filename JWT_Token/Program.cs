using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JWT_Token.Managers;
using JWT_Token.Models;

namespace JWT_Token
{
    class Program
    {
        static void Main(string[] args)
        {
            IAuthContainerModel model = GetJwtContainerModel("Ilya Gomel", "ilyasrevenge@gmail.com");
            model.Expires = 8;
            IAuthService service = new JWTService(model.SecretKey);

            string token = service.GenerateToken(model);

            if (!service.IsValid(token))
            {
                throw  new UnauthorizedAccessException();
            }
            else
            {
                List<Claim> claims = service.GetTokenClaims(token).ToList();

                Console.WriteLine(claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Name))?.Value);
                Console.WriteLine(claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email))?.Value);
            }
        }

        static JWTContainerModel GetJwtContainerModel(string name, string email)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email)
                }
            };
        }
    }
}
