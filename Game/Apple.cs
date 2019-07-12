using System;

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
        public static void putAppleOnTheScreen()
        {
            generateApple();
            Console.SetCursorPosition(appleXPosition , appleYPosition);
            Console.Write((char)64);
        }
        static void generateApple()
        {
            Random apple = new Random();
            appleXPosition = apple.Next(2,68);
            appleYPosition = apple.Next(2,38);
        }
    }
}