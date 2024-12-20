namespace Application.Features.Students.Exceptions;

/// <summary>
/// Exception thrown when attempting to add a student that already exists.
/// </summary>
public class DuplicateStudentException(string message) : Exception(message);