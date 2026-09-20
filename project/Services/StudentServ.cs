
using project.Models;

namespace project.Services;

public class StudentServ : GenericSer<Students>
{
    public StudentServ(string filePath) : base(filePath)
    {

    }

    public List<Students> GetStudentsByCountry(string country)
    {
        return _items.Where(s => s.Country != null && s.Country.Equals(country, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public Students? GetStudentByRollNumber(int rollNumber)
    {
        return _items.FirstOrDefault(s => s.RollNumber == rollNumber);
    }

    public List<Students> GetStudentsByLastName(string lastName)
    {
        return _items.Where(s => s.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Students> GetStudentsByFirstName(string firstName)
    {
        return _items.Where(s => s.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Students> GetStudentsByGrade(char grade)
    {
        return _items.Where(s => s.Grade == grade).ToList();
    }

    public void UpdateStudent(Students updatedStudent)
    {
        var existingStudent = GetStudentByRollNumber(updatedStudent.RollNumber);
        if (existingStudent != null)
        {
            existingStudent.FirstName = updatedStudent.FirstName;
            existingStudent.LastName = updatedStudent.LastName;
            existingStudent.Country = updatedStudent.Country;
            existingStudent.Grade = updatedStudent.Grade;
            Save();
        }
        else
        {
            throw new ArgumentException($"No student found with Roll Number: {updatedStudent.RollNumber}");
        }
    }


    public void RemoveStudentByRollNumber(int rollNumber)
    {
        var studentToRemove = GetStudentByRollNumber(rollNumber);
        if (studentToRemove != null)
        {
            Remove(studentToRemove);
        }
        else
        {
            throw new ArgumentException($"No student found with Roll Number: {rollNumber}");
        }
    }


}

