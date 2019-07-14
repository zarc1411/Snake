using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
namespace snakeGame
{
    class Snake
    {
        private static decimal speed = 150m;
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
            Console.Write((char)2);
        }
        private static void moveTheSnake(List<Point> snakeBody)
        {
            bool gameIsStillRunning = true;
            bool youPressTheRightKeys = false;
            char snakeDirection = ' ';
            int numberOfMove = 0;
            //Assigns point a default value, use this if you are not sure about the default value of a type
            Point nextHead = default(Point);
            
            ConsoleKey input = Console.ReadKey(true).Key;

            if(input == ConsoleKey.DownArrow)
            snakeBody.Reverse();
                    
            do
            {
                Point last = snakeBody[snakeBody.Count - 1];
                Console.SetCursorPosition(last.X , last.Y);
                snakeBody.RemoveAt(snakeBody.Count - 1);
                Console.Write(" ");
                   
                nextHead = snakeBody[0];
                do
                {
                    if(input == ConsoleKey.UpArrow || input == ConsoleKey.W)
                    {
                        nextHead = new Point(nextHead.X , nextHead.Y-1);
                        SetCursorAtPositionXandYfor(nextHead);
                        snakeDirection = 'U';
                        youPressTheRightKeys = false;
                        numberOfMove++;
                    }
                    else if(input == ConsoleKey.DownArrow || input == ConsoleKey.S)
                    {
                        nextHead = new Point(nextHead.X, nextHead.Y+1);
                        SetCursorAtPositionXandYfor(nextHead);
                        snakeDirection = 'D';
                        youPressTheRightKeys = false;
                        numberOfMove++;
                    }
                    else if(input == ConsoleKey.LeftArrow || input == ConsoleKey.A)
                    {
                        nextHead = new Point(nextHead.X -1 , nextHead.Y);
                        SetCursorAtPositionXandYfor(nextHead);
                        snakeDirection = 'L';
                        youPressTheRightKeys = false;
                        numberOfMove++;
                    }
                    else if(input == ConsoleKey.RightArrow || input == ConsoleKey.D)
                    {
                        nextHead = new Point(nextHead.X+1 , nextHead.Y);
                        SetCursorAtPositionXandYfor(nextHead);
                        snakeDirection = 'R';
                        youPressTheRightKeys = false;
                        numberOfMove++;
                    }
                    else
                    {
                        if(numberOfMove == 0)
                        {
                            youPressTheRightKeys = true;
                            input = Console.ReadKey(true).Key;
                        }
                        else
                        {
                            if(snakeDirection == 'D')
                            input = ConsoleKey.DownArrow;
                            else if(snakeDirection == 'U')
                            input = ConsoleKey.UpArrow;
                            else if(snakeDirection == 'L')
                            input = ConsoleKey.LeftArrow;
                            else if(snakeDirection == 'R')
                            input = ConsoleKey.RightArrow;
                        }
                    }
                }while(youPressTheRightKeys);
                //To in_ert this new head
                snakeBody.Insert(0,nextHead);
        
                if(Console.KeyAvailable)
                {   
                    input = Console.ReadKey(true).Key;
                    // This is to make sure that I cant go backwards when the snake is going upwards and so on..
                    if((input == ConsoleKey.UpArrow || input == ConsoleKey.W) && snakeDirection == 'D' )
                    input = ConsoleKey.DownArrow;
                    else if((input == ConsoleKey.DownArrow || input == ConsoleKey.S) && snakeDirection == 'U')
                    input = ConsoleKey.UpArrow;
                    else if((input == ConsoleKey.RightArrow || input == ConsoleKey.D) && snakeDirection == 'L')
                    input = ConsoleKey.LeftArrow;
                    else if((input == ConsoleKey.LeftArrow || input == ConsoleKey.A) && snakeDirection == 'R')
                    input = ConsoleKey.RightArrow;
                }
                //If the snake eats the Apple   
                if(nextHead.X == Apple.AppleXPosition && nextHead.Y == Apple.AppleYPosition)
                {
                    Apple.ApplesEaten++;
                    Point nextTail = snakeBody[snakeBody.Count - 1];
                    //Increasing the snake's body
                    if(snakeDirection == 'U')
                    nextTail = new Point(nextTail.X , nextTail.Y + 1);
                    else if(snakeDirection == 'D')
                    nextTail = new Point(nextTail.X , nextTail.Y-1);
                    else if(snakeDirection == 'L')
                    nextTail = new Point(nextTail.X + 1 , nextTail.Y);
                    else if(snakeDirection == 'R')
                    nextTail = new Point(nextTail.X - 1 , nextTail.Y);
        
                    snakeBody.Insert(snakeBody.Count , nextTail);

                    Apple.putAppleOnTheScreen(snakeBody);

                    Snake.speed *= 0.960m;
                }
                //If the snake touches itself
                for(int i = 2 ; i<snakeBody.Count -1 ; i++)
                {
                    if(nextHead == snakeBody[i])
                    gameIsStillRunning = false;
                }

                //if it touches the wall
                if(nextHead.X == 1 || nextHead.X == 70 || nextHead.Y == 1 || nextHead.Y == 40)
                gameIsStillRunning = false;

                Thread.Sleep(Convert.ToInt32(speed));
                //Display score
                Console.SetCursorPosition(3,42);
                Console.Write("SCORE = " + Apple.ApplesEaten * 100);
                Console.SetCursorPosition(53,42);
                Console.Write("GAME speed = " + (int)Snake.speed);

            }while(gameIsStillRunning);
        }
    }
}