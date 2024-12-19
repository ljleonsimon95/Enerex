using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

/// <summary>
/// Student entity.
/// </summary>
public class Student : IEquatable<Student>
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

    public bool Equals(Student? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Name == other.Name &&
               Gender == other.Gender &&
               Age == other.Age &&
               Education == other.Education &&
               AcademicYear == other.AcademicYear;
    }
}