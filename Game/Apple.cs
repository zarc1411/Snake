using System;
using System.Drawing;
using System.Collections.Generic;
namespace snakeGame
{
    class Apple
    {
        static int appleXPosition = 0;
        public static int AppleXPosition
        {
            get
            {
                return appleXPosition;
            }
        }
        static int appleYPosition = 0;
        public static int AppleYPosition
        {
            get
            {
                return appleYPosition;
            }
        }

        static int applesEaten = 0;
        public static int ApplesEaten
        {
            get
            {
                return applesEaten;
            }
            set
            {
                applesEaten = value;
            }
        }
        Apple apple = new Apple();
        public static void putAppleOnTheScreen(List<Point> snakeBody)
        {
            generateApple(snakeBody);
            Console.SetCursorPosition(appleXPosition , appleYPosition);
            Console.Write((char)64);
        }
        static void generateApple(List<Point> snakeBody)
        {
            Random apple = new Random();
            bool appleDoesntOverlapWithSnake = true;
            do
            {
                appleXPosition = apple.Next(2,68);
                appleYPosition = apple.Next(2,38);
                foreach(Point point in snakeBody)
                {
                    if(point.X == appleXPosition && point.Y == AppleYPosition)
                    {
                        appleDoesntOverlapWithSnake = true;
                        break;
                    }
                    else appleDoesntOverlapWithSnake = false;

                }
            }while(appleDoesntOverlapWithSnake);

        }
    }
}