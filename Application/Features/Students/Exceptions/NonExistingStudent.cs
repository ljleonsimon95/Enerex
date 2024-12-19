namespace Application.Features.Students.Exceptions;

public class NonExistingStudent : Exception
{
    public NonExistingStudent(string message) : base(message)
    {
    }
}