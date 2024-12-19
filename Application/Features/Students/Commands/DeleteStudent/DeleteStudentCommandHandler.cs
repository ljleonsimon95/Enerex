using Domain.Interfaces;
using MediatR;

namespace Application.Features.Students.Commands.DeleteStudent;

public class DeleteStudentCommandHandler(IStudentRepository studentRepository)
    : IRequestHandler<DeleteStudentCommand, Guid>
{
    public async Task<Guid> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetByIdAsync(request.Id) ?? throw new Exception("Student not found");
        await studentRepository.DeleteAsync(student.Id);
        return student.Id;
    }
}