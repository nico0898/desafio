using api.Application.Services;
using api.Domain.Interfaces;
using api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Servicios
builder.Services.AddControllers();

builder.Services.AddCors(); // <--- sin política nombrada

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔧 Inyección de dependencias
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskService>();

var app = builder.Build();

// 🧨 ACTIVAR CORS DE FORMA GLOBAL, FORZADO
app.Use((context, next) =>
{
    context.Response.Headers["Access-Control-Allow-Origin"] = "http://localhost:5053";
    context.Response.Headers["Access-Control-Allow-Methods"] = "GET, POST, PUT, DELETE, OPTIONS";
    context.Response.Headers["Access-Control-Allow-Headers"] = "*";

    // Manejar preflight (OPTIONS)
    if (context.Request.Method == "OPTIONS")
    {
        context.Response.StatusCode = 200;
        return Task.CompletedTask;
    }

    return next();
});

// ⚠️ Swagger (después de CORS)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // COMENTADO si estás usando HTTP

app.MapControllers();

app.Run();
