using Application.Features.Students.Commands.AddStudent;
using Application.Features.Students.Commands.Commons;
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

// Controllers, routing and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Fluent Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<StudentCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AddStudentCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetAllStudentsQueryValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetAllStudentsQueryValidator>();

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await dbContext.SeedDataAsync();
}

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Authorization
app.UseAuthorization();

// Routing
app.MapControllers();

// Start app
app.Run();