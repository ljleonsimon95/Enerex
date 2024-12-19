using Application.Features.Students.Commands.AddStudent;
using Application.Features.Students.Queries.Commons;
using Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllStudentsQuery).Assembly));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();


// Configurar Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro de FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<AddStudentCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetAllStudentsQueryValidator>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await dbContext.SeedDataAsync();
}

// Usar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();