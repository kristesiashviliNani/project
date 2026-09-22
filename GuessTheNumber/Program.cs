namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int numberToGuess = random.Next(1, 101);

            int attempts = 0;

            Console.WriteLine("Welcome to the Guess the Number game!");
            Console.WriteLine("I'm thinking of a number between 1 and 100.");

            while (true)
            {
                try
                {
                    Console.WriteLine("\nEnter your guess:");
                    int userGuess = Convert.ToInt32(Console.ReadLine());

                    attempts++;

                    if (userGuess < 1 || userGuess > 100)
                    {
                        Console.WriteLine("Please enter a number from 1 to 100.");
                        continue;
                    }

                    if (userGuess < numberToGuess)
                    {
                        
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The secret number is higher.");
                    }
                    else if (userGuess > numberToGuess)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("The secret number is lower.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Congratulations! You guessed the number.");
                        Console.WriteLine($"Number of attempts: {attempts}");
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a whole number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: The number is too large.");
                }
            }

            Console.WriteLine("Game over. Thanks for playing!");
        }
    }
}
