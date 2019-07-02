using System;

namespace TwoZeroFourEight
{
    class Program 
    {
        public static void Main()
        {
            Random randNum = new Random();
            int initialNumOne = randNum.Next(1,15);
            int initialNumTwo = 0;
            while(true)
            {
               initialNumTwo = randNum.Next(0,15);
               if(initialNumOne != initialNumTwo)
               break;
            }
            
            Console.WriteLine("WELCOME!!!");
 
            
            Input ob2 = new Input();
            Grid.randomIndexes(initialNumOne , initialNumTwo);
            Grid.printTheGrid();

            ConsoleKeyInfo key;
          
            
            Console.WriteLine("Please enter UP/DOWN/LEFT/RIGHT");

            do
            {
                key = Console.ReadKey(true);

                if(key.Key == ConsoleKey.UpArrow)
                {
                  ob2.moveNumbersLeftOrUp(15,12,12,4,1);
                 // Console.ReadKey();
                }
                else if(key.Key == ConsoleKey.DownArrow)
                {
                  //ob2.moveNumbersDown();
                  ob2.moveNumbersRightOrDown(0,4,12,4,1);
                }
                else if(key.Key == ConsoleKey.LeftArrow)
                {
                  ob2.moveNumbersLeftOrUp(15,0,3,1,4);
                }
                else if(key.Key == ConsoleKey.RightArrow)
                {
                  ob2.moveNumbersRightOrDown(0,16,3,1,4);
                }
            }while(key.Key != ConsoleKey.X);
        }
    }
}