namespace Application.Features.Students.Exceptions;

public class DuplicateStudentException(string message) : Exception(message);