using _03_Battleship.CLI.IO;
using _03_Battleship.Library.Helpers;
using _03_Battleship.Library.Models;
using _03_Battleship.Library.Services;

namespace _03_Battleship.CLI;

static class Battleship
{
    static int numberOfRounds = 1;

    public static void Start()
    {
        var (playerName1, playerName2) = RequestPlayerNames();
        var (initialPositions1, initialPositions2) = RequestInitialPositions(
            playerName1,
            playerName2
        );
        var (player1, player2) = CreatePlayers(
            playerName1,
            playerName2,
            initialPositions1,
            initialPositions2
        );

        GameLoop(player1, player2);
    }

    static (string name1, string name2) RequestPlayerNames()
    {
        var playerName1 = PlayerInteraction.AskForPlayerName(1);
        var playerName2 = PlayerInteraction.AskForPlayerName(2);

        return (playerName1, playerName2);
    }

    static (string[] initialPositions1, string[] initialPositions2) RequestInitialPositions(
        string playerName1,
        string playerName2
    )
    {
        var initialPositions1 = PlayerInteraction.AskForInitialPositions(playerName1);
        var initialPositions2 = PlayerInteraction.AskForInitialPositions(playerName2);

        return (initialPositions1, initialPositions2);
    }

    static (Player player1, Player player2) CreatePlayers(
        string playerName1,
        string playerName2,
        string[] initialPositions1,
        string[] initialPositions2
    )
    {
        var player1 = new Player { Name = playerName1, Ships = initialPositions1.ToInitialShips() };
        var player2 = new Player { Name = playerName2, Ships = initialPositions2.ToInitialShips() };

        return (player1, player2);
    }

    static void GameLoop(Player actualPlayer, Player enemyPlayer)
    {
        do
        {
            var shot = PlayerInteraction.AskForShot(actualPlayer, enemyPlayer);

            var isSunk = GameLogicService.Shot(shot, actualPlayer.Shots, enemyPlayer.Ships);
            PlayerInteraction.ShowShotStatus(actualPlayer.Name, isSunk);

            if (GameLogicService.ThereIsAWinner(enemyPlayer.Ships))
            {
                PlayerInteraction.ShowWinnerAndStats(numberOfRounds, actualPlayer, enemyPlayer);
                break;
            }

            (actualPlayer, enemyPlayer) = (enemyPlayer, actualPlayer);
            numberOfRounds++;
        } while (true);
    }
}
