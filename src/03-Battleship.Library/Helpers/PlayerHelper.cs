using _03_Battleship.Library.Models;

namespace _03_Battleship.Library.Helpers;

public static class PlayerHelper
{
    public static Ship[] ToInitialShips(this string[] initialPositions)
    {
        var gridSpots = new Ship[initialPositions.Length];
        for (int i = 0; i < initialPositions.Length; i++)
        {
            gridSpots[i] = new Ship { Position = initialPositions[i], Status = ShipStatus.Alive };
        }

        return gridSpots;
    }
}
