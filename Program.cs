using System.Text;
using aztro_cchardos_back_group2.Application.Mappings;
using aztro_cchardos_back_group2.Application.Services;
using aztro_cchardos_back_group2.Data.Config;
using aztro_cchardos_back_group2.Domain.Interfaces;
using aztro_cchardos_back_group2.Infrastructure.Data;
using aztro_cchardos_back_group2.Infrastructure.Data.Configs;
using aztro_cchardos_back_group2.Infrastructure.Middlewares;
using aztro_cchardos_back_group2.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var dbConfig = new DbConfig(); //* Crea un constructor de la aplicación web con los argumentos proporcionados

if (dbConfig.ValidateConnection(out string message)) //* Valida la conexión a la base de datos
{
    Console.WriteLine(message); //* Imprime el mensaje de validación
}
else
{
    Console.WriteLine("Connection string is invalid", message); //* Imprime un mensaje de error si la conexión falla
}

//* Configuracion de JWT Authentication
var jwtConfig = new JwtConfig();

//* Valida que las variables de entorno JWT_KEY, JWT_ISSUER y JWT_AUDIENCE no estén vacías
if (string.IsNullOrEmpty(jwtConfig.Key) || string.IsNullOrEmpty(jwtConfig.Issuer) || string.IsNullOrEmpty(jwtConfig.Audience))
{
    throw new ArgumentException("JWT configuration is missing.");
}

//* Convierte la clave JWT en un arreglo de bytes
var key = Encoding.ASCII.GetBytes(jwtConfig.Key);

//* Configura la autenticación JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // * Establece el esquema de autenticación predeterminado
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // * Establece el esquema de desafío predeterminado
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters // * Configura los parámetros de validación del token
    {
        ValidateIssuer = true, // * Valida el emisor del token
        ValidateAudience = true, // * Valida el emisor y la audiencia del token
        ValidateLifetime = true, // * Valida la vigencia del token
        ValidateIssuerSigningKey = true, // * Valida la clave del emisor del token
        ValidIssuer = jwtConfig.Issuer, // * Establece el emisor válido del token
        ValidAudience = jwtConfig.Audience, // * Establece la audiencia válida del token
        IssuerSigningKey = new SymmetricSecurityKey(key) // * Establece la clave de firma del token
    };
});

//* Habilita la autorización
builder.Services.AddAuthorization();

//* Add services to the container.
builder.Services.AddControllers(); //* Agrega los controladores al contenedor de servicios

//* Registrar DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(dbConfig.ConnectionString));

//* Registrar AutoMapper
builder.Services.AddAutoMapper(typeof(UserProfile));

//* Registrar servicios
builder.Services.AddScoped<IUserService, UserService>(); //* Registra la implementación de IUserService
builder.Services.AddScoped<TokenService>(); //* Registra la implementación de TokenService
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionOptionService, QuestionOptionService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IDestinationService, DestinationService>();
builder.Services.AddScoped<ICombinationService, CombinationService>();
builder.Services.AddScoped<ITravelPlanService, TravelPlanService>();

//* Registrar repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>(); //* Registra la implementación de IUserRepository
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionOptionRepository, QuestionOptionRepository>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
builder.Services.AddScoped<ICombinationRepository, CombinationRepository>();
builder.Services.AddScoped<ITravelPlanRepository, TravelPlanRespository>();

//* Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); //* Agrega soporte para OpenAPI (Swagger) al contenedor de servicios

// * Configuración de CORS para permitir solicitudes desde el frontend en desarrollo
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.SetIsOriginAllowed(_ => true)
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
});

var app = builder.Build(); //* Construye la aplicación web

//* Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //* Si el entorno es de desarrollo
{
    app.MapOpenApi(); //* Configura OpenAPI (Swagger) para el entorno de desarrollo
}

//* Habilita CORS antes de Authentication y Authorization
app.UseCors("AllowFrontend");

app.UseMiddleware<RoleAuthorizationMiddleware>(); //* Habilita el middleware de autorización de roles

app.UseAuthentication(); //* Habilita la autenticación
app.UseAuthorization(); //* Habilita la autorización

app.MapControllers(); //* Mapea los controladores a las rutas

app.Run(); //* Ejecuta la aplicación