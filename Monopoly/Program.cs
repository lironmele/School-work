using System;

namespace Monopoly
{
    class Monopoly
    {
        public static void Init()
        {
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
            int[] Price = { 0, 0, 0, 250, 300, 0, 0, 0, 50, -200, 0, 200, 250, 0, 0, 0, 0, 200, 150, 100, 0, 200, 0, 0, 200, 300, 0, 0, 0, 0 };
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
            Random dice = new Random();
        }

        public static void House(int player, int Move, int[] wallet, int[] Position, string[] gameBoard, string[] owner, int[] Penalty, int[] Price, string[] names)
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
            else
            { 
                
            }
        }

        public static int RollDice(Random D)
        {
            return D.Next(1, 7) + D.Next(1, 7);
        }

        public static void MakeTurn(int player, int Move, int[] wallet, int[] Position, string[] gameBoard, string[] owner, int[] Penalty, int[] Price, string[] names)
        {
            if (Move > 30)
            {
                Move -= 30;
            }
            Position[player] += Move;
            Move = Position[player];
            switch (Move)
            {
                case 3:
                case 4:
                case 11:
                case 17:
                case 18:
                case 19:
                case 24:
                    House(player, Move, wallet, Position, gameBoard, owner, Penalty, Price);
                    break;
                case 15:
                    Penalty[player] += 2;
                    Console.WriteLine("Jail for two moves!");
                    break;
                case 21:
                case 8:
                    wallet[player] -= 50;
                    Console.WriteLine(gameBoard[Move]);
                    break;
                case 9:
                    wallet[player] += Price[Move];
                    break;
            }
        }

        public static void PrintPlayers(string[] args)
        { 
            
        }

        public static void Main(string[] args)
        {

        }
    }
}
