using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProyectoBackendCsharp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<ControlConexion>();
builder.Services.AddSingleton<TokenService>();

// Configuración de CORS para permitir solicitudes de cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo",
        builder => builder
            .AllowAnyOrigin() // Permite cualquier origen
            .AllowAnyMethod() // Permite cualquier método HTTP
            .AllowAnyHeader()); // Permite cualquier cabecera
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

// Habilitar el uso de CORS
app.UseCors("PermitirTodo");

app.UseAuthorization();

app.MapControllers();

app.Run();
