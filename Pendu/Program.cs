using Pendu.Library;
using Pendu.Enum;
using Pendu.Utilities;
using System.Collections;

Console.Title = "Morpion";

Console.WriteLine("Bienvenue dans le morpion");
List<Player> players = Functions.SetPlayers();
Player player1 = players[0];
Player player2 = players[1];

Console.WriteLine($"{player1.Name} va affronter {player2.Name}, confirmer ? (y/n)");
if (Console.ReadKey().Key == ConsoleKey.N)
    return;

Difficulties difficulty = Functions.SetDifficulty();

