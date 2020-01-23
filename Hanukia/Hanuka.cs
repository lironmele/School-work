using System;

namespace SchoolWork
{
    class Hanuka
    {
        public static int[] CreateHanuka()
        {
            Random rnd = new Random();
            int[] Hanukia = new int[9];
            for (int i = 0; i < 9; i++)
            {
                Hanukia[i] = rnd.Next(1,6);
            }
            return Hanukia;
        }

        public static void ChangeColorCandle(int color)
        {
            switch(color)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
            }
        }
        public static bool DrawHanukia(int day, int[] hanukia)
        {
            if (day < 1 || day > 8)
            {
                return false;
            }
            ConsoleColor currentForeground = Console.ForegroundColor;
            ChangeColorCandle(hanukia[0]);
            Console.WriteLine("    *");
            Console.WriteLine("    *");
            for (int i = 0; i < 6; i++)
            {
                for (int can = 0; can <= day; can++)
                {
                    ChangeColorCandle(hanukia[can]);
                    Console.Write("    *");
                }
                Console.WriteLine("");
            }
            Console.ForegroundColor = currentForeground;
            Console.WriteLine("************************************************");
            Console.WriteLine("************************************************");
            Console.WriteLine("************************************************");
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Great Hanuka how many candles today?");
            int CanNum = int.Parse(Console.ReadLine());
            int[] Hanukia1 = CreateHanuka();
            DrawHanukia(CanNum, Hanukia1);
        }
    }
}