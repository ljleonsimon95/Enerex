using Application.Features.Students.Queries.Commons;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Students.Queries.GetSingleStudents;

public class GetSingleStudentQuery : IRequest<Student>
{
    public Guid Id { get; set; }
};