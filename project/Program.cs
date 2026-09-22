namespace project
{
    internal class Program
    {
        static void Main(string[] args)
        {
       var studentUI = new UI.StudentUI();
            
            while(true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Run Student UI");
                Console.WriteLine("2. Exit");
                Console.Write("Select an option: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        studentUI.RunStudentUI();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
