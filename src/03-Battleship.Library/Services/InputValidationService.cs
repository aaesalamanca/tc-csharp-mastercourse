using System.Diagnostics.CodeAnalysis;

namespace _03_Battleship.Libray.Services;

public static class InputValidationService
{
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

        if (!int.TryParse(initialShipPosition[1].ToString(), out int parsedShipPosition))
        {
            return false;
        }

        switch (parsedShipPosition)
        {
            case < 0
            or > 4:
                return false;
        }

        return !initialPositions.Contains(initialShipPosition);
    }
}
