using Application.Features.Students.Helpers;
using Application.Features.Students.Queries.Commons;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Students.Queries.GetAllStudentsName;

public class GetAllStudentsNameQueryHandler(IStudentRepository studentRepository)
    : IRequestHandler<GetAllStudentsNameQuery, string>
{
    public async Task<string> Handle(GetAllStudentsNameQuery request, CancellationToken cancellationToken)
    {
        var students = FilterHelpers.Filter(await studentRepository.GetAllAsync(), request).ToList();

        return string.Join(request.Separator, students.Select(s => s.Name));
    }
}