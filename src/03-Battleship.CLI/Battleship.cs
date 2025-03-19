using _03_Battleship.CLI.Drawing;
using _03_Battleship.CLI.IO;
using _03_Battleship.Libray.Models;

namespace _03_Battleship.CLI;

static class Battleship
{
    public static void Start()
    {
        var (playerName1, playerName2) = RequestPlayerNames();
        var (initialPositions1, initialPositions2) = RequestInitialPositions(
            playerName1,
            playerName2
        );
    }

    static (string name1, string name2) RequestPlayerNames()
    {
        var playerName1 = UserInteraction.AskForPlayerName(1);
        var playerName2 = UserInteraction.AskForPlayerName(2);

        return (playerName1, playerName2);
    }

    static (string[] initialPositions1, string[] initialPositions2) RequestInitialPositions(
        string playerName1,
        string playerName2
    )
    {
        var initialPositions1 = UserInteraction.AskForInitialPositions(playerName1);
        var initialPositions2 = UserInteraction.AskForInitialPositions(playerName2);

        return (initialPositions1, initialPositions2);
    }
}
