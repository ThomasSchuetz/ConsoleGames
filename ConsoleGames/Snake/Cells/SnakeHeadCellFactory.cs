namespace Snake
{
  static class SnakeHeadCellFactory
  {
    public static SnakeHeadCell CreateSnakeHeadCell(Coordinate position, Direction snakeDirection)
    {
      return snakeDirection switch
      {
        //Direction.Left => new SnakeHeadCell(position, "\u2B9C"),
        //Direction.Right => new SnakeHeadCell(position, "\u2B9E"),
        //Direction.Up => new SnakeHeadCell(position, "\u2B9D"),
        //Direction.Down => new SnakeHeadCell(position, "\u2B9F"),
        Direction.Left => new SnakeHeadCell(position, "<"),
        Direction.Right => new SnakeHeadCell(position, ">"),
        Direction.Up => new SnakeHeadCell(position, "^"),
        Direction.Down => new SnakeHeadCell(position, "v"),
        _ => throw new System.ArgumentOutOfRangeException("Undefined direction!"),
      };
    }
  }
}
