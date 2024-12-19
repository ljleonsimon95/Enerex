using Domain.Entities;

namespace Domain.Interfaces;

/// <summary>
/// Defines a contract for a student repository.
/// </summary>
public interface IStudentRepository
{
    /// <summary>
    /// Gets all students asynchronously.
    /// </summary>
    /// <returns>A list of students.</returns>
    Task<IEnumerable<Student>> GetAllAsync();

    /// <summary>
    /// Gets a student by identifier asynchronously.
    /// </summary>
    /// <param name="id">The student identifier.</param>
    /// <returns>The student if found; otherwise, null.</returns>
    Task<Student?> GetByIdAsync(Guid id);

    /// <summary>
    /// Adds a student asynchronously.
    /// </summary>
    /// <param name="student">The student to add.</param>
    Task AddAsync(Student student);

    /// <summary>
    /// Updates a student asynchronously.
    /// </summary>
    /// <param name="student">The student to update.</param>
    Task UpdateAsync(Student student);

    /// <summary>
    /// Deletes a student by identifier asynchronously.
    /// </summary>
    /// <param name="id">The student identifier.</param>
    Task DeleteAsync(Guid id);
    
}