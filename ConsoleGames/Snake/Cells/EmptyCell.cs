namespace Snake
{
  class EmptyCell : CanBeMovedToCell
  {
    public EmptyCell(Coordinate position) : base(position, " ") { }
    public override bool ContainsFood() => false;
  }
}
