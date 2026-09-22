using Direction.Services;

namespace Direction;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Dictionary");

        var translationService = new TranslationService();

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nChoose a language (Eng-geo, Geo-eng):");
            var choice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choice))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid language.");
                continue;
            }


            var isLanguegePartSupported = translationService.IsLanguegePartSupported(choice);

            if (!isLanguegePartSupported)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Language not supported. Please choose a valid language.");
                
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the word to translate:");

            var wordToTranslate = Console.ReadLine();

            var translation = translationService.Translate(wordToTranslate, choice);

            if (translation is null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Word not found in the dictionary. Want to add it? (y/n)");
                var addWordChoice = Console.ReadLine();
                if (addWordChoice?.ToLower() == "y")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Enter the translation for the word:");
                    var newTranslation = Console.ReadLine();
                    translationService.AddTranslation(wordToTranslate, newTranslation, choice);
                    Console.WriteLine("Translation added successfully.");
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Translation: {translation}");
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("want to translate another word? (y/n)");

                var anotherWordChoice = Console.ReadLine();

                if (anotherWordChoice?.ToLower() != "y")
                {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                }

            }
        }
    }

