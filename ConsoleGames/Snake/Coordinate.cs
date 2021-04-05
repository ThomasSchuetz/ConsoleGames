namespace Snake
{
  class Coordinate
  {
    public int X { get; set; }
    public int Y { get; set; }
    public Coordinate(int x, int y)
    {
      X = x;
      Y = y;
    }
    public Coordinate GetNeighbor(Direction direction)
    {
      return direction switch
      {
        Direction.Left => new Coordinate(X - 1, Y),
        Direction.Right => new Coordinate(X + 1, Y),
        Direction.Up => new Coordinate(X, Y - 1),
        Direction.Down => new Coordinate(X, Y + 1),
        _ => throw new System.ArgumentOutOfRangeException($"Unknown current direction {direction}"),
      };
    }
  }
}
