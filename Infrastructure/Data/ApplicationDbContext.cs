using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }

    public async Task SeedDataAsync()
    {
        if (!Students.Any())
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "Files", "students.txt");

            if (File.Exists(filePath))
            {
                var lines = await File.ReadAllLinesAsync(filePath);
                var students = lines
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line =>
                    {
                        var parts = line.Split(',');

                        return new Student
                        {
                            Id = Guid.NewGuid(),
                            Name = parts[0],
                            Gender = parts[1],
                            Age = int.Parse(parts[2]),
                            Education = parts[3],
                            AcademicYear = int.Parse(parts[4])
                        };
                    })
                    .ToList();

                Students.AddRange(students);
                await SaveChangesAsync();
            }
        }
    }
}