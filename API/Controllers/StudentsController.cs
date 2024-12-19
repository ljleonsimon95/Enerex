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
    [HttpGet("all-info")]
    public async Task<IActionResult> GetAllStudents([FromQuery] GetAllFullStudentsQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("just-names")]
    public async Task<IActionResult> GetAllStudentsNames([FromQuery] GetAllStudentsNameQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddStudent(
        [FromBody] AddStudentCommand command)
    {
        try
        {
            var studentId = await mediator.Send(command);
            return Ok(studentId);
        }
        catch (DuplicateStudentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            // Manejo de otras excepciones no controladas
            return StatusCode(500, new { message = "An unexpected error occurred" });
        }
    }

    [HttpPut("edit/{id:guid}")]
    public async Task<IActionResult> EditStudent(
        [FromBody] EditStudentCommand command,
        [FromRoute] Guid id)
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
            });
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

    [HttpPut("bulk-edit")]
    public async Task<IActionResult> BulkStudentEdit(
        [FromQuery] BulkEditCommand command)
    {
        try
        {
            var count = await mediator.Send(command);
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

    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> DeleteStudent(
        [FromRoute] Guid id)
    {
        try
        {
            var studentId = await mediator.Send(new DeleteStudentCommand()
            {
                Id = id
            });
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