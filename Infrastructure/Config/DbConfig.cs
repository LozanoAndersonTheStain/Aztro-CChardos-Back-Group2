using DotNetEnv; //* Importa la librería DotNetEnv para cargar variables de entorno desde un archivo .env
using Npgsql; //* Importa la librería Npgsql para trabajar con PostgreSQL

namespace aztro_cchardos_back_group2.Infrastructure.Data.Configs
{
    public class DbConfig
    {
        public string ConnectionString { get; set; } = string.Empty; //* Propiedad para almacenar la cadena de conexión

        public DbConfig()
        {
            Env.Load(); //* Carga las variables de entorno desde el archivo .env

            string dBHost = Environment.GetEnvironmentVariable("DB_HOST") ?? ""; //* Obtiene la URL de la base de datos desde las variables de entorno
            string dBPort = Environment.GetEnvironmentVariable("DB_PORT") ?? ""; //* Obtiene el puerto de la base de datos desde las variables de entorno
            string dBUsername = Environment.GetEnvironmentVariable("DB_USERNAME") ?? ""; //*  Obtiene el nombre de usuario de la base de datos desde las variables de entorno
            string dBPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? ""; //* Obtiene la contraseña de la base de datos desde las variables de entorno
            string dBName = Environment.GetEnvironmentVariable("DB_NAME") ?? ""; //* Obtiene el nombre de la base de datos desde las variables de entorno

            //* Crea la cadena de conexión a la base de datos
            ConnectionString = $"Server={dBHost};Port={dBPort};Username={dBUsername};Password={dBPassword};Database={dBName}";
        }

        //* Método para validar la conexión a la base de datos
        public bool ValidateConnection(out string message)
        {
            try
            {
                //* Intenta abrir una conexión a la base de datos usando la cadena de conexión
                using var connection = new NpgsqlConnection(ConnectionString);
                connection.Open();
                message = "Database connection successful."; //* Mensaje de éxito si la conexión se abre correctamente
                return true;
            }
            catch (NpgsqlException ex)
            {
                message = $"Database connection failed: {ex.Message}"; //* Mensaje de error si la conexión falla
                return false;
            }
        }
    }
}