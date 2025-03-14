using aztro_cchardos_back_group2.Domain.Enums;

namespace aztro_cchardos_back_group2.Infrastructure.Auth
{
    public static class RoutePermissions
    {
        public static Dictionary<string, string[]> RoleRoutes = new()
        {
            {
                RoleUser.Admin, new[]
                {
                    "/api/users",
                }
            },
            {
                RoleUser.User, new[]
                {
                    "/api/destinations/{destinationName}",
                }
            }
        };
    }
}