using System;

namespace snakeGame
{
    class Menu
    {
        public static void startTheGame()
        {
 
            Console.SetCursorPosition(35,30);
            Console.WriteLine("START");
            Console.SetCursorPosition(35 , 33);
            Console.WriteLine("HELP");
            Console.SetCursorPosition(35, 36);
            Console.WriteLine("EXIT");
            Console.SetCursorPosition(33 , 29);
            Console.Write("#########");
            Console.Write("#       #");
            Console.Write("#########");

            
        }

        
    }
}