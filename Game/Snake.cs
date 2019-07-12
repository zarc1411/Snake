using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
namespace snakeGame
{
    class Snake
    {
        public static void createTheSnake(List<Point> snakeBody)
        {
            for(int i = 0 ; i<5 ; i++)
            {
                snakeBody.Add(new Point(40 , i +25));
            }
            
            foreach(Point point in snakeBody)
            {
                Console.SetCursorPosition(point.X , point.Y);
                Console.Write((char)2);
            }
        }
        
        public static void startPlaying(List<Point> body)
        {
            moveTheSnake(body);
        }

        static void SetCursorAtPositionXandYfor(Point head)
        {
            Console.SetCursorPosition(head.X , head.Y);
            Console.Write("0");
        }
        private static void moveTheSnake(List<Point> snakeBody)
        {
            bool gameIsStillRunning = true;
            char flag = ' ';
            //Assigns point a default value, use this if you are not sure about the default value of a type
            Point nextHead = default(Point);
        
            ConsoleKey input = Console.ReadKey(true).Key;
            do
            {
                if(input == ConsoleKey.UpArrow|| input == ConsoleKey.DownArrow
                || input == ConsoleKey.LeftArrow|| input == ConsoleKey.RightArrow)
                {
                    //Removing the tail of the snake
                    Point last = snakeBody[snakeBody.Count - 1];
                    Console.SetCursorPosition(last.X , last.Y);
                    snakeBody.RemoveAt(snakeBody.Count - 1);
                    Console.Write(" ");

                    nextHead = snakeBody[0];
                    if(input == ConsoleKey.UpArrow)
                    {
                        nextHead = new Point(nextHead.X , nextHead.Y-1);
                        SetCursorAtPositionXandYfor(nextHead);
                        flag = 'U';
                    }
                    else if(input == ConsoleKey.DownArrow)
                    {
                        nextHead = new Point(nextHead.X, nextHead.Y+1);
                        SetCursorAtPositionXandYfor(nextHead);
                        flag = 'D';
                    }
                    else if(input == ConsoleKey.LeftArrow)
                    {
                        nextHead = new Point(nextHead.X -1 , nextHead.Y);
                        SetCursorAtPositionXandYfor(nextHead);
                        flag = 'L';
                    }
                    else if(input == ConsoleKey.RightArrow)
                    {
                        nextHead = new Point(nextHead.X+1 , nextHead.Y);
                        SetCursorAtPositionXandYfor(nextHead);
                        flag = 'R';
                    }

                    //To insert this new head
                    snakeBody.Insert(0,nextHead);
                }
                
                if(Console.KeyAvailable)
                {   
                    input = Console.ReadKey(true).Key;
                    // This is to make sure that I cant go backwards when the snake is going upwards and so on..
                    if(input == ConsoleKey.UpArrow && flag == 'D')
                    input = ConsoleKey.DownArrow;
                    else if(input == ConsoleKey.DownArrow && flag == 'U')
                    input = ConsoleKey.UpArrow;
                    else if(input == ConsoleKey.RightArrow && flag == 'L')
                    input = ConsoleKey.LeftArrow;
                    else if(input == ConsoleKey.LeftArrow && flag == 'R')
                    input = ConsoleKey.RightArrow;
                }

                if(nextHead.X == Apple.AppleXPosition && nextHead.Y == Apple.AppleYPosition)
                {
                    Apple.ApplesEaten++;
                    Apple.putAppleOnTheScreen();
                }

                //if it touches the wall
                if(nextHead.X == 1 || nextHead.X == 70 || nextHead.Y == 1 || nextHead.Y == 40)
                gameIsStillRunning = false;

                Thread.Sleep(150);

            
            }while(gameIsStillRunning);
        }
    }
}