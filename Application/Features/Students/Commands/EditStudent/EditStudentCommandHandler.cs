using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Students.Commands.EditStudent;

/// <summary>
/// Handler for processing edit student commands.
/// </summary>
public class EditStudentCommandHandler(IStudentRepository studentRepository)
    : IRequestHandler<FullEditStudentCommand, Guid>
{
    /// <summary>
    /// Handles the edit student command.
    /// </summary>
    /// <param name="request">The edit student command containing the student details to be updated.</param>
    /// <param name="cancellationToken">The cancellation token to observe for cancellation requests.</param>
    /// <returns>The id of the edited student.</returns>
    public async Task<Guid> Handle(FullEditStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new Student
        {
            Id = request.Id,
            Name = request.Name,
            Age = request.Age,
            Gender = request.Gender,
            Education = request.Education,
            AcademicYear = request.AcademicYear
        };
        await studentRepository.UpdateAsync(student);
        return student.Id;
    }
}