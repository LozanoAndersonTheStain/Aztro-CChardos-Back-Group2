using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using DotNetEnv;
using aztro_cchardos_back_group2.Infrastructure.Data.Configs;

namespace aztro_cchardos_back_group2.Infrastructure.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Cargar variables de entorno
            Env.Load();

            // Crear la configuración de la base de datos
            var dbConfig = new DbConfig();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(dbConfig.ConnectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}