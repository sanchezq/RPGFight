using System;
using System.Collections.Generic;
using System.Text;

class Game
{
    public static bool Input(ConsoleKey keyTest, ConsoleKey keyTest2)
    {
        Console.WriteLine();
        while (true)
        {
            ConsoleKey key = Console.ReadKey().Key;
            Console.CursorLeft = 0;
            Console.Write(" ");
            Console.CursorLeft = 0;

            if (key == keyTest)
            {
                return true;
            }
            else if (key == keyTest2)
            {
                return false;
            }
        }
    }
    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ╗\n");
        Console.WriteLine("{0,25} {1, 16}", "[ RPG Fight ]", "║\n");
        Console.WriteLine("═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ╝\n\n\n");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("Press ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("[Enter] ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("to Play\n\n\n");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("Press ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("[Esc] ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("to Exit");

        if (Input(ConsoleKey.Enter, ConsoleKey.Escape))
        {
            Intro();
        }
    }
    public static void Intro()
    {
        Commentator commentator = new Commentator();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ╗\n");
        Console.WriteLine("{0,25} {1, 16}", "[ RPG Fight ]", "║\n");
        Console.WriteLine("═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ╝\n\n\n");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.Write("First character's name: ");
        string name1 = Console.ReadLine();

        Console.WriteLine("\n\nFirst character's class:\n");
        Console.WriteLine("1. Warrior");
        Console.WriteLine("2. Wizard");

        Character charA;

        if (Input(ConsoleKey.NumPad1, ConsoleKey.NumPad2))
        {
            Warrior war = new Warrior(name1);
            commentator.Link(war);
            charA = war;
        }
        else
        {
            Wizard wiz = new Wizard(name1);
            commentator.Link(wiz);
            charA = wiz;
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ╗\n");
        Console.WriteLine("{0,25} {1, 16}", "[ RPG Fight ]", "║\n");
        Console.WriteLine("═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ╝\n\n\n");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.Write("Second character's name: ");
        string name2 = Console.ReadLine();

        Console.WriteLine("\n\nSecond character's class:\n");
        Console.WriteLine("1. Warrior");
        Console.WriteLine("2. Wizard");

        Character charB;

        if (Input(ConsoleKey.NumPad1, ConsoleKey.NumPad2))
        {
            Warrior war = new Warrior(name2);
            commentator.Link(war);
            charB = war;
        }
        else
        {
            Wizard wiz = new Wizard(name1);
            commentator.Link(wiz);
            charB = wiz;
        }

        Fight(charA, charB);
    }
    public static void DisplayStats(Character charA, Character charB)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ╗\n");
        Console.WriteLine("{0,-30} {1, -30} {2, -60}", "[" + charA.GetType() + "] " + charA.name, "║ " + "[" + charB.GetType() + "] " + charB.name, "║");

        Console.WriteLine("{0,-30} {1, -30} {2, -60}", "- HP: " + charA.HP.ToString(), "║ " + "- HP: " + charB.HP.ToString(), "║");
        Console.WriteLine("{0,-30} {1, -30} {2, -60}", "- MP: /", "║ " + "- MP: " + charB.MP.ToString(), "║");
        Console.WriteLine("{0,-30} {1, -30} {2, -60}", "- Attack Points: " + charA.AP.ToString(), "║ " + "- Attack Points: " + charB.AP.ToString(), "║");
        Console.WriteLine("{0,-30} {1, -30} {2, -60}", "- Defense Points: " + charA.DP.ToString(), "║ " + "- Defense Points: " + charB.DP.ToString(), "║");
        Console.WriteLine("═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ═ ╝");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public static void Fight(Character charA, Character charB)
    {
        int i = 1;

        while (charA.HP > 0 && charB.HP > 0)
        {
            DisplayStats(charA, charB);
            Console.WriteLine("\nRound " + i + "\n");

            if (i % 2 == 0)
            {
                charB.Action(charA);
                if (charA.HP > 0)
                {
                    charA.Action(charB);
                }
            }
            else
            {
                charA.Action(charB);
                if (charB.HP > 0)
                {
                    charB.Action(charA);
                }
            }
            i++;

            if (charA.HP > 0 && charB.HP > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n\nPress [Space] to continue...");
                if (!Input(ConsoleKey.Spacebar, ConsoleKey.Escape))
                {
                    return;
                }
            }
        }

        DisplayStats(charA, charB);

        Console.ForegroundColor = ConsoleColor.Yellow; ;

        if (charA.HP > 0)
        {
            Console.WriteLine("\n  " + charA.name + " won !");
        }
        else
        {
            Console.WriteLine("\n  " + charB.name + " won !");
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
    }
}
