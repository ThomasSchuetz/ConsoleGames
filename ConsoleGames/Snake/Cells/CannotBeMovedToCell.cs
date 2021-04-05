namespace Snake
{
  abstract class CannotBeMovedToCell : Cell
  {
    public CannotBeMovedToCell(Coordinate position, string visualization) : base(position, visualization) { }
    public override bool CanBeMovedTo() => false;
    public override bool ContainsFood() => false;
  }
}
