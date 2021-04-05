namespace Snake
{
  abstract class Cell
  {
    public Coordinate Position { get; }
    string visualization;

    public Cell(Coordinate position, string visualization)
    {
      this.Position = position;
      this.visualization = visualization;
    }

    public string GetVisualization() => visualization;
    abstract public bool CanBeMovedTo();
    abstract public bool ContainsFood();
  }
}
