using System;
using System.Collections.Generic;

namespace Snake
{
  class Snake
  {
    private List<Cell> Position { get; } // Tail: 0, Head: Last index

    public Snake(Coordinate startPosition, int initialLength = 5)
    {
      Position = new List<Cell>();
      for (int i = 0; i < initialLength; i++)
      {
        Position.Add(new SnakeBaseCell(new Coordinate(startPosition.X + i, startPosition.Y)));
      }
    }

    public void MoveTo(Cell target)
    {
      if (target.CanBeMovedTo())
      {
        Position.Add(target);
        if (!target.ContainsFood())
        {
          Position.RemoveAt(0);
        }
      }
      else
      {
        throw new System.Exception("Cannot move to occupied field!");
      }
    }

    public Coordinate GetHeadPosition() => Position[Position.Count - 1].Position;

    public List<Cell> GetAllCells()
    {
      var currentDirection = GetCurrentDirection();
      var result = new List<Cell>();
      for (int i = 0; i < Position.Count-1; i++)
      {
        result.Add(new SnakeBaseCell(Position[i].Position));
      }
      result.Add(SnakeHeadCellFactory.CreateSnakeHeadCell(GetHeadPosition(), currentDirection));
      return result;
    }

    public Direction GetCurrentDirection()
    {
      var headPosition = GetHeadPosition();
      var previousHeadPosition = Position[Position.Count - 2].Position;
      if (headPosition.X - previousHeadPosition.X > 0)
      {
        return Direction.Right;
      }
      else if (headPosition.X - previousHeadPosition.X < 0)
      {
        return Direction.Left;
      }
      else // no change in X position
      {
        if (headPosition.Y - previousHeadPosition.Y > 0)
        {
          return Direction.Down;
        }
        else
        {
          return Direction.Up;
        }
      }
    }

    public Coordinate CalculateTargetPosition(Direction direction)
    {
      var currentPosition = GetHeadPosition();
      var currentDirection = GetCurrentDirection();

      var targetPosition = currentPosition.GetNeighbor(currentDirection);

      switch (direction)
      {
        case Direction.Left:
          if ((currentDirection == Direction.Down) || (currentDirection == Direction.Up))
          {
            targetPosition = new Coordinate(currentPosition.X - 1, currentPosition.Y);
          }
          break;
        case Direction.Right:
          if ((currentDirection == Direction.Down) || (currentDirection == Direction.Up))
          {
            targetPosition = new Coordinate(currentPosition.X + 1, currentPosition.Y);
          }
          break;
        case Direction.Up:
          if ((currentDirection == Direction.Left) || (currentDirection == Direction.Right))
          {
            targetPosition = new Coordinate(currentPosition.X, currentPosition.Y - 1);
          }
          break;
        case Direction.Down:
          if ((currentDirection == Direction.Left) || (currentDirection == Direction.Right))
          {
            targetPosition = new Coordinate(currentPosition.X, currentPosition.Y + 1);
          }
          break;
        default:
          throw new ArgumentOutOfRangeException($"Unknown target direction {direction}");
      }

      return targetPosition;
    }
  }
}
