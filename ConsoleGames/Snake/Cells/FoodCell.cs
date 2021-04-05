namespace Snake
{
  class FoodCell : CanBeMovedToCell
  {
    public FoodCell(Coordinate position) : base(position, "*") { }
    public override bool ContainsFood() => true;
  }
}
