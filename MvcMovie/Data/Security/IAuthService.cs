namespace MvcMovie.Data.Security;
public interface IAuthService
{
   string GenerateJwtToken(string email, string role); 
   string ComputeSha256Hash(string pass);
    bool ValidateToken(string token);
    string GetRoleFromToken(string token);
}