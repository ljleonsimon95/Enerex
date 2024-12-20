using Application.Features.Students.Commands.Commons;
using FluentValidation;
using MediatR;

namespace Application.Features.Students.Commands.EditStudent;

/// <summary>
/// Command to Edit a new student
/// </summary>
public class EditStudentCommand : StudentCommand
{
}

public class FullEditStudentCommand : EditStudentCommand, IRequest<Guid>
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; init; }
}