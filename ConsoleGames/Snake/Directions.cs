using System;

namespace Snake
{
  public enum Direction
  {
    Left,
    Right,
    Up,
    Down
  }

  public static class DirectionConverter
  {
    public static Direction ConvertFromKeyInput(ConsoleKey input)
    {
      return input switch
      {
        ConsoleKey.UpArrow => Direction.Up,
        ConsoleKey.DownArrow => Direction.Down,
        ConsoleKey.LeftArrow => Direction.Left,
        ConsoleKey.RightArrow => Direction.Right,
        _ => throw new ArgumentOutOfRangeException($"Undefined key input {input}"),
      };
    }
  }
}
