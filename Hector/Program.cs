using Hector.Data;
using Hector.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Connect Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidDataException("No connection");


// Add services to the container.
builder.Services.AddScoped<ParticipantRepository>();
builder.Services.AddDbContext<ParticipantDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Register Swagger
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = Path.Combine(AppContext.BaseDirectory, "Hector.xml");
    c.IncludeXmlComments(xmlFile);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<RequestLoggingMiddleware>();
    app.MapGet("/", () => "Hello World!");
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Set to empty to serve UI at root (e.g., https://localhost:5001/)
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
