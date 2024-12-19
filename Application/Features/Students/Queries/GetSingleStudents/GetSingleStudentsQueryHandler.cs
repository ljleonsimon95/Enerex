using Application.Features.Students.Queries.Commons;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Students.Queries.GetSingleStudents;

public class GetSingleStudentsQueryHandler(IStudentRepository studentRepository)
    : IRequestHandler<GetSingleStudentQuery, Student>
{
    public async Task<Student> Handle(GetSingleStudentQuery request, CancellationToken cancellationToken)
    {
        return await studentRepository.GetByIdAsync(request.Id) ?? throw new Exception("Student not found");
    }
}