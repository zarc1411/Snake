using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
namespace snakeGame
{
public class Program
{
    public static void Main(string [] args)
    {
        Console.CursorVisible = false;
        Console.BackgroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Black;

        Wall.buildTheWall();
        
        List<Point> body = new List<Point>();
        Snake.createTheSnake(body);

        Apple.putAppleOnTheScreen();

        Snake.startPlaying(body);
        
    

       
    }
}
}
