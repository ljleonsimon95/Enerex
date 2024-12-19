using Application.Features.Students.Helpers;
using Application.Features.Students.Queries.Commons;
using Application.Helpers;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Students.Queries.GetAllStudents;

public class GetAllFullStudentsQueryHandler(IStudentRepository studentRepository)
    : IRequestHandler<GetAllFullStudentsQuery, PagedResult<Student>>
{
    async Task<PagedResult<Student>> IRequestHandler<GetAllFullStudentsQuery, PagedResult<Student>>.Handle(
        GetAllFullStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = FilterHelpers.Filter(await studentRepository.GetAllAsync(), request).ToList();

        var paginatedStudents = students
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        return new PagedResult<Student>
        {
            Items = paginatedStudents,
            TotalCount = students.Count,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}