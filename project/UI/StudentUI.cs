using project.cunsts;
using project.Models;
using project.Services;
namespace project.UI;
internal class StudentUI 
{
    
    private readonly StudentServ _studentService;
    public StudentUI() 
    {
        _studentService = new StudentServ(filePaths.StudentsFilePath);
    }

    public void RunStudentUI()
    {
        while (true)
        {
            Console.WriteLine("\n~~~~~ Student Management System ~~~~~ ");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Search Student by Roll Number");
            Console.WriteLine("4. Update Student Grade");
            Console.WriteLine("5. Remove Student");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    AddStudent();
                    break;


                case "2":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ViewAllStudents();
                    break;

                case "3":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    SearchStudent();
                    break;

                case "4":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    UpdateStudent();
                    break;
                case "5":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    RemoveStudent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            if (input == "6")
            {
                Console.Clear();
            }

        }
    }
        private void AddStudent()
    {


        Console.WriteLine("\n~~~~~  Add Student ~~~~~ "); 

        Console.Write("Enter student First Name: "); 
        var firstName = Console.ReadLine();


        while (string.IsNullOrWhiteSpace(firstName))
        { 
            Console.Write("First Name cannot be empty. Enter again: "); 
            firstName = Console.ReadLine(); 
        }

        Console.Write("Enter student Last Name: ");
        var lastName = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(lastName))
        { 
            Console.Write("Last Name cannot be empty. Enter again: "); 
            lastName = Console.ReadLine(); 
        } 

        Console.Write("Enter student Roll Number: ");
        int rollNumber;

        while (!int.TryParse(Console.ReadLine(), out rollNumber) || rollNumber <= 0)
        {
            Console.Write("Please enter a valid positive number: ");
        } 

        var existingStudent = _studentService.GetStudentByRollNumber(rollNumber); 
         
        if (existingStudent != null) 
        {
            Console.WriteLine("A student with this Roll Number already exists.");
            return; 
        }

        Console.Write("Enter student Country: ");
        var country = Console.ReadLine();

        Console.Write("Enter student Grade (A-F): ");
        char grade;

        while (true) 
        { 
            var gradeInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(gradeInput) && gradeInput.Length == 1 && char.ToUpper(gradeInput[0]) >= 'A' && char.ToUpper(gradeInput[0]) <= 'F') 
            { 
                grade = char.ToUpper(gradeInput[0]);
                break; 
            }

            Console.Write("Please enter a valid grade (A-F): "); 
        } 

        var student = new Students
        { 
            FirstName = firstName, LastName = lastName, Country = country, RollNumber = rollNumber, Grade = grade 
        }; 

        _studentService.Add(student);

        Console.WriteLine("Student added successfully!");
    } 


    private void ViewAllStudents()
    { 
        Console.WriteLine("\n~~~~~  All Students ~~~~~ "); 
        var students = _studentService.GetAll();

        if (students.Count == 0) 
        {
            Console.WriteLine("There are no students.");
            return;
        } 
        foreach (var student in students) 
        { 
            Console.WriteLine($"First Name: {student.FirstName}, " + $"Last Name: {student.LastName}, " + $"Roll Number: {student.RollNumber}, " + $"Country: {student.Country}, " + $"Grade: {student.Grade}");
        } 
    }

    private void SearchStudent()
    { 
        Console.WriteLine("\n~~~~~  Search Student ~~~~~ ");
        Console.Write("Enter Roll Number: ");

        if (!int.TryParse(Console.ReadLine(), out int rollNumber)) 
        { 
            Console.WriteLine("Invalid Roll Number."); 
            return;
        } 
        
        var student = _studentService.GetStudentByRollNumber(rollNumber);
        
        if (student == null) 
        { 
            Console.WriteLine("Student not found."); 
            return;
        }
        Console.WriteLine("\nStudent found:"); 
        Console.WriteLine($"First Name: {student.FirstName}"); 
        Console.WriteLine($"Last Name: {student.LastName}"); 
        Console.WriteLine($"Roll Number: {student.RollNumber}");
        Console.WriteLine($"Country: {student.Country}");
        Console.WriteLine($"Grade: {student.Grade}"); 
    } 

    private void UpdateStudent() 
    { 
        Console.WriteLine("\n~~~~~  Update Student Grade ~~~~~ "); 
        Console.Write("Enter Roll Number: ");
        if (!int.TryParse(Console.ReadLine(), out int rollNumber))
        {
            Console.WriteLine("Invalid Roll Number."); 
    
            return;
        } 
        var student = _studentService.GetStudentByRollNumber(rollNumber);
        if (student == null) 
        {
            Console.WriteLine("Student not found.");
            return; 
        }

        Console.Write($"Current Grade: {student.Grade}");
        Console.Write("\nEnter new Grade (A-F): ");

        char newGrade;

        while (true) 
        { 
            var input = Console.ReadLine(); 
            if (!string.IsNullOrWhiteSpace(input) && input.Length == 1 && char.ToUpper(input[0]) >= 'A' && char.ToUpper(input[0]) <= 'F') 
            { 
                newGrade = char.ToUpper(input[0]);
                break; 
            } 
            Console.Write("Please enter a valid grade (A-F): ");
        } 
        
        var updatedStudent = new Students { FirstName = student.FirstName, LastName = student.LastName, Country = student.Country, RollNumber = student.RollNumber, Grade = newGrade };
        _studentService.UpdateStudent(updatedStudent);
        Console.WriteLine("Student grade updated successfully!"); 
    }
    
    private void RemoveStudent() 
    {
        Console.WriteLine("\n~~~~~  Remove Student ~~~~~ ");

        Console.Write("Enter Roll Number: ");

        if (!int.TryParse(Console.ReadLine(), out int rollNumber))
        {
            Console.WriteLine("Invalid Roll Number."); 
            return;
        } 
        
        var student = _studentService.GetStudentByRollNumber(rollNumber); 
        if (student == null) 
        {
            Console.WriteLine("Student not found.");
            return;
        } 
        
        _studentService.RemoveStudentByRollNumber(rollNumber); 
        Console.WriteLine("Student removed successfully!");
    } 
}