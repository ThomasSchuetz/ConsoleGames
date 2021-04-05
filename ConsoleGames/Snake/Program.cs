using System;
using System.Threading;

namespace Snake
{
  class Program
  {
    static void Main(string[] args)
    {
      int width = 20;
      int height = 20;
      var snake = new Snake(new Coordinate(5, 10));
      var board = new Board(width, height, snake);

      while (board.IsAlive)
      {
        Thread.Sleep(200);
        ConsoleKeyInfo input;
        if (Console.KeyAvailable)
        {
          input = Console.ReadKey(true); //intercept = true (don't print char on console)
                                         //If the directionMap doesn't find a direction for the character 
                                         //the user pressed it throws an exception.
                                         //Wrapping this in a try/catch allows us to ignore all non-direction keys
                                         //except Escape, which quits the game.
          try
          {
            var direction = DirectionConverter.ConvertFromKeyInput(input.Key);
            board.Move(direction);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(board.GetVisualization());
            Console.SetCursorPosition(0, 0);
          }
          catch (ArgumentOutOfRangeException)
          {
            // Do nothing if an undefined key was pressed
          }
        }
        else
        {
          board.Move();
          Console.SetCursorPosition(0, 0);
          Console.WriteLine(board.GetVisualization());
          Console.SetCursorPosition(0, 0);
        }
      }
      Console.SetCursorPosition(0, height + 2);
      Console.WriteLine("The snake died!");
      Console.ReadLine();
    }
  }
}