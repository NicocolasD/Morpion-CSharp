using Pendu.Library;
using Pendu.Enum;
using Pendu.Utilities;

Console.Title = "Morpion";

Console.WriteLine("Bienvenue dans le morpion");
Console.WriteLine("\nSaisissez le nom du joueur 1 : ");
Player player1 = new (Console.ReadLine());
Console.WriteLine("\nSaisissez le nom du joueur 2 : ");
Player player2 = new(Console.ReadLine());

Console.WriteLine($"\n{player1.Name} va affronter {player2.Name}, confirmer ? (y/n)");
if (Console.ReadKey().Key == ConsoleKey.N)
    return;

Difficulties difficulty = Functions.SetDifficulty();

