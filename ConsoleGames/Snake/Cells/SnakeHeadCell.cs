namespace Snake
{
  class SnakeHeadCell : CannotBeMovedToCell
  {
    public SnakeHeadCell(Coordinate position, string visualization) : base(position, visualization) { }
  }
}
