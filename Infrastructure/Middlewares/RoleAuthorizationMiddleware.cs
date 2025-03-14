using System.Security.Claims;
using aztro_cchardos_back_group2.Infrastructure.Auth;

namespace aztro_cchardos_back_group2.Infrastructure.Middlewares
{
    public class RoleAuthorizationMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            //* Verifica si el usuario tiene un rol asignado
            var userRole = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            //* Obtiene la ruta solicitada
            var path = context.Request.Path.Value?.ToLower();

            //* Verifica si el rol del usuario y la ruta solicitada están en la lista de rutas permitidas
            if (!string.IsNullOrEmpty(userRole) && !string.IsNullOrEmpty(path))
            {
                //* Si el usuario no está autorizado, devuelve una respuesta 403 Forbidden
                if (!RoutePermissions.RoleRoutes.TryGetValue(userRole, out var allowedRoutes) ||
                    !allowedRoutes.Any(route => path.StartsWith(route)))
                {
                    //* Devuelve un código de estado 403 Forbidden 
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;

                    //* Devuelve un mensaje de error
                    await context.Response.WriteAsJsonAsync(new { message = "Access denied" });
                    return;
                }
            }
            //* Si el usuario está autorizado, continúa con la solicitud
            await _next(context);
        }
    }
}