using System.Diagnostics.CodeAnalysis;
using _03_Battleship.Library.Models;

namespace _03_Battleship.Library.Services;

public static class InputValidationService
{
    public static bool IsValidPlayerName([NotNullWhen(true)] string? playerName) =>
        !string.IsNullOrWhiteSpace(playerName);

    public static bool IsValidInitialShipPosition(
        [NotNullWhen(true)] string? initialShipPosition,
        List<string> initialPositions
    )
    {
        if (string.IsNullOrWhiteSpace(initialShipPosition))
        {
            return false;
        }

        if (initialShipPosition.Length != 2)
        {
            return false;
        }

        switch (initialShipPosition[0])
        {
            case < 'A'
            or > 'E':
                return false;
        }

        if (!int.TryParse(initialShipPosition[1].ToString(), out int parsedShipPositionColumn))
        {
            return false;
        }

        switch (parsedShipPositionColumn)
        {
            case < 0
            or > 4:
                return false;
        }

        return !initialPositions.Contains(initialShipPosition);
    }

    public static bool IsValidShot([NotNullWhen(true)] string? shot, Ship[] enemyShips)
    {
        if (string.IsNullOrWhiteSpace(shot))
        {
            return false;
        }

        if (shot.Length != 2)
        {
            return false;
        }

        switch (shot[0])
        {
            case < 'A'
            or > 'E':
                return false;
        }

        if (!int.TryParse(shot[1].ToString(), out int parsedShotColumn))
        {
            return false;
        }

        switch (parsedShotColumn)
        {
            case < 0
            or > 4:
                return false;
        }

        if (enemyShips.Any(ship => ship.Position == shot && ship.Status == ShipStatus.Sunk))
        {
            return false;
        }

        return true;
    }
}
