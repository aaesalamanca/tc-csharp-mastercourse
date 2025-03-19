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

    public static void ShowInitialGrid(string playerName, List<string> initialPositions)
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

    public static void ShowInitialPositions(List<string> initialPositions)
    {
        Console.WriteLine("You have placed the ships in the following positions:");
        foreach (var initialPosition in initialPositions)
        {
            Console.Write($"{initialPosition} ");
        }
        Console.WriteLine();
    }
}
