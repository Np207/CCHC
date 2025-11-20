using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace LHS_Client;

public class JwtHelper
{
    private readonly IConfiguration _config;
    private static readonly string SecretKey = "TNCM-WEB-TOKEN-KEY-NOT-TOO-SHORT"; // Change this to a secure key
    public JwtHelper(IConfiguration config)
    {
        _config = config;
    }

    // Generate JWT Token with Encrypted ID
    public static string GenerateToken(string id)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(SecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", id) }),
            Expires = DateTime.UtcNow.AddMinutes(30), // Token expires in 30 minutes
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    // Validate and Decode JWT Token
    public static string? ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(SecretKey);

        try
        {
            var validationParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, validationParams, out _);
            var idClaim = principal.FindFirst("id");
            return idClaim?.Value;
        }
        catch
        {
            return null; // Token is invalid
        }
    }
}
