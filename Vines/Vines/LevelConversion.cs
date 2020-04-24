using System;
using System.Collections.Generic;
using System.Text;

namespace Vines
{
    public partial class MainGameLoop
    {
        public char[,] levelToGrid(string[] rawData)
        {
            int x = rawData[0].Length;
            int y = rawData.Length;

            char[,] r = new char[x,y];

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
