using _03_Battleship.Library.Models;

namespace _03_Battleship.Library.Services;

public static class GameLogicService
{
    public static bool Shot(string shot, List<string> previousShots, Ship[] enemyShips)
    {
        previousShots.Add(shot);

        var enemyShip = enemyShips.FirstOrDefault(ship => ship.Position == shot);
        if (enemyShip is not null)
        {
            enemyShip.Status = ShipStatus.Sunk;
            return true;
        }

        return false;
    }

    public static bool ThereIsAWinner(Ship[] enemyShips) =>
        enemyShips.Count(ship => ship.Status == ShipStatus.Sunk) == 5;
}
