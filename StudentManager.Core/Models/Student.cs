using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManager.Core.Models;

public class Student
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string Email { get; set; } = string.Empty;
    public List<double> Grades { get; set; } = new List<double>();

    // Proprietate calculată pentru medie
    public double AverageGrade => Grades.Count > 0 ? Grades.Average() : 0;

    public string FullName => $"{FirstName} {LastName}";

    public override string ToString()
    {
        return $"{FullName} ({Group}) - Media: {AverageGrade:F2}";
    }
}
