namespace Application.Features.Students.Exceptions;

/// <summary>
/// Exception thrown when attempting to access a student that does not exist.
/// </summary>
public class NonExistingStudent(string message) : Exception(message);