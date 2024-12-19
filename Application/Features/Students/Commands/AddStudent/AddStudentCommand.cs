using FluentValidation;
using MediatR;

namespace Application.Features.Students.Commands.AddStudent;

/// <summary>
/// Command to add a new student
/// </summary>
public class AddStudentCommand : IRequest<Guid>
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
/// Validator for AddStudentCommand
/// </summary>
public abstract class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
{
    protected AddStudentCommandValidator()
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