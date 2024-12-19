using FluentValidation;

namespace Application.Features.Students.Queries.Commons;

public class GetAllStudentsBasicQuery
{
    public string? Gender { get; set; }
    public int? Age { get; set; }
    public string? Education { get; set; }
    public int? AcademicYear { get; set; }
}

public class GetAllStudentsQuery : GetAllStudentsBasicQuery
{
    public string? NameSearchKey { get; set; }
}

public abstract class GetAllStudentsQueryValidator : AbstractValidator<GetAllStudentsBasicQuery>
{
    protected GetAllStudentsQueryValidator()
    {
        RuleFor(x => x.Age)
            .GreaterThan(0).WithMessage("Age must be greater than 0.")
            .LessThanOrEqualTo(150).WithMessage("Age must be realistic.");

        RuleFor(x => x.Gender)
            .Must(g => g == "M" || g == "F" || string.IsNullOrEmpty(g)).WithMessage("Gender must be 'M' or 'F'.");

        RuleFor(x => x.AcademicYear)
            .GreaterThan(0).WithMessage("Academic year must be greater than 0.")
            .LessThanOrEqualTo(10).WithMessage("Academic year must be less than or equal to 10.");
    }
}