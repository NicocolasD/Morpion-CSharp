using Pendu.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendu.Utilities
{
    internal class Functions
    {
        private static void Writehoices()
        {
            Console.Clear();
            Console.WriteLine("Choix de la difficulté : ");
            Console.WriteLine($"1 : {Difficulties.Easy} \n2 : {Difficulties.Medium} \n3 : {Difficulties.Difficult}");
        }

        internal static Difficulties SetDifficulty()
        {
            Writehoices();
            Difficulties difficulty = Difficulties.NotSet;
            do
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("Etes-vous sûr de vouloir choisir le mode facile ? (y/n)");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            difficulty = Difficulties.Easy;
                        }
                        break;
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("Etes-vous sûr de vouloir choisir le mode moyen ? (y/n)");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            difficulty = Difficulties.Medium;
                        }
                        break;
                    case ConsoleKey.NumPad3:
                        Console.WriteLine("Etes-vous sûr de vouloir choisir le mode difficile ? (y/n)");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            difficulty = Difficulties.Difficult;
                        }
                        break;
                    default:
                        Writehoices();
                        break;
                }
            } while (difficulty == Difficulties.NotSet);
            Console.Clear();
            return difficulty;
        }
    }
}
