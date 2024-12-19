using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Students.Commands.EditStudent;

public class EditStudentCommandHandler(IStudentRepository studentRepository)
    : IRequestHandler<FullEditStudentCommand, Guid>
{
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