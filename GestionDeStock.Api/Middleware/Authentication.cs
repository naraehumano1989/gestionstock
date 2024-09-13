using FirebaseAdmin.Auth;
using GestionDeStock.Infrastructure.Persistence;

namespace GestionDeStock.Api.Middleware
{
    public class Authentication
    {
        private readonly RequestDelegate _next;
        private readonly AppDbContext _dbContext;

        public Authentication(RequestDelegate next, AppDbContext dbContext)
        {
            _next = next;
            _dbContext = dbContext;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Falta token de autorización");
                return;
            }
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("No se encontró Token.");
                return;
            }

            try
            {
              AppDbContext db = _dbContext;
                var user = db.Users.FirstOrDefault(u => u.Token == token);
                if (user == null)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Token no válido.");
                    return;
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
