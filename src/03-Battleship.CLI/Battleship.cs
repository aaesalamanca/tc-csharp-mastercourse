using _03_Battleship.CLI.Drawing;
using _03_Battleship.CLI.IO;
using _03_Battleship.Libray.Models;

namespace _03_Battleship.CLI;

static class Battleship
{
    public static void Start()
    {
        CLIDrawer.ShowWelcome();

        var (p1, p2) = CreatePlayers();
    }

    static (Player p1, Player p2) CreatePlayers()
    {
        string playerName1 = UserInteraction.AskForPlayerNumber(1);
        string playerName2 = UserInteraction.AskForPlayerNumber(2);

        return (new Player { Name = playerName1 }, new Player { Name = playerName2 });
    }
}
