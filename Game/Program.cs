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
        Console.BackgroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;

        Wall.buildTheWall();
        
        List<Point> body = new List<Point>();
        Snake.createTheSnake(body);

        Snake.startPlaying(body);
        
    

       
    }
}
}
