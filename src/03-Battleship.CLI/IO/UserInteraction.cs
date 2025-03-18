namespace _03_Battleship.CLI.IO;

static class UserInteraction
{
    static string? AskForPlayerInfo(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }

    public static string AskForPlayerNumber(int playerNumber)
    {
        do
        {
            var playerName = AskForPlayerInfo($"What is the name for player {playerNumber}?");

            if (string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine("The player name can't be empty or whitespace.");
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();
            return playerName;
        } while (true);
    }
}
