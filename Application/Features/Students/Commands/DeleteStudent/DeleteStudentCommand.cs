using MediatR;

namespace Application.Features.Students.Commands.DeleteStudent;

public class DeleteStudentCommand : IRequest<Guid>
{
    public Guid Id { get; init; }
}