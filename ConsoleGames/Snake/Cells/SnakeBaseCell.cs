namespace Snake
{
  class SnakeBaseCell : CannotBeMovedToCell
  {
    public SnakeBaseCell(Coordinate position) : base(position, "o") { }
  }
}
