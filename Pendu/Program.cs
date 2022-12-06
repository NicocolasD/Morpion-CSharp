using Pendu.Library;
using Pendu.Enum;
using Pendu.Utilities;
using System.Collections;

Console.Title = "Pendu";

Console.WriteLine("Bienvenue dans le pendu");
List<Player> players = Functions.SetPlayers();
Player player1 = players[0];
Player player2 = players[1];

Console.WriteLine($"{player1.Name} va affronter {player2.Name}, confirmer ? (y/n)");
if (Console.ReadKey().Key == ConsoleKey.N)
    return;

Difficulties difficulty = Functions.SetDifficulty();

bool play = true;
do
{
    Game game = new(difficulty, players);
    foreach (Player player in players)
    {
        string word = Functions.ChooseWord();
        bool win = game.Play(word, player.Name);
        if (win)
            player.AddPoint();
        Console.WriteLine("Appuyez sur espace pour continuer.");
        if (Console.ReadKey().Key == ConsoleKey.Spacebar)
            continue;
    }

    bool response = false;
    while (!response)
    {
        Console.Clear();
        Console.WriteLine("Voulez-vous rejouer ? (y/n)");
        ConsoleKey key = Console.ReadKey().Key;
        if (key == ConsoleKey.Y)
            response = true;
        else if (key == ConsoleKey.N)
        {
            response = true;
            play = false;
            Console.Clear();
            Console.WriteLine("Score :");
            foreach (Player player in players)
            {
                Console.WriteLine($"    {player.Name} : {player.Score} points");
            }
        }
    }
} while (play);




return;