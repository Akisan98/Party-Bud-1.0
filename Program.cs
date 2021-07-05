using System;
using System.Diagnostics;
using System.Threading;

namespace Party_Bud_1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                mainMenu();
            }
        }

        // Main Menu for the program
        static void mainMenu()
        {
            string projectName = "Party Bud";
            string creator = "Akisan";
            string version = "1.0.0";
            string lastModifyed = "04.07.2021";

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            // Introduction / Credits
            Console.WriteLine($"{projectName} by {creator} - " +
                $"Version {version} | Last Modifyed {lastModifyed}");

            Console.ResetColor();

            Console.WriteLine("\nPick a mode\n1. Alias\n2. Question Game\n3. Turnament Manager\n4. Quit\n");

            Console.Write("> ");
            string userInput = Console.ReadLine();

            try
            {
                int option = Int32.Parse(userInput);
                switch (option)
                {
                    case 1:
                        runAliasGame();
                        break;
                    case 2:
                        runQuestionGame();
                        break;
                    case 3:
                        runTurnamentManager();
                        break;
                    case 4:
                        System.Environment.Exit(0);
                        break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Invalid input from user is not Int, Error: {e.Message}");
            }
        }

        // Method to start Alias game
        static void runAliasGame()
        {
            Alias game = new(); // new Alias(); --> new(); 
            game.setup();
            Console.WriteLine("\nPress a Key to Continue...\n");
            Console.ReadKey(true);
            game.start();
        }

        static void runQuestionGame()
        {
            Console.WriteLine("Question Game!\n\nPress q to Quit\nPress n for Next Question!");

            Random rnd = new(); //  new Random(); -- > new();
            int num = rnd.Next(1, 1000); // Say there is 1000 Questions

            Console.WriteLine($"\nRANDOM QUESTION {num}");

            while (true)
            {
                num = rnd.Next(1, 1000);

                if (Console.KeyAvailable)
                {
                    // Check for input Right / Wrong
                    Console.WriteLine();
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.KeyChar)
                    {
                        case 'q':
                            return;

                        case 'n':
                            Console.WriteLine($"RANDOM QUESTION {num}");
                            break;
                    }
                }
            }
        }

        static void runTurnamentManager()
        {
            TurnamentManager tm = new();
            tm.setup();
            tm.start();
        }
    }
}
