using MvcMovie.Data.Security;

public class AutorizationMiddleware
{
    private readonly RequestDelegate _next;

    public AutorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var authService = context.RequestServices.GetRequiredService<IAuthService>();
        var route = context.Request.Path;
        var token = context.Request.Cookies["JwtToken"];

        if (route.Value.Equals("/users/login", StringComparison.OrdinalIgnoreCase))
        {
            await _next(context);
            return;
        }
        if (route.Value.Equals("/", StringComparison.OrdinalIgnoreCase))
        {
            await _next(context);
            return;
        }

         if (string.IsNullOrEmpty(token) || !authService.ValidateToken(token))
        { 
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }
        else
        {
            if (route.Value.Equals("/studio", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }
            else if (route.Value.Equals("/movie", StringComparison.OrdinalIgnoreCase))
            {
                 await _next(context);
                 return;
            }
            else if (route.Value.Equals("/artist", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }
            else {

                string role = authService.GetRoleFromToken(token);
                if (role == "Admin")
                {
                    await _next(context);
                    return;
                }
                else
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized");
                    return;
                }
                
            }
        } 

    }
}