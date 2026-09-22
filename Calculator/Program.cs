namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to the Calculator");

            var calculator = new Calculator.Class.Calculator();

            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nEnter first number:");
                    double a = Convert.ToDouble(Console.ReadLine());


                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nEnter second number:");
                    double b = Convert.ToDouble(Console.ReadLine());


                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nEnter operation (+, -, *, /):");
                    string operation = Console.ReadLine();

                    double result;
                    switch (operation)
                    {
                        case "+":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            result = calculator.Add(a, b);
                            break;

                        case "-":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            result = calculator.Subtract(a, b);
                            break;

                        case "*":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            result = calculator.Multiply(a, b);
                            break;

                        case "/":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            result = calculator.Divide(a, b);
                            break;

                            default:
                            Console.WriteLine("Invalid operation");
                            continue;

                    }
                    
                    Console.WriteLine($"Result: {result}");

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter numbers only.");
                }
                catch (DivideByZeroException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You cannot divide by zero.");
                }

               
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nDo you want to perform another calculation? (y/n)");
                
                if (Console.ReadLine()?.ToLower() != "y")
                { 
                   
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }
    }
}