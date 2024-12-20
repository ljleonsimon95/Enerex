using Application.Features.Students.Helpers;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Students.Commands.BulkStudentEdit;

/// <summary>
/// Handler for processing bulk student edit commands.
/// </summary>
public class BulkEditCommandHandler(IStudentRepository studentRepository) : IRequestHandler<BulkEditCommand, int>
{
    /// <summary>
    /// Handles the bulk edit command by updating student details.
    /// </summary>
    /// <param name="request">The bulk edit command containing the criteria for updates.</param>
    /// <param name="cancellationToken">The cancellation token to observe for cancellation requests.</param>
    /// <returns>The number of students that were edited.</returns>
    public async Task<int> Handle(BulkEditCommand request, CancellationToken cancellationToken)
    {
        var toBeEditedStudents =
            FilterHelpers.Filter(await studentRepository.GetAllAsync(), request.FetchQuery).ToList();

        foreach (var student in toBeEditedStudents)
        {
            var newStudent = student;

            if (request.ToEditQuery.AcademicYear != null)
            {
                newStudent.AcademicYear = (int)request.ToEditQuery.AcademicYear;
            }

            if (request.ToEditQuery.Education != null)
            {
                newStudent.Education = request.ToEditQuery.Education;
            }

            if (request.ToEditQuery.Age != null)
            {
                newStudent.Age = (int)request.ToEditQuery.Age;
            }

            await studentRepository.UpdateAsync(newStudent);
        }

        return toBeEditedStudents.Count;
    }
}