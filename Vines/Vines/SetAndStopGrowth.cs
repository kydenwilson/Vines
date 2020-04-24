using System;
using System.Collections.Generic;
using System.Text;

namespace Vines
{
    public partial class Grid
    {
        public bool checkPlants()
        {
            bool r = false;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    for (int k = 0; k < vines.Length; k++)
                    {
                        if (Char.Equals(data[j, i], vines[k]))
                        {
                            r = true;
                            return r;
                        }
                    }
                }
            }
            return r;
        }

        public void startGrowth()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (Char.Equals(data[j, i], growingPlants))
                    {
                        grow(j, i, true);
                    }
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    for (int k = 0; k < tempTips.Length; k++)
                    {
                        if (Char.Equals(data[j, i], tempTips[k]))
                        {
                            data[j, i] = growable[k];
                        }
                    }
                }
            }
        }

        public bool checkGrowth()
        {
            bool r = false;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    for (int k = 0; k < growable.Length; k++)
                    {
                        if (Char.Equals(data[j, i], growable[k]))
                        {
                            grow(j, i);
                            r = true;
                        }
                    }
                }
            }

            if (r)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        for (int k = 0; k < tempTips.Length; k++)
                        {
                            if (Char.Equals(data[j, i], tempTips[k]))
                            {
                                data[j, i] = growable[k];
                            }
                        }
                    }
                }
            }

            return r;
        }


        public void clearGrowingPlants()
        {
            if (Char.Equals(growingPlants, '0')) { }
            else
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (Char.Equals(data[j, i], growingPlants))
                        {
                            data[j, i] = '$';
                        }
                    }
                }
                growingPlants = '0';
            }
        }

        public void die(int x, int y) { data[x, y] = '!'; }

        public bool areDeadPlants()
        {
            bool r = false;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (Char.Equals(data[j, i], '!'))
                    {
                        r = true;
                        return r;
                    }
                }
            }
            return r;
        }
    }
}
