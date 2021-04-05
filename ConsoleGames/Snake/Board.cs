using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
  class Board
  {
    public bool IsAlive { get; private set; }

    readonly Cell[,] cells;
    readonly int width;
    readonly int height;
    readonly Snake snake;
    FoodCell food;

    public Board(int width, int height, Snake snake)
    {
      IsAlive = true;
      cells = new Cell[width, height];
      this.width = width;
      this.height = height;
      this.snake = snake;
      InitializeField();
    }

    private void UpdateCells()
    {
      CreateAllEmptyCells();
      AddSnakePosition();
      AddFoodPosition();
    }

    private void AddFoodPosition()
    {
      cells[food.Position.X, food.Position.Y] = food;
    }

    private void AddSnakePosition()
    {
      foreach (var cell in snake.GetAllCells())
      {
        cells[cell.Position.X, cell.Position.Y] = cell;
      }
    }

    private void PlaceFoodAtRandomPosition()
    {
      var allCanBeMovedToCells = new List<Cell>();
      foreach (var cell in cells)
      {
        if (cell.CanBeMovedTo())
        {
          allCanBeMovedToCells.Add(cell);
        }
      }
      var foodCellIndex = new Random().Next(allCanBeMovedToCells.Count);
      food = new FoodCell(new Coordinate(allCanBeMovedToCells[foodCellIndex].Position.X, allCanBeMovedToCells[foodCellIndex].Position.Y));
      AddFoodPosition();
    }

    private void InitializeField()
    {
      CreateEnvironmentCells();
      CreateAllEmptyCells();
      AddSnakePosition();
      PlaceFoodAtRandomPosition();
    }

    private void CreateAllEmptyCells()
    {
      for (int x = 1; x < width - 1; x++)
      {
        for (int y = 1; y < height - 1; y++)
        {
          if (!(cells[x,y] is EnvironmentCell)) // Keep previously defined environment cells. This allows for defining labyrinths, etc.
          {
            cells[x, y] = new EmptyCell(new Coordinate(x, y));
          }
        }
      }
    }

    /// <summary>
    /// Create environment cells, which can be used to create custom labyrinths, etc.
    /// </summary>
    protected virtual void CreateEnvironmentCells()
    {
      for (int x = 0; x < width; x++)
      {
        if (x == 0 || x == width - 1)
        {
          for (int y = 0; y < height; y++)
          {
            cells[x, y] = CreateEnvironmentCell(x, y);
          }
        }
        else
        {
          cells[x, 0] = CreateEnvironmentCell(x, 0);
          cells[x, height - 1] = CreateEnvironmentCell(x, height - 1);
        }
      }
    }

    protected EnvironmentCell CreateEnvironmentCell(int x, int y) => new EnvironmentCell(new Coordinate(x, y));

    public void Move(Direction direction)
    {
      var targetPosition = snake.CalculateTargetPosition(direction);
      var targetCell = cells[targetPosition.X, targetPosition.Y];
      if (targetCell.CanBeMovedTo())
      {
        snake.MoveTo(targetCell);
        if (targetCell.ContainsFood())
        {
          PlaceFoodAtRandomPosition();
        }
      }
      else
      {
        IsAlive = false;
      }
    }

    public void Move()
    {
      Move(snake.GetCurrentDirection());
    }

    public string GetVisualization()
    {
      UpdateCells();
      var result = new StringBuilder();
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          result.Append(cells[x, y].GetVisualization());
        }
        result.Append(Environment.NewLine);
      }
      return result.ToString();
    }
  }
}
