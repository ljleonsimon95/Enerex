using Application.Features.Students.Queries.Commons;
using FluentValidation;
using MediatR;

namespace Application.Features.Students.Commands.BulkStudentEdit;

/// <summary>
/// Represents a command to bulk edit students
/// </summary>
public class BulkEditCommand : IRequest<int>
{
    /// <summary>
    /// Gets or sets the query to fetch students to be edited
    /// </summary>
    public GetAllStudentsQuery FetchQuery { get; set; }

    /// <summary>
    /// Gets or sets the query containing the new data for the students
    /// </summary>
    public GetAllStudentsBasicQuery ToEditQuery { get; set; }
}

public class BulkEditCommandValidator : AbstractValidator<BulkEditCommand>
{
    public BulkEditCommandValidator()
    {
    }
}