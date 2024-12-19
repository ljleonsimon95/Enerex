using Application.Features.Students.Queries.Commons;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Students.Queries.GetAllStudentsName;

public class GetAllStudentsNameQuery : GetAllStudentsQuery, IRequest<string>
{
    public char Separator { get; set; } = ',';
};