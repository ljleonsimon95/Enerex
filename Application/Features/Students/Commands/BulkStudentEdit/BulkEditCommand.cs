using Application.Features.Students.Queries.Commons;
using MediatR;

namespace Application.Features.Students.Commands.BulkStudentEdit;

public class BulkEditCommand : IRequest<int>
{
    public GetAllStudentsQuery FetchQuery { get; set; }
    public GetAllStudentsBasicQuery ToEditQuery { get; set; }
}