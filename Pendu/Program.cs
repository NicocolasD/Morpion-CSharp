using Pendu.Library;

Console.WriteLine("Bienvenue dans le morpion");
Console.WriteLine("Saisissez le nom du joueur 1 : ");
Player player1 = new (Console.ReadLine());
Console.WriteLine("Saisissez le nom du joueur 2 : ");
Player player2 = new(Console.ReadLine());

Console.WriteLine($"{player1.Name} va affronter {player2.Name}, confirmer ? (y/n)");
if (Console.ReadLine() == "n")
    return;


    