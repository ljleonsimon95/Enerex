using Application.Features.Students.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <summary>
/// Repository for students
/// </summary>
public class StudentRepository(ApplicationDbContext context) : IStudentRepository
{
    /// <summary>
    /// Gets all students
    /// </summary>
    /// <returns>All students</returns>
    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await Task.FromResult(context.Students);
    }

    /// <summary>
    /// Gets a student by its id
    /// </summary>
    /// <param name="id">Id of the student</param>
    /// <returns>The student if found, otherwise null</returns>
    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await Task.FromResult(context.Students.FirstOrDefault(s => s.Id == id));
    }

    /// <summary>
    /// Adds a student
    /// </summary>
    /// <param name="student">Student to add</param>
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

    /// <summary>
    /// Updates a student
    /// </summary>
    /// <param name="student">Student to update</param>
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

    /// <summary>
    /// Deletes a student
    /// </summary>
    /// <param name="id">Id of the student to delete</param>
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