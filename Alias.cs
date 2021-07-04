using System;
using System.Diagnostics;

namespace Party_Bud_1._0
{
    class Alias
    {
        // Global Ref to Stopwatch
        Stopwatch stopWatch = new Stopwatch();
        int timeLimit = 90; // Hardcoded for now

        // Method for setting up the Game
        public void setup()
        {
            Console.WriteLine("Starting Alias!");
            Console.WriteLine("Round Rule is .......");
        }

        // Method for generating random rule in game
        void randomRule()
        {
            Random rnd = new(); //  new Random(); -- > new();
            int num = rnd.Next(1, 6);

            if (num % 5 == 0)
            {
                stopWatch.Stop();
                Console.WriteLine("\nRANDOM DRINKING RULE (Time Paused)\n");
                pressKey();
                stopWatch.Start();
            }
        }

        // Method to get next question
        void getQuestion()
        {
            randomRule();
            Console.WriteLine("\nWrite WORD TO GUESS here");
        }

        // Method to wait for user
        void pressKey()
        {
            Console.WriteLine("\nPress a Key to Continue...\n");
            Console.ReadKey(true);
        }

        // Method to call to start game / main method.
        public void start()
        {
            // Quick Info to user
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press R for Correct Answers");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press W for Wrong Answers\n");
            Console.ResetColor();

            pressKey();

            stopWatch.Start();
            getQuestion();

            // Get time
            TimeSpan ts = stopWatch.Elapsed;

            // Counters to keep track
            int wrongCounter = 0;
            int rightCounter = 0;

            // While limit is not reached
            while (ts.TotalSeconds < timeLimit)
            {
                if (Console.KeyAvailable)
                {
                    // Check for input Right / Wrong
                    Console.WriteLine();
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.KeyChar)
                    {
                        case 'r':
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Correct!");
                            Console.ResetColor();
                            rightCounter++;
                            getQuestion();
                            break;

                        case 'w':
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong!");
                            Console.ResetColor();
                            wrongCounter++;
                            getQuestion();
                            break;
                    }
                }


                ts = stopWatch.Elapsed;

                // Print time
                string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}",
                    ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\rTime: " + elapsedTime);
                Console.ResetColor();
            }

            Console.WriteLine();

            // Summary of Round once done
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nNumber of Correct Question {rightCounter} ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Number of wrong Questions {wrongCounter} ");
            Console.ResetColor();

            stopWatch.Stop();

            // Calls itself to start next round!
            // start();
        }
    }
}
