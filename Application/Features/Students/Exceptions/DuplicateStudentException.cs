namespace Application.Features.Students.Exceptions;

public class DuplicateStudentException : Exception
{
    public DuplicateStudentException(string message) : base(message)
    {
    }
}