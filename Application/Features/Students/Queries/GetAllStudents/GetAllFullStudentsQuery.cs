using Application.Features.Students.Queries.Commons;
using Application.Helpers;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Students.Queries.GetAllStudents;

public class GetAllFullStudentsQuery : GetAllStudentsQuery, IRequest<PagedResult<Student>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
};