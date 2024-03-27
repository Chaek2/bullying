using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace REYSAPITEST1.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "REYS_API";
        public const string AUDIENCE = "REYS_";
        const string KEY = "nRfzgTAOMtwaW9ezqnzNyzG5LAfBYcPDRHzSiwtkePin";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
