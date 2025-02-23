using Application.Interfaces;
using Application.Services;
using Infrastructure.ExternalServices;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregar controladores
builder.Services.AddControllers();

// Configurar Swagger para la documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Abastecimiento ACME", Version = "v1" });
});

// Registrar servicios en el contenedor de dependencias
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddHttpClient<IEnvioPedidoClient, EnvioPedidoClient>();

var app = builder.Build();

// Configurar el pipeline de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
