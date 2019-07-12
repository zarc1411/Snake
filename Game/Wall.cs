using System;

namespace snakeGame
{
    class Wall
    {
        public static void buildTheWall()
        {
            for(int i = 1 ; i < 41 ; i++)
            {
                Console.SetCursorPosition(1,i);
                Console.Write("#");
                Console.SetCursorPosition(70 , i);
                Console.Write("#");
            }
            for(int i = 1 ; i<71 ; i++ )
            {
                Console.SetCursorPosition(i,1);
                Console.Write("#");
                Console.SetCursorPosition(i,40);
                Console.Write("#");
            }
        }
    }
}