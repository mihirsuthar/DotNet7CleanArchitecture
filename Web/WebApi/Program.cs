using Application;
using Infrastructure;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterApplicationDependencies(builder.Configuration);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = ".Net 6 CRUD", Version = "v1" });

    // Set the comments path for the swagger JSON and UI
    var basePath = PlatformServices.Default.Application.ApplicationBasePath;
    var xmlPath = Path.Combine(basePath, "AppInfo.xml");

    option.IncludeXmlComments(xmlPath);
});

// Infrastructure - Dependency Injection
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
