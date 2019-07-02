using System;
using System.Linq;
namespace TwoZeroFourEight
{
    class Game
    {
        private int score;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
        
        public void generateTwoOrFourRandomly()
        {
            Random rpos = new Random();
            Random rno = new Random();
            int count = 0;
            int twoOrFour = rno.Next(0,1);
            while(true)
            {
                if(!(Grid.array.Contains(0)))
                {
                    if(doesntHaveMoves())
                    {
                        Console.WriteLine("NO MOVES LEFT.SORRY TO SAY MISTER , YOU LOST THE GAME :(");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    while(count<16)
                    {
                        int index = rpos.Next(0,15);
                        if(Grid.array[index] == 0)
                        {
                            if(twoOrFour == 0)
                            Grid.array[index] = 2;
                            else
                            Grid.array[index] = 4;

                            break;
                        }
                        count++;
                    }
                
                    if(count>=16)
                    {
                        for(int i = 0 ; i<16 ; i++)
                        {
                            if(Grid.array[i] == 0)
                            {
                                if(twoOrFour == 0)
                                Grid.array[i] = 2;
                                else
                                Grid.array[i] = 4;
                                break;
                            }
                        }
                    }
                    break;
                }
            }
        }
        public bool doesntHaveMoves()
        {
            Input ob  = new Input();
            bool pairableGrids = true;
            int rightIndex = 0 ; 
            while(rightIndex<16)
            {
                for(int i = rightIndex ; i<rightIndex+3 ; i++)
                {
                    int sum = Grid.array[i] + Grid.array[i+1];
                    if(ob.isPowerOfTwo(sum))
                    {
                        pairableGrids = false;
                        break;
                    }
                    else
                    pairableGrids = true;
                }
                rightIndex = rightIndex + 4;
            }
            int downIndex = 0;
            while(downIndex<4)
            {
                for(int i = downIndex ; i<downIndex + 12; i = i + 4)
                {
                    int sum = Grid.array[i] + Grid.array[i+4];
                    if(ob.isPowerOfTwo(sum))
                    {
                        pairableGrids = false;
                        break;
                    }
                    else 
                    pairableGrids = true;
                }
                downIndex++;
            }
            return pairableGrids;
        }
    }    
}