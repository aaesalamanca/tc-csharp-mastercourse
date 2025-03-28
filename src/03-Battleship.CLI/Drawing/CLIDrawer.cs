using _03_Battleship.Library.Helpers;
using _03_Battleship.Library.Models;

namespace _03_Battleship.CLI.Drawing;

static class CLIDrawer
{
    public static void ShowHeader()
    {
        Console.Clear();

        Console.WriteLine("###############################");
        Console.WriteLine("####### Battleship Game #######");
        Console.WriteLine("###############################");
        Console.WriteLine();
    }

    public static void ShowInitialGridProgress(string playerName, List<string> initialPositions)
    {
        Console.WriteLine(
            $"{playerName}, these are the positions where you can place your ships (placed ships are marked with `++`):"
        );
        Console.WriteLine();

        for (char c = 'A'; c < 'F'; c++)
        {
            for (int i = 0; i < 5; i++)
            {
                if (initialPositions.Contains($"{c}{i}"))
                {
                    Console.Write("++ ");
                }
                else
                {
                    Console.Write($"{c}{i} ");
                }
            }
            Console.WriteLine();
        }
    }

    public static void ShowInitializedGrid(string playerName, List<string> initialPositions)
    {
        Console.WriteLine(
            $"{playerName}, these are your ships placed in your grid (placed ships are marked with `++`):"
        );
        Console.WriteLine();

        for (char c = 'A'; c < 'F'; c++)
        {
            for (int i = 0; i < 5; i++)
            {
                if (initialPositions.Contains($"{c}{i}"))
                {
                    Console.Write("++ ");
                }
                else
                {
                    Console.Write($"{c}{i} ");
                }
            }
            Console.WriteLine();
        }
    }

    public static void ShowCurrentTurnGrid(Ship[] ships, bool isEnemy = true)
    {
        Console.WriteLine("----------");
        Console.WriteLine();

        Console.WriteLine(
            $"{(isEnemy ? "Your enemy's grid is (sunk enemy's ships are marked with `XX`):" : "Your grid is (sunk ships are marked with `XX` and alive ships are marked with `++`):")}"
        );
        Console.WriteLine();
        Console.WriteLine($"\tAlive ships: {ships.Count(ship => ship.Status == ShipStatus.Alive)}");
        Console.WriteLine();

        var enemyShipStatuses = ships.GetStatusesDictionary();

        for (char c = 'A'; c < 'F'; c++)
        {
            for (int i = 0; i < 5; i++)
            {
                if (enemyShipStatuses.TryGetValue($"{c}{i}", out var status))
                {
                    if (status == ShipStatus.Sunk)
                    {
                        Console.Write("XX ");
                    }
                    else if (!isEnemy)
                    {
                        Console.Write($"++ ");
                    }
                    else
                    {
                        Console.Write($"{c}{i} ");
                    }
                }
                else
                {
                    Console.Write($"{c}{i} ");
                }
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public static void ShowAfterShotMessage(string actualPlayerName, bool isSunk)
    {
        if (isSunk)
        {
            Console.WriteLine($"{actualPlayerName}, you shot an enemy ship!");
        }
        else
        {
            Console.WriteLine($"{actualPlayerName}, you failed your shot...");
        }
    }

    public static void ShowWinner(string winnerName) =>
        Console.WriteLine($"Congratulations, {winnerName}! You're the winner!");

    public static void ShowFinalStats(int numberOfRounds, Player winner, Player looser)
    {
        Console.WriteLine("----------");
        Console.WriteLine("");

        Console.WriteLine("Game stats:");
        Console.WriteLine();

        Console.WriteLine($"\tNumber of rounds: {numberOfRounds}");
        Console.WriteLine();

        ShowPlayerStats(winner, looser);
        Console.WriteLine();
        ShowPlayerStats(looser, winner);
    }

    static void ShowPlayerStats(Player actualPlayer, Player enemyPlayer)
    {
        Console.WriteLine($"\tPlayer: {actualPlayer.Name}");
        Console.WriteLine();

        Console.WriteLine($"\t\tNumber of shots: {actualPlayer.Shots.Count}");
        Console.Write("\t\tShots: ");
        foreach (var shot in actualPlayer.Shots)
        {
            Console.Write($"{shot} ");
        }
        Console.WriteLine();
        Console.WriteLine(
            $"\t\tAccuracy: {enemyPlayer.Ships.Count(ship => ship.Status == ShipStatus.Sunk) / (double)actualPlayer.Shots.Count:P}"
        );
    }
}
