using System;
using System.Collections.Generic;
using System.Text;

namespace Vines
{
    public partial class Grid
    {
        int framePause = 500;
        bool pause = true;

        char[,] data;
        string[] rawData;

        int width;
        int height;

        public char growingPlants = '0';

        char[] growable = new char[4] {'^','v', '<', '>' };
        char[] tempTips = new char[4] {'[',']','{','}'};
        char[] even = new char[4] { '2', '4', '6', '8' };        
        char[] vines = new char[9] { '1', '2', '3', '4','5','6','7','8','9' };        

        public Grid(char[,] level, string[] dataRaw)
        {            
            data = level;
            rawData = dataRaw;
            width = data.GetLength(0);
            height = data.GetLength(1);
        }

        public void resetLevel()
        {
            data = levelToGrid(rawData);
            growingPlants = '0';
            draw();
        }

        public char getPlant()
        {
            char input = Interface.GetNumber();
            if (char.Equals(input, '0'))
            {
                Console.Write("\n Invalid Input, please try again:  ");
                return getPlant();
            }

            for (int i = 0; i < height; i ++)
            {
                for (int j = 0; j < width; j++)
                {                    
                    if (Char.Equals(data[j,i], input))
                    {
                        char r = input;
                        return r;
                    }
                }
            }

            Console.Write("\n The number " + input + " does not have any valid vines. Please try again:  ");

            return getPlant();
        }

        public void draw(bool clear = true)
        {
            if (clear) { Console.Clear(); }

            Console.Write("\n");

            Console.Write("  ");
            for (int i = 0; i < width; i++)
            {
                if (i == 0) { Console.Write("x"); }
                Console.Write("x");               
            }
            Console.Write("x");

            Console.Write("\n");

            for (int i = 0; i < height; i++)
            {
                Console.Write("  x");
                for (int j = 0; j < width; j++)
                {                   
                    Console.Write(data[j,i]);
                }
                Console.Write("x\n");
            }

            Console.Write("  ");
            for (int i = 0; i < width; i++)
            {
                if (i == 0) { Console.Write("x"); }
                Console.Write("x");                
            }
            Console.Write("x\n");
            Console.Write("\n\n");
        }

        public char[,] levelToGrid(string[] rawData)
        {
            int x = rawData[0].Length;
            int y = rawData.Length;

            char[,] r = new char[x, y];

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    r[j, i] = rawData[i][j];
                }
            }

            return r;
        }
    }
}
