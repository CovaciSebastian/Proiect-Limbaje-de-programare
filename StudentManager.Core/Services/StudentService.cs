using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StudentManager.Core.Models;

namespace StudentManager.Core.Services;

public class StudentService
{
    private List<Student> _students = new();
    private readonly string _filePath;

    public StudentService(string fileName = "students.json")
    {
        // Salvăm fișierul în folderul local al aplicației
        _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        LoadData();
    }

    public IEnumerable<Student> GetAll() => _students;

    public IEnumerable<Student> Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return GetAll();

        return _students.Where(s => 
            s.FirstName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            s.LastName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            s.Group.Contains(query, StringComparison.OrdinalIgnoreCase));
    }

    public void Add(Student student)
    {
        if (student == null) throw new ArgumentNullException(nameof(student));
        _students.Add(student);
        SaveData();
    }

    public bool Remove(Guid id)
    {
        var student = _students.Find(s => s.Id == id);
        if (student != null)
        {
            _students.Remove(student);
            SaveData();
            return true;
        }
        return false;
    }

    public void Update(Student updatedStudent)
    {
        var index = _students.FindIndex(s => s.Id == updatedStudent.Id);
        if (index != -1)
        {
            _students[index] = updatedStudent;
            SaveData();
        }
    }

    public void SaveData()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(_students, options);
            File.WriteAllText(_filePath, jsonString);
        }
        catch (Exception ex)
        {
            // În context real, am loga eroarea
            Console.WriteLine($"Eroare la salvare: {ex.Message}");
        }
    }

    public void LoadData()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                string jsonString = File.ReadAllText(_filePath);
                _students = JsonSerializer.Deserialize<List<Student>>(jsonString) ?? new List<Student>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la încărcare: {ex.Message}");
            _students = new List<Student>();
        }
    }

    public void ExportToCsv(string exportPath)
    {
        var lines = new List<string> { "Nume,Prenume,Grupa,Media" };
        foreach (var s in _students)
        {
            lines.Add($"{s.LastName},{s.FirstName},{s.Group},{s.AverageGrade:F2}");
        }
        File.WriteAllLines(exportPath, lines);
    }
}
