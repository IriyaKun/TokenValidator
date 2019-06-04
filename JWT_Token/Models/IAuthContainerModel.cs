using System.Security.Claims;

namespace JWT_Token.Models
{
    public interface IAuthContainerModel
    {
        string SecretKey { get; set; }
        string SecurityAlgorithm { get; set; }
        int Expires { get; set; }

        Claim[] Claims { get; set; }
    }
}