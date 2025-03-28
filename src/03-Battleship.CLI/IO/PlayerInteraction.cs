using _03_Battleship.CLI.Drawing;
using _03_Battleship.Library.Models;
using _03_Battleship.Library.Services;

namespace _03_Battleship.CLI.IO;

static class PlayerInteraction
{
    public static string AskForPlayerName(int playerNumber)
    {
        do
        {
            CLIDrawer.ShowHeader();

            var playerName = AskForPlayerInfo($"What is the name for player {playerNumber}?");

            if (!InputValidationService.IsValidPlayerName(playerName))
            {
                Console.WriteLine(
                    "The player name can't be empty or whitespace. Press ENTER to continue."
                );
                _ = Console.ReadKey();

                continue;
            }

            return playerName;
        } while (true);
    }

    public static string[] AskForInitialPositions(string playerName)
    {
        var initialPositions = new List<string>();
        do
        {
            CLIDrawer.ShowHeader();
            CLIDrawer.ShowInitialGridProgress(playerName, initialPositions);
            Console.WriteLine();

            var initialShipPosition = AskForPlayerInfo(
                $"{playerName}, where do you want to place your ship number {initialPositions.Count + 1}?"
            );

            if (
                !InputValidationService.IsValidInitialShipPosition(
                    initialShipPosition,
                    initialPositions
                )
            )
            {
                Console.WriteLine("That's not a valid ship position. Press ENTER to continue.");
                _ = Console.ReadKey();

                continue;
            }

            initialPositions.Add(initialShipPosition);
        } while (initialPositions.Count < 5);

        CLIDrawer.ShowHeader();
        CLIDrawer.ShowInitializedGrid(playerName, initialPositions);
        Console.WriteLine();
        Console.WriteLine("Press ENTER to continue.");
        _ = Console.ReadKey();

        return [.. initialPositions];
    }

    public static string AskForShot(Player actualPlayer, Player enemyPlayer)
    {
        do
        {
            CLIDrawer.ShowHeader();
            Console.WriteLine($"Actual turn is for player: {actualPlayer.Name}.");
            Console.WriteLine();

            CLIDrawer.ShowCurrentTurnGrid(enemyPlayer.Ships);
            CLIDrawer.ShowCurrentTurnGrid(actualPlayer.Ships, false);

            var shot = AskForPlayerInfo(
                $"{actualPlayer.Name}, at which position do you want to shot?"
            );
            if (!InputValidationService.IsValidShot(shot, enemyPlayer.Ships))
            {
                Console.WriteLine("That's not a valid shot. Press ENTER to continue.");
                _ = Console.ReadKey();
                continue;
            }

            return shot;
        } while (true);
    }

    public static void ShowShotStatus(string actualPlayerName, bool isSunk)
    {
        CLIDrawer.ShowHeader();
        CLIDrawer.ShowAfterShotMessage(actualPlayerName, isSunk);
        Console.WriteLine();

        Console.WriteLine("Press ENTER to continue.");
        _ = Console.ReadKey();
    }

    public static void ShowWinnerAndStats(int numberOfRounds, Player winner, Player looser)
    {
        CLIDrawer.ShowHeader();
        CLIDrawer.ShowWinner(winner.Name);
        Console.WriteLine();
        CLIDrawer.ShowFinalStats(numberOfRounds, winner, looser);
    }

    static string? AskForPlayerInfo(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }
}
