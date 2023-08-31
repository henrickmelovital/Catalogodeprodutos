using ProVarejista.CrossCutting.IoC;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adicionando o CORS
builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddInfrastructureAPI(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Varejista.API", Version = "v1" });
});

//System.Text.Json  .NET 6.0
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Permitindo os acessos ao CORS:
app.UseCors(cors => cors
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
);

app.MapControllers();

app.Run();
