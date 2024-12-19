using System.Data;
using Application.Features.Students.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StudentRepository(ApplicationDbContext context) : IStudentRepository
{
    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await Task.FromResult(context.Students);
    }

    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await Task.FromResult(context.Students.FirstOrDefault(s => s.Id == id));
    }

    public async Task AddAsync(Student student)
    {
        var exists = await context.Students.AnyAsync(s =>
            s.Name == student.Name &&
            s.Gender == student.Gender &&
            s.Age == student.Age &&
            s.Education == student.Education &&
            s.AcademicYear == student.AcademicYear);

        if (exists)
        {
            throw new DuplicateStudentException("Student already exists");
        }

        context.Students.Add(student);
        await context.SaveChangesAsync();
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Student student)
    {
        var existingStudent = context.Students.FirstOrDefault(s => s.Id == student.Id);

        var exists = await context.Students.AnyAsync(s =>
            s.Name == student.Name &&
            s.Gender == student.Gender &&
            s.Age == student.Age &&
            s.Education == student.Education &&
            s.AcademicYear == student.AcademicYear);

        if (exists)
        {
            throw new DuplicateStudentException("Student already exists");
        }

        if (existingStudent != null)
        {
            existingStudent.Name = student.Name;
            existingStudent.Gender = student.Gender;
            existingStudent.Age = student.Age;
            existingStudent.Education = student.Education;
            existingStudent.AcademicYear = student.AcademicYear;
        }

        await context.SaveChangesAsync();
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var student = context.Students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            context.Students.Remove(student);
            await context.SaveChangesAsync();
            await Task.CompletedTask;
        }
        else throw new NonExistingStudent("Student does not exists");
    }
}