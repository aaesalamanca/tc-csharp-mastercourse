namespace _03_Battleship.Library.Models;

public class Player
{
    public required string Name { get; init; }
    public required Ship[] Ships { get; init; }
    public List<string> Shots { get; } = [];
}
