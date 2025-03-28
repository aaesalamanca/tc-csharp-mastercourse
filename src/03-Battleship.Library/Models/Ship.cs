namespace _03_Battleship.Library.Models;

public class Ship
{
    public required string Position { get; init; }
    public required ShipStatus Status { get; set; }
}
