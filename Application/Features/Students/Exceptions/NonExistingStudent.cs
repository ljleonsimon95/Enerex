namespace Application.Features.Students.Exceptions;

public class NonExistingStudent(string message) : Exception(message);