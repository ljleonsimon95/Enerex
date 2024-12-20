using Application.Features.Students.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Students.Commands.DeleteStudent;

/// <summary>
/// Handler for delete student command
/// </summary>
public class DeleteStudentCommandHandler(IStudentRepository studentRepository)
    : IRequestHandler<DeleteStudentCommand, Guid>
{
    /// <summary>
    /// Handles the delete student command
    /// </summary>
    /// <param name="request">Delete student command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Id of the deleted student</returns>
    public async Task<Guid> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentRepository.GetByIdAsync(request.Id) ?? throw new NonExistingStudent("Student not found");
        await studentRepository.DeleteAsync(student.Id);
        return student.Id;
    }
}