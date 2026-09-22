
namespace project.Models;

public class Students 
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Country { get; set; }
    public required int RollNumber { get; set; }
    public required char Grade { get; set; }

}
