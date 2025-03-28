using _03_Battleship.Library.Models;

namespace _03_Battleship.Library.Helpers;

public static class ShipHelper
{
    public static Dictionary<string, ShipStatus> GetStatusesDictionary(this Ship[] ships)
    {
        var statuses = new Dictionary<string, ShipStatus>();
        foreach (var ship in ships)
        {
            statuses.Add(ship.Position, ship.Status);
        }

        return statuses;
    }
}
