using System;

namespace Monopoly
{
    class Program
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
            foreach (int i in wallet)
            {
                wallet[i] = 1000;
            }
            string[] gameBoard = { "start", "", "", "Tel Aviv Center", "Tel Aviv  beach", "", "", "", "Toll road. you have to pay...", "Lottery = you win", "", "Petach Tikva", "Industrial Area=PT", "", "", "Prison - Wait 2 turns", "", "Jerusalem", "Haifa - on top", "Haifa - down", "", "Police - Speeding", "", "", "Eilat", "Eilat - Industrial Area", "", "Toto - jump 5 step", "", "" };
            int[] Price = { 0, 0, 0, 250, 300, 0, 0, 0, 50, -200, 0, 200, 250, 0, 0, 0, 0, 200, 150, 100, 0, 200, 0, 0, 200, 300, 0, 0, 0, 0 };
            string[] owner = new string[30];
            int[] players = new int[NumberOfPlayers];
            foreach (int p in players)
            {
                players[p] = 0;
            }
            Random dice = new Random();
        }

        public static int RollDice(Random D)
        {
            return D.Next(1, 7) + D.Next(1, 7);
        }

        public static void MakeTurn()
        {
        
        }

        public static void PrintPlayers(string[] args)
        { 
            
        }

        public static void Main(string[] args)
        {

        }
    }
}