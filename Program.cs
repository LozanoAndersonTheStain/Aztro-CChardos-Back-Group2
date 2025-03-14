using aztro_cchardos_back_group2.Infrastructure.Data.Configs; //* Importa el espacio de nombres que contiene DbConfig

var builder = WebApplication.CreateBuilder(args);

var dbConfig = new DbConfig(); //* Crea un constructor de la aplicación web con los argumentos proporcionados

if (dbConfig.ValidateConnection(out string message)) //* Valida la conexión a la base de datos
{
    Console.WriteLine(message); //* Imprime el mensaje de validación
} else {
    Console.WriteLine("Connection string is invalid", message); //* Imprime un mensaje de error si la conexión falla
}

// Add services to the container.
builder.Services.AddControllers(); // Agrega los controladores al contenedor de servicios
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // Agrega soporte para OpenAPI (Swagger) al contenedor de servicios

var app = builder.Build(); // Construye la aplicación web

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Si el entorno es de desarrollo
{
    app.MapOpenApi(); // Configura OpenAPI (Swagger) para el entorno de desarrollo
}

// Comment out or remove the following line to disable HTTPS redirection
// app.UseHttpsRedirection(); // Redirige las solicitudes HTTP a HTTPS

app.UseAuthorization(); // Habilita la autorización

app.MapControllers(); // Mapea los controladores a las rutas

app.Run(); // Ejecuta la aplicación
