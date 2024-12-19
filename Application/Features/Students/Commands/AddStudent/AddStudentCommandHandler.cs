using Application.Features.Students.Commands.AddStudent;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Students.Commands;

public class AddStudentCommandHandler(IStudentRepository studentRepository) : IRequestHandler<AddStudentCommand, Guid>
{
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