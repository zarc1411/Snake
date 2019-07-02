using System;

namespace TwoZeroFourEight
{
    class Grid
    {
      public static int [] array = new int[16];

      public static void randomIndexes(int n1 , int n2)
        {
            array[n1] = 2;
            array[n2] = 2;
        }
       public static void printTheGrid()
        {
            for(int i = 0 ; i<16 ; i++)
            {
                if((i+1)%4 == 1)
                Console.Write("|");

                if(array[i] == 0)
                Console.Write("  " + " |");
                else
                Console.Write(" " + array[i] + " |");

                if((i+1)%4 == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("-----------------");
                }
            }
        }
    }
}