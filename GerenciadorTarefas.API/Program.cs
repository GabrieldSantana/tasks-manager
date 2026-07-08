using System.Data;
using Application.Validators;
using FluentValidation;
using GerenciadorTarefas.API.Config;
using Microsoft.Data.SqlClient;
using TasksManager.API.Config;
using TasksManager.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IDbConnection>(provider =>
{
    return new SqlConnection(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true; // Evita letras maiúsculas na url
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.DependencyInjections(builder.Configuration);

builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskValidator>();

builder.Services.RegisterMaps();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();


app.UseCors("AllowAngularApp");

app.UseMiddleware<ExceptionMiddleware>();
 
app.UseAuthorization();

app.MapControllers();

app.Run();
