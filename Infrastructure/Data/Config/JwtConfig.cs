using DotNetEnv;

namespace aztro_cchardos_back_group2.Data.Config
{
    public class JwtConfig
    {
        public string Key { get; private set; }
        public string Issuer { get; private set; }
        public string Audience { get; private set; }
        public int ExpirationHours { get; private set; }

        public JwtConfig()
        {
            Env.Load(); //* Carrega las variables de entorno desde el archivo .env

            Key = Environment.GetEnvironmentVariable("JWT_KEY") ?? ""; //* Obtiene el valor de la variable de entorno JWT_KEY
            Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? ""; //* Obtiene el valor de la variable de entorno JWT_ISSUER
            Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? ""; //* Obtiene el valor de la variable de entorno JWT_AUDIENCE
            ExpirationHours = int.Parse(Environment.GetEnvironmentVariable("JWT_EXPIRATION_HOURS") ?? "24"); //* Obtiene el valor de la variable de entorno JWT_EXPIRATION_HOURS
        }
    }
}