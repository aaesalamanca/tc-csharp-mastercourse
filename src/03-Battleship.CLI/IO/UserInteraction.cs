using _03_Battleship.CLI.Drawing;
using _03_Battleship.Libray.Services;

namespace _03_Battleship.CLI.IO;

static class UserInteraction
{
    public static string AskForPlayerNumber(int playerNumber)
    {
        do
        {
            CLIDrawer.ShowHeader();

            var playerName = AskForPlayerInfo($"What is the name for player {playerNumber}?");

            if (string.IsNullOrWhiteSpace(playerName))
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

            Console.WriteLine(
                $"{playerName}, these are the positions where you can place your ships:"
            );
            Console.WriteLine();
            CLIDrawer.ShowInitialGrid();
            Console.WriteLine();

            if (initialPositions.Count > 0)
            {
                CLIDrawer.ShowInitialShipsLocation(initialPositions);
                Console.WriteLine();
            }

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

        return [.. initialPositions];
    }

    static string? AskForPlayerInfo(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }
}
