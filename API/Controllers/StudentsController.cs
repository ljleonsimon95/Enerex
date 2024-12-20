using Application.Features.Students.Commands.AddStudent;
using Application.Features.Students.Commands.BulkStudentEdit;
using Application.Features.Students.Commands.DeleteStudent;
using Application.Features.Students.Commands.EditStudent;
using Application.Features.Students.Exceptions;
using Application.Features.Students.Queries.GetAllStudents;
using Application.Features.Students.Queries.GetAllStudentsName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("students")]
public class StudentsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Adds a new student
    /// </summary>
    /// <param name="command">Student data to be added</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Id of the added student</returns>
    [HttpPost("add")]
    public async Task<IActionResult> AddStudent(
        [FromBody] AddStudentCommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            var studentId = await mediator.Send(command, cancellationToken);
            return Ok(studentId);
        }
        catch (DuplicateStudentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred" });
        }
    }

    /// <summary>
    /// Edits a student
    /// </summary>
    /// <param name="command">Student data to be edited</param>
    /// <param name="id">Id of the student to be edited</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Id of the edited student</returns>
    [HttpPut("edit/{id:guid}")]
    public async Task<IActionResult> EditStudent(
        [FromBody] EditStudentCommand command,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        try
        {
            var studentId = await mediator.Send(new FullEditStudentCommand()
            {
                Id = id,
                Name = command.Name,
                Age = command.Age,
                AcademicYear = command.AcademicYear,
                Education = command.Education,
                Gender = command.Gender
            }, cancellationToken);
            return Ok(studentId);
        }
        catch (DuplicateStudentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred" });
        }
    }

    /// <summary>
    /// Bulk edits multiple students
    /// </summary>
    /// <param name="command">Command containing the criteria for students to be edited and their new data</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The number of students that were successfully edited</returns>
    [HttpPut("bulk-edit")]
    public async Task<IActionResult> BulkStudentEdit(
        [FromQuery] BulkEditCommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            var count = await mediator.Send(command, cancellationToken);
            return Ok(count);
        }
        catch (DuplicateStudentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred" });
        }
    }

    /// <summary>
    /// Gets a list of all students with their full information
    /// </summary>
    /// <param name="query">Query containing the criteria for the students to be retrieved and the page number and size</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Paged list of students with their full information</returns>
    [HttpGet("all-info")]
    public async Task<IActionResult> GetAllStudents(
        [FromQuery] GetAllFullStudentsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Gets a list of all students with just their names
    /// </summary>
    /// <param name="query">Query containing the criteria for the students to be retrieved.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Paged list of students with just their names</returns>
    [HttpGet("just-names")]
    public async Task<IActionResult> GetAllStudentsNames(
        [FromQuery] GetAllStudentsNameQuery query,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Deletes a student
    /// </summary>
    /// <param name="id">Id of the student to be deleted</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Id of the deleted student</returns>
    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> DeleteStudent(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        try
        {
            var studentId = await mediator.Send(new DeleteStudentCommand()
            {
                Id = id
            }, cancellationToken);
            return Ok(studentId);
        }
        catch (NonExistingStudent ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred" });
        }
    }
}