using Application.Features.Students.Commands.Commons;
using FluentValidation;
using MediatR;

namespace Application.Features.Students.Commands.AddStudent;

/// <summary>
/// Command to add a new student
/// </summary>
public class AddStudentCommand : StudentCommand, IRequest<Guid>
{
}

/// <summary>
/// Validator for the student command
/// </summary>
public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
{
    public AddStudentCommandValidator()
    {
        Include(new StudentCommandValidator());
    }
}