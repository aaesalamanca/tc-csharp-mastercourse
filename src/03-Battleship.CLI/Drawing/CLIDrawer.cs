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

    public static void ShowInitialGrid()
    {
        for (char c = 'A'; c < 'F'; c++)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{c}{i} ");
            }
            Console.WriteLine();
        }
    }

    public static void ShowInitialShipsLocation(List<string> initialShipsLocation)
    {
        Console.WriteLine("You have placed the ships in the following positions: ");
        foreach (var shipLocation in initialShipsLocation)
        {
            Console.Write($"{shipLocation} ");
        }
        Console.WriteLine();
    }
}
