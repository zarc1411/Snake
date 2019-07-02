using System;
using System.Linq;
namespace TwoZeroFourEight
{
    class Input
    {
        Game game = new Game();
        public bool isPowerOfTwo(int x)
        {
            return (x!=0) && ((x & (x-1)) == 0);
        }

        void checkFromRightToLeft(int i , int incrementVal)
        {
            int sum = 0; 
            int zeroChecker = 0;
            
            sum = Grid.array[i] + Grid.array[i-incrementVal];
            if(isPowerOfTwo(sum))
            {
                Grid.array[i-incrementVal] = sum;
                zeroChecker = Grid.array[i];
                Grid.array[i] = 0;
                if(zeroChecker!=0 && Grid.array[i-incrementVal]/zeroChecker == 2)
                {
                    i = i - incrementVal;
                    game.Score = game.Score + sum;
                }
                if(sum == 2048)
                {
                    Console.WriteLine("CONGRATULATIONS YOU HAVE WON THE GAME");
                    Environment.Exit(0);
                }
            }
        }

        void checkFromLeftToRight(int i , int incrementVal)
        {
            int sum = 0;
            int zeroChecker = 0;
            sum = Grid.array[i] + Grid.array[i+incrementVal];
            if(isPowerOfTwo(sum))
            {
                Grid.array[i+incrementVal] = sum;
                zeroChecker = Grid.array[i];
                Grid.array[i] = 0;
                if(zeroChecker!=0 && Grid.array[i+incrementVal]/zeroChecker == 2)
                {
                    i = i + incrementVal;
                    game.Score = game.Score + sum;
                }
                if(sum == 2048)
                {
                    Console.WriteLine("CONGRATULATIONS YOU HAVE WON THE GAME!!!");
                    Environment.Exit(0);
                }
            }
        }
        public void moveNumbersRightOrDown(int initIndex , int whileLimit , int forLimit , int incrementVal , int indexIncrmntVal)
        {
            int num = 0;
            int count = 0;
            //For choosing the number that we are gonna use for comparing with other numbers
            if(Grid.array[initIndex] == 0)
            num = Grid.array[initIndex+incrementVal];
            else
            num = Grid.array[initIndex];
            while(initIndex < whileLimit) 
            {
                /* For checking if there are repeating elements, for example ...[2][2][2]
                or [2][2][2][2] */ 
                for(int k = initIndex; k<=initIndex + forLimit ; k = k + incrementVal)
                {
                    if(num == Grid.array[k])
                    count++;
                }
                /*This means that there are repeating elements , so we would have to do the shifting 
                from opposite direction */
                if(count>=3)
                {
                    for(int i = initIndex + forLimit ; i>initIndex ; i = i - incrementVal)
                    {
                       checkFromRightToLeft(i , incrementVal);
                    }
                }
                /*If there are no repeating elements then we just need to move in the direction 
                the player pressed*/
                else
                {
                    for(int i = initIndex; i<initIndex + forLimit ; i = i + incrementVal)
                    {
                       checkFromLeftToRight(i , incrementVal);
                    }
                }
                
                int j = initIndex;
                /* This loop is for moving any zeroes in the middle to the extreme left , [8][0][8][0] gets converted
                to [0][0][8][8]*/
                while((j + forLimit)>initIndex)
                {
                    for(int i =  initIndex + forLimit ; i>initIndex; i = i - incrementVal)
                    {
                        if(Grid.array[i] == 0)
                        {
                            int temp = Grid.array[i];
                            Grid.array[i] = Grid.array[i-incrementVal];
                            Grid.array[i-incrementVal] = temp;
                        }
                    }
                    j = j - incrementVal;
                }
             
                 initIndex = initIndex + indexIncrmntVal;
               
            }
       
            game.generateTwoOrFourRandomly();
        
            Grid.printTheGrid();
            Console.WriteLine("The score is " + game.Score);
        }

        public void moveNumbersLeftOrUp(int initIndex , int whileLimit , int forLimit , int incrementVal , int indexIncrmntVal)
        {
            int num = 0;
            int count = 0;
            //For choosing the number that we are gonna use for comparing with other numbers
            if(Grid.array[initIndex] == 0)
            num = Grid.array[initIndex-incrementVal];
            else
            num = Grid.array[initIndex];
            while(initIndex >= whileLimit) 
            {
                /* For checking if there are repeating elements, for example ...[2][2][2]
                or [2][2][2][2] */
                for(int k = initIndex; k>=initIndex - forLimit ; k = k - incrementVal)
                {
                    if(num == Grid.array[k])
                    count++;
                }
                /*This means that there are repeating elements , so we would have to do the shifting 
                from opposite direction */
                if(count>=3)
                {
                    for(int i = initIndex - forLimit ; i<initIndex ; i = i + incrementVal)
                    {
                        checkFromLeftToRight(i , incrementVal);
                    }
                }
                /*If there are no repeating elements then we just need to move in the direction 
                the player pressed*/
                else
                {
                    for(int i = initIndex; i>initIndex - forLimit ; i = i - incrementVal)
                    {
                        checkFromRightToLeft(i , incrementVal);
                    }
                }
                
                
                int j = initIndex;
                /* This loop is for moving any zeroes in the middle to the extreme left , [8][0][8][0] gets converted
                to [0][0][8][8]*/
                while((j - forLimit)<initIndex)
                {
                    for(int i =  initIndex - forLimit ; i<initIndex; i = i + incrementVal)
                    {
                        if(Grid.array[i] == 0)
                        {
                            int temp = Grid.array[i];
                            Grid.array[i] = Grid.array[i+incrementVal];
                            Grid.array[i+incrementVal] = temp;
                        }
                    }
                    j = j + incrementVal;
                }
                 initIndex = initIndex - indexIncrmntVal;
               
            }
            
            game.generateTwoOrFourRandomly();
          
            Grid.printTheGrid();
            Console.WriteLine("The score is " + game.Score);
        }



    }
}