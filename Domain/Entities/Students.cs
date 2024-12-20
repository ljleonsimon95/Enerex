using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

/// <summary>
/// Student entity.
/// </summary>
public class Student
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the gender.
    /// </summary>
    public string Gender { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the age.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Gets or sets the education.
    /// </summary>
    public string Education { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the academic year.
    /// </summary>
    public int AcademicYear { get; set; }
}