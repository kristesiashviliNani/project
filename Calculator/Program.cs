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
                    Console.WriteLine("\nEnter first number:");
                    double a = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("\nEnter second number:");
                    double b = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("\nEnter operation (+, -, *, /):");
                    string operation = Console.ReadLine();

                    double result;
                    switch (operation)
                    {
                        case "+":
                            result = calculator.Add(a, b);
                            break;

                        case "-":
                            result = calculator.Subtract(a, b);
                            break;

                        case "*":
                            result = calculator.Multiply(a, b);
                            break;

                        case "/":
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
                    Console.WriteLine("Please enter numbers only.");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("You cannot divide by zero.");
                }

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