using Pendu.Enum;
using Pendu.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendu.Utilities
{
    internal class Functions
    {
        #region Difficulty 

        private static void WriteDifficultyChoices()
        {
            Console.Clear();
            Console.WriteLine("Choix de la difficulté : ");
            Console.WriteLine($"1 : {Difficulties.Easy} \n2 : {Difficulties.Medium} \n3 : {Difficulties.Difficult}");
        }

        public static Difficulties SetDifficulty()
        {
            WriteDifficultyChoices();
            Difficulties difficulty = Difficulties.NotSet;
            do
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        Console.WriteLine("Etes-vous sûr de vouloir choisir le mode facile ? (y/n)");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            difficulty = Difficulties.Easy;
                        }
                        break;
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        Console.WriteLine("Etes-vous sûr de vouloir choisir le mode moyen ? (y/n)");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            difficulty = Difficulties.Medium;
                        }
                        break;
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        Console.WriteLine("Etes-vous sûr de vouloir choisir le mode difficile ? (y/n)");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            difficulty = Difficulties.Difficult;
                        }
                        break;
                    default:
                        WriteDifficultyChoices();
                        break;
                }
            } while (difficulty == Difficulties.NotSet);
            Console.Clear();
            return difficulty;
        }

        #endregion

        #region Players

        public static List<Player> SetPlayers()
        {
            List<Player> players = new();
            for (int i = 1; i < 3; i++)
            {
                Console.WriteLine($"\nSaisissez le nom pour le joeur {i} : ");
                players.Add(new Player(Console.ReadLine()));
            }
            Console.Clear();
            return players;
        }

        #endregion

        #region File

        public static string ChooseWord()
        {
            string[] words = File.ReadAllLines("C:\\DEV\\COURS_C#\\Pendu\\Pendu\\mots.txt");
            Random random = new();
            int number = random.Next(0, words.Length);
            return words[number];
        }

        #endregion
    }
}
