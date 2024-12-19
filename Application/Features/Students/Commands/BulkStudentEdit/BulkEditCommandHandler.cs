using Application.Features.Students.Helpers;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Students.Commands.BulkStudentEdit;

public class BulkEditCommandHandler(IStudentRepository studentRepository) : IRequestHandler<BulkEditCommand, int>
{
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