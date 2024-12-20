using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Students.Commands.AddStudent;

/// <summary>
/// Handles the adding of a student
/// </summary>
/// <returns>The id of the added student</returns>
public class AddStudentCommandHandler(IStudentRepository studentRepository) : IRequestHandler<AddStudentCommand, Guid>
{
    /// <summary>
    /// Handles the adding of a student
    /// </summary>
    /// <param name="request">The request containing the new student's data</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete</param>
    /// <returns>The id of the added student</returns>
    public async Task<Guid> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new Student
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Age = request.Age,
            Gender = request.Gender,
            Education = request.Education,
            AcademicYear = request.AcademicYear
        };

        await studentRepository.AddAsync(student);
        return student.Id;
    }
}