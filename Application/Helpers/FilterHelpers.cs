using Application.Features.Students.Queries.Commons;
using Domain.Entities;

namespace Application.Features.Students.Helpers;

public static class FilterHelpers
{
    public static IEnumerable<Student> Filter(IEnumerable<Student> students, GetAllStudentsQuery request)
    {
        if (!string.IsNullOrEmpty(request.NameSearchKey))
            students = students.Where(s => s.Name.Contains(request.NameSearchKey, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrEmpty(request.Gender))
            students = students.Where(s => s.Gender.Equals(request.Gender, StringComparison.OrdinalIgnoreCase));

        if (request.Age.HasValue)
            students = students.Where(s => s.Age == request.Age.Value);

        if (!string.IsNullOrEmpty(request.Education))
            students = students.Where(s => s.Education.Contains(request.Education, StringComparison.OrdinalIgnoreCase));

        if (request.AcademicYear.HasValue)
            students = students.Where(s => s.AcademicYear == request.AcademicYear.Value);

        return students.OrderBy(s => s.Name);
    }
}