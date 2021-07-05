using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party_Bud_1._0
{
    class TurnamentManager
    {
        // Players in Play
        List<string> players = new List<string> {};

        // Current Round
        List<string> player1 = new List<string> { };
        List<string> player2 = new List<string> { };

        public void setup()
        {
            Console.WriteLine("How many players will there be?");
            Console.Write("> ");
            string userInput = Console.ReadLine();

            try
            {
                int personsPlaying = Int32.Parse(userInput);

                if (personsPlaying <= 0)
                {
                    Console.WriteLine("Can't be less than or equal to 0");
                    System.Environment.Exit(0);
                }

                foreach (var person in Enumerable.Range(1, personsPlaying))
                {
                    Console.WriteLine("Name of Player?");
                    Console.Write("> ");
                    string playerName = Console.ReadLine();
                    players.Add(playerName);
                }

                for (int i = 0; i < players.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        player1.Add(players[i]);
                    } else
                    {
                        player2.Add(players[i]);
                    }
                }

                // Make sure everyone has an oponent
                if (player1.Count != player2.Count)
                {
                    player2.Add(players[0] + " 2"); // Just to mark which of the round qulifies the person
                }

                foreach (var player in player1)
                {
                    Console.WriteLine(player);
                }

                foreach (var player in player2)
                {
                    Console.WriteLine(player);
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Invalid input from user is not Int, Error: {e.Message}");
            }
        }

        public void start()
        {
            Console.WriteLine("\nPlayer that are to play against each other are as follows:\n");

            for (int i = 0; i < player1.Count; i++)
            {
                Console.WriteLine($"{player1[i]} - {player2[i]}");
            }

            Console.WriteLine("\nLet's the matches begin!\n");

            for (int i = 0; i < player1.Count; i++)
            {
                Console.WriteLine("Who won?");
                Console.WriteLine($"1 for {player1[i]} - 2 for {player2[i]}");
                Console.Write("> ");
                string userInput = Console.ReadLine();

                try
                {
                    int personWon = Int32.Parse(userInput);

                    switch (personWon)
                    {
                        case 1:
                            players.Remove(player2[i]);
                            break;
                        case 2:
                            players.Remove(player1[i]);
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Invalid input from user Only 1 or 2, Error: {e.Message}");
                }
            }

            if (players.Count > 1)
            {
                newRound();
            } 
            else {
                Console.WriteLine($"Winner is: {players[0]}");
            }
        }

        void newRound()
        {
            player1.Clear();
            player2.Clear();

            for (int i = 0; i < players.Count; i++)
            {
                if (i % 2 == 0)
                {
                    player1.Add(players[i]);
                }
                else
                {
                    player2.Add(players[i]);
                }
            }

            // Make sure everyone has an oponent
            if (player1.Count != player2.Count)
            {
                player2.Add(players[0] + " 2");
            }

            start();
        }
    }
}
