using FluentValidation;

namespace Application.Features.Students.Commands.Commons;

public class StudentCommand
{
    /// <summary>
    /// Name of the student
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Age of the students
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Gender of the student
    /// </summary>
    public string Gender { get; set; } = default!;

    /// <summary>
    /// Education of the student
    /// </summary>
    public string Education { get; set; } = default!;

    /// <summary>
    /// Academic year of the student
    /// </summary>
    public int AcademicYear { get; set; }
}

/// <summary>
/// Validator for the student command
/// </summary>
public class StudentCommandValidator : AbstractValidator<StudentCommand>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public StudentCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The name of the student is required.")
            .MaximumLength(100).WithMessage("The name cannot exceed 100 characters.");

        RuleFor(x => x.Age)
            .GreaterThan(0).WithMessage("Age must be greater than 0.")
            .LessThanOrEqualTo(150).WithMessage("Age must be realistic.");

        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("Gender is required.")
            .Must(g => g == "M" || g == "F").WithMessage("Gender must be 'M' or 'F'.");

        RuleFor(x => x.Education)
            .NotEmpty().WithMessage("Education is required.")
            .MaximumLength(200).WithMessage("Education cannot exceed 200 characters.");

        RuleFor(x => x.AcademicYear)
            .GreaterThan(0).WithMessage("Academic year must be greater than 0.")
            .LessThanOrEqualTo(10).WithMessage("Academic year must be less than or equal to 10.");
    }
}