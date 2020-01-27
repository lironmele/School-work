using System;

namespace Monopoly
{
    class Monopoly
    {
        public static void House(int player, int Move, int[] wallet, string[] gameBoard, string[] owner, int[] Price, string[] names)
        {
            if (owner[Move] == null)
            {
                Console.WriteLine($"Do you want to buy {gameBoard[Move]}?");
                bool buy = bool.Parse(Console.ReadLine());
                if (buy)
                {
                    owner[Move] = names[player];
                    wallet[player] -= Price[Move];
                    return;
                }
                else
                {
                    return;
                }
            }
            else if (Move == 12 || Move == 25) // incase of factory
            {
                Console.WriteLine($"{gameBoard[Move]} is owned by {owner[Move]}. {names[player]} gets 50 but loses one turn.");
                wallet[player] += (50);
                wallet[Array.IndexOf(names, owner[Move])] -= 50;
                return;
            }
            else
            {
                Console.WriteLine($"{gameBoard[Move]} is owned by {owner[Move]}. Pay {Price[Move] / 5}!");
                wallet[player] -= (Price[Move] / 5);
                wallet[Array.IndexOf(names, owner[Move])] += (Price[Move] / 5);
                return;
            }
        }

        public static int RollDice(Random D)
        {
            return D.Next(1, 7) + D.Next(1, 7);
        }

        public static void MakeTurn(int player, int[] wallet, int[] Position, string[] gameBoard, string[] owner, int[] Penalty, int[] Price, string[] names)
        {
            Random rnd = new Random();
            int Move = RollDice(rnd);
            Position[player] += Move;
            if (Position[player] > 30)
            {
                Position[player] -= 30;
            }
            Move = Position[player];
            switch (Move)
            {
                case 3:
                case 4:
                case 11:
                case 17:
                case 18:
                case 19:
                case 24: // House
                    House(player, Move, wallet, gameBoard, owner, Price, names);
                    break;
                case 15: // prison
                    Penalty[player] += 2;
                    Console.WriteLine("Jail for two moves!");
                    break;
                case 8:
                case 21: // police, road 6
                    wallet[player] -= Price[Move];
                    Console.WriteLine(gameBoard[Move]);
                    break;
                case 9: // pais factory
                    wallet[player] += Price[Move];
                    Console.WriteLine(gameBoard[Move]);
                    break;
                case 12:
                case 25: // factory
                    House(player, Move, wallet, gameBoard, owner, Price, names);
                    Penalty[player] += 1;
                    break;
                case 27: // toto
                    Console.WriteLine(gameBoard[Move]);
                    Position[player] += 5;
                    Position[player] -= 30;
                    break;
            }
        }

        public static bool CheckDefeat(int[] wallet, string[] names)
        { 
            for (int i = 0; i < wallet.Length; i++)
            {
                if (wallet[i] < 1)
                {
                    Console.WriteLine($"{names[i]} has lost! What a loser!");
                    return false;
                }
            }
            return true;
        }

        public static void PrintPlayers(int[] wallet, int[] Position, string[] gameBoard, string[] owner, int[] Penalty, string[] names)
        {
            Console.WriteLine("**************************");
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{names[i]}:");
                Console.Write($"Wallet - {wallet[i]}. Penalty - {Penalty[i]}. Position - {Position[i]+1}. ");
                Console.Write("Ownes: ");
                for (int j = 0; j < owner.Length; j++)
                {
                    if (owner[j] == names[i])
                    {
                        Console.Write($"{gameBoard[j]}   ");
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.WriteLine("**************************");
        }

        public static void Main(string[] args)
        {
            // init
            Console.WriteLine("How many players are playing?");
            int NumberOfPlayers = int.Parse(Console.ReadLine());
            while (NumberOfPlayers < 2 && NumberOfPlayers > 4)
            {
                Console.WriteLine("Player count should be between 2 and 4");
                NumberOfPlayers = int.Parse(Console.ReadLine());
            }
            int[] wallet = new int[NumberOfPlayers];
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                wallet[i] = 1000;
            }
            string[] gameBoard = { "start", "", "", "Tel Aviv Center", "Tel Aviv  beach", "", "", "", "Toll road. you have to pay...", "Lottery = you win", "", "Petach Tikva", "Industrial Area=PT", "", "", "Prison - Wait 2 turns", "", "Jerusalem", "Haifa - on top", "Haifa - down", "", "Police - Speeding", "", "", "Eilat", "Eilat - Industrial Area", "", "Toto - jump 5 step", "", "" };
            int[] Price = { 0, 0, 0, 250, 300, 0, 0, 0, 50, 200, 0, 200, 250, 0, 0, 0, 0, 200, 150, 100, 0, 200, 0, 0, 200, 300, 0, 0, 0, 0 };
            string[] owner = new string[30];
            int[] Position = new int[NumberOfPlayers];
            for (int p = 0; p < NumberOfPlayers; p++)
            {
                Position[p] = 0;
            }
            string[] names = new string[NumberOfPlayers];
            for (int n = 0; n < NumberOfPlayers; n++)
            {
                Console.WriteLine("Please input a name!");
                names[n] = Console.ReadLine();

            }
            int[] Penalty = new int[NumberOfPlayers];
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Penalty[i] = 0;
            }

            // Main Game
            int f = 0;
            while (CheckDefeat(wallet, names))
            {
                Console.ReadKey();
                if (f >= names.Length)
                {
                    f = 0;
                }
                if (Penalty[f] > 0)
                {
                    Penalty[f] -= 1;
                    Console.WriteLine($"{names[f]} is in jail for {Penalty[f]+1} more turns!");
                    f++;
                    continue;
                }
                MakeTurn(f, wallet, Position, gameBoard, owner, Penalty, Price, names);
                f++;
                PrintPlayers(wallet, Position, gameBoard, owner, Penalty, names);
            }

        }
    }
}
