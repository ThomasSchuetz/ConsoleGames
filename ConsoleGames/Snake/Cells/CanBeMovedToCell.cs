namespace Snake
{
  abstract class CanBeMovedToCell : Cell
  {
    public CanBeMovedToCell(Coordinate position, string visualization) : base(position, visualization) { }
    public override bool CanBeMovedTo() => true;
  }
}
