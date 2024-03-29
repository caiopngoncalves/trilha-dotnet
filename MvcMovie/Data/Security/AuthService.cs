using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MvcMovie.Data.Security;
public class AuthService : IAuthService
{
   private readonly IConfiguration _configuration;

   public AuthService(IConfiguration configuration)
   {
      _configuration = configuration;
   }

    public string ComputeSha256Hash(string pass)
    {
         using (var sha256 = SHA256.Create())
         {
               var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
               var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
               return hash;
         }
    }

    public string GenerateJwtToken(string email, string role)
   {
      var issuer = _configuration["Jwt:Issuer"];
      var audience = _configuration["Jwt:Audience"];
      var key = _configuration["Jwt:Key"];
      //cria uma chave utilizando criptografia simétrica
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
      //cria as credenciais do token
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
      
      var claims = new[]
      {
         new Claim("userName", email),
         new Claim(ClaimTypes.Role, role)
      };

      var token = new JwtSecurityToken( //cria o token
         issuer: issuer, //emissor do token
         audience: audience, //destinatário do token
         claims: claims, //informações do usuário
         expires: DateTime.Now.AddMinutes(30), //tempo de expiração do token
         signingCredentials: credentials); //credenciais do token
      

      var tokenHandler = new JwtSecurityTokenHandler(); //cria um manipulador de token

      var stringToken = tokenHandler.WriteToken(token);

      return stringToken;
   }
    public bool ValidateToken(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            return false;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = _configuration["Jwt:Audience"]
            }, out SecurityToken validatedToken);

            return true;
        }
        catch
        {
            // Token validation failed
            return false;
        }
        
    }
    public string GetRoleFromToken(string token)
    {
        var key = _configuration["Jwt:Key"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = securityKey,
            ValidateIssuer = false,
            ValidateAudience = false
        };

        var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
        var roleClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

        return roleClaim?.Value;
    }
}