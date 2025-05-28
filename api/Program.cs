using api.Domain.Interfaces;
using api.Infrastructure.Repositories;
using api.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// 👉 Registrar servicios y dependencias
builder.Services.AddControllers(); //Habilita los controladores
builder.Services.AddEndpointsApiExplorer(); //swagger
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

// 👉 Inyección de dependencias
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskService>();

var app = builder.Build();

// 👉 Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 👉 Mapear los controladores
app.MapControllers();
    
app.Run();
