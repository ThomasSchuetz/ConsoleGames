namespace Snake
{
  class EnvironmentCell : CannotBeMovedToCell
  {
    public EnvironmentCell(Coordinate position) : base(position, "#") { }
  }
}
