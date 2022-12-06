using Pendu.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendu.Utilities
{
    internal class Game
    {
        public string HiddenWord { get; set; }
        public List<char> UsedLetters { get; set; }
        public int Attempts { get; set; }
        public Difficulties Difficulty { get; set; } = Difficulties.NotSet;

        public Game(string hiddenWord, Difficulties difficulty)
        {
            HiddenWord = hiddenWord;
            Difficulty = difficulty;
            UsedLetters = new List<char>();
            Attempts = 10;
        }

        public void Play(string word)
        {
            Console.WriteLine(this.HiddenWord);

            bool game = true;
            int time = GetTimeByDifficulty();

            while (game)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                this.HiddenWord = InitEtoile(word);

                while(this.Attempts >= 1)
                {
                    char letter = Console.ReadKey().KeyChar;
                    this.UsedLetters.Add(letter);

                    (bool testLetter, this.HiddenWord) = TestLetter(letter, word, this.HiddenWord);

                    if (sw.ElapsedMilliseconds >= (long)time)
                    {
                        Console.WriteLine($"Vous avez dépassé les {time / 1000} secondes autorisées. Vous avez perdu.");
                        this.Attempts = 0;
                        break;
                    }
                    if (testLetter == false) {
                        this.Attempts--;
                    }
                    if (this.Attempts == 0)
                    {
                        PrintPendu();
                        Console.WriteLine($"Vous avez perdu, le mot secret était {word}");
                        break;
                    }
                    if (TestGagne())
                    {
                        PrintPendu();
                        Console.WriteLine($"Bravo vous avez gagné ! \nLe mot secret était : {this.HiddenWord}.");
                        this.Attempts = 0;

                        sw.Stop();
                        Console.WriteLine($"Votre partie a durée {sw.ElapsedMilliseconds / 1000} secondes.");
                        break;
                    }

                    PrintPendu();
                }

                bool response = false;
                while (!response)
                {
                    Console.WriteLine("Voulez-vous rejouer ? (y/n)");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                        response = true;
                    else if (Console.ReadKey().Key == ConsoleKey.N)
                    {
                        response = true;
                        game = false;
                    }

                    Console.Clear();
                }
            }
            return;
        }

        private string InitEtoile(string word)
        {
            string hiddenWord = string.Empty;
            for (int i = 0; i < word.Length; i++)
            {
                hiddenWord+='*';
            }
            return hiddenWord;
        }

        private int GetTimeByDifficulty()
        {
            if (this.Difficulty == Difficulties.Easy)
            {
                return SetSecondsToMilliseconds(60);
            } else if (this.Difficulty == Difficulties.Medium)
            {
                return SetSecondsToMilliseconds(30);
            } else
            {
                return SetSecondsToMilliseconds(15);
            }
        }

        private int SetSecondsToMilliseconds(int time)
        {
            return time * 1000;
        }

        private (bool, string) TestLetter(char letter, string word, string hiddenWord)
        {
            bool win = false;
            string newHiddenWord = string.Empty;
            for (int i = 0; i < word.Length; i++)
            {
                if (hiddenWord[i] != '*')
                {
                    newHiddenWord += hiddenWord[i];
                } else if (word[i] == letter)
                {
                    newHiddenWord += letter;
                    win = true;
                } else
                {
                    newHiddenWord += '*';
                }
            }
            return (win, newHiddenWord);
        }

        private bool TestGagne()
        {
            bool win = true;
            for (int i = 0; i < HiddenWord.Length; i++)
            {
                if (HiddenWord[i] == '*')
                {
                    win = false;
                    break;
                }
            }
            return win;
        }

        private void PrintPendu()
        {
            string[] pendu = new string[11];
            pendu[0] =
                "\n	 ______\n" +
                "	 |   |\n"+
                "	 |   O\n"+
                "	 |  /|\\\n"+
                "	 |  / \\\n"+
                "	_|_\n\n   ";
            pendu[1] =
                "\n	 ______\n" +
                "	 |   |\n"+
                "	 |   O\n"+
                "	 |  /|\\\n"+
                "	 |  / \n"+
                "	_|_\n\n   ";
            pendu[2] =
                "\n	 ______\n" +
                "	 |   |\n"+
                "	 |   O\n"+
                "	 |  /|\\\n"+
                "	 |  \n"+
                "	_|_\n\n   ";
            pendu[3] =
                "\n	 ______\n" +
                "	 |   |\n"+
                "	 |   O\n"+
                "	 |  /|\n"+
                "	 |  \n"+
                "	_|_\n\n   ";
            pendu[4] =
                "\n	 ______\n" +
                "	 |   |\n"+
                "	 |   O\n"+
                "	 |   |\n"+
                "	 |  \n"+
                "	_|_\n\n   ";
            pendu[5] =
                "\n	 ______\n" +
                "	 |   |\n"+
                "	 |   O\n"+
                "	 |  \n"+
                "	 |  \n"+
                "	_|_\n\n   ";
            pendu[6] =
                "\n	 ______\n" +
                "	 |   |\n"+
                "	 |  \n"+
                "	 |  \n"+
                "	 |  \n"+
                "	_|_\n\n   ";
            pendu[7] =
                "\n	 ______\n" +
                "	 |  \n"+
                "	 |  \n"+
                "	 |  \n"+
                "	 |  \n"+
                "	_|_\n\n   ";
            pendu[8] =
                "	 \n" +
                "	 |  \n"+
                "	 |  \n"+
                "	 |  \n"+
                "	 |  \n"+
                "	_|_\n\n   ";
            pendu[9] =
                "	 \n"+
                "    \n"+
                "	 \n"+
                "	 |  \n"+
                "	 |  \n"+
                "	_|_\n\n   ";
            pendu[10] =
                "	 \n"+
                "	 \n"+
                "	 \n"+
                "	 \n"+
                "	 \n"+
                "	\n\n   ";

            Console.Clear();
            Console.WriteLine($"Lettres utilisées : ");
            foreach (char letter in this.UsedLetters)
            {
                Console.Write(letter);
            }
            Console.WriteLine(pendu[this.Attempts]);
            Console.WriteLine(this.HiddenWord);
        }
    }
}
