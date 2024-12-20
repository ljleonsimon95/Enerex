using MediatR;

namespace Application.Features.Students.Commands.DeleteStudent;

/// <summary>
/// Represents a command to delete a student
/// </summary>
/// <remarks>
/// Used to delete a student from the database.
/// </remarks>
public class DeleteStudentCommand : IRequest<Guid>
{
    /// <summary>
    /// Gets or sets the id of the student to be deleted
    /// </summary>
    public Guid Id { get; init; }
}