using System;
using System.Collections.Generic;
using System.Text;

namespace Vines
{
    public partial class Grid
    {
        public void grow(int x, int y, bool start = false)
        {
            
            if (Char.Equals(data[x, y], '^')) { checkUp(x, y, 0, start); }
            if (Char.Equals(data[x, y], 'v')) { checkDown(x, y, 0, start); }
            if (Char.Equals(data[x, y], '<')) { checkLeft(x, y, 0, start); }
            if (Char.Equals(data[x, y], '>')) { checkRight(x, y, 0, start); }

            if (start)
            {
                checkUp(x, y, 0, start);
            }
        }

        public void checkUp(int x, int y, int check, bool start = false)
        {
            if (check >= 4) { die(x, y); return; }
            int c = check;

            if (y == 0)
            {
                upBlocked(x, y, c, start);
            }
            else
            {
                if (Char.Equals(data[x, y - 1], ' '))
                {
                    if (!start)
                    {
                        data[x, y] = '|';
                    }
                    data[x, y - 1] = '[';

                }
                else if (Char.Equals(data[x, y - 1], 'L'))
                {
                    if (!start)
                    {
                        data[x, y] = '|';
                    }
                }
                else
                {
                    upBlocked(x, y, c, start);
                }
            }
        }

        public void upBlocked(int x, int y, int check, bool start = false)
        {
            if ((Char.Equals(growingPlants, even[0])) ||
                (Char.Equals(growingPlants, even[1])) ||
                (Char.Equals(growingPlants, even[2])) ||
                (Char.Equals(growingPlants, even[3])))
            {
                checkRight(x, y, check + 1, start);
            }
            else
            {
                checkLeft(x, y, check + 1, start);
            }
        }

        public void checkDown(int x, int y, int check, bool start = false)
        {
            if (check >= 4) { die(x, y); return; }
            int c = check;

            if (y == height - 1)
            {
                downBlocked(x, y, c, start);
            }
            else
            {
                if (Char.Equals(data[x, y + 1], ' '))
                {
                    if (!start)
                    {
                        data[x, y] = '|';
                    }
                    data[x, y + 1] = ']';
                }
                else if (Char.Equals(data[x, y + 1], 'L'))
                {
                    if (!start)
                    {
                        data[x, y] = '|';
                    }
                }
                else
                {
                    downBlocked(x, y, c, start);
                }
            }
        }

        public void downBlocked(int x, int y, int check, bool start = false)
        {
            if ((Char.Equals(growingPlants, even[0])) ||
                (Char.Equals(growingPlants, even[1])) ||
                (Char.Equals(growingPlants, even[2])) ||
                (Char.Equals(growingPlants, even[3])))
            {
                checkLeft(x, y, check + 1, start);
            }
            else
            {
                checkRight(x, y, check + 1, start);
            }
        }

        public void checkRight(int x, int y, int check, bool start = false)
        {
            if (check >= 4) { die(x, y); return; }
            int c = check;

            if (x == width - 1)
            {
                rightBlocked(x, y, c, start);
            }
            else
            {
                if (Char.Equals(data[x + 1, y], ' '))
                {
                    if (!start)
                    {
                        data[x, y] = '-';
                    }
                    data[x + 1, y] = '}';
                }
                else if (Char.Equals(data[x + 1, y], 'L'))
                {
                    if (!start)
                    {
                        data[x, y] = '-';
                    }
                }
                else
                {
                    rightBlocked(x, y, c, start);
                }
            }
        }

        public void rightBlocked(int x, int y, int check, bool start = false)
        {
            if ((Char.Equals(growingPlants, even[0])) ||
                (Char.Equals(growingPlants, even[1])) ||
                (Char.Equals(growingPlants, even[2])) ||
                (Char.Equals(growingPlants, even[3])))
            {
                checkDown(x, y, check + 1, start);
            }
            else
            {
                checkUp(x, y, check + 1, start);
            }
        }

        public void checkLeft(int x, int y, int check, bool start = false)
        {
            if (check >= 4) { die(x, y); return; }
            int c = check;

            if (x == 0)
            {
                leftBlocked(x, y, c, start);
            }
            else
            {
                if (Char.Equals(data[x - 1, y], ' '))
                {
                    if (!start)
                    {
                        data[x, y] = '-';
                    }
                    data[x - 1, y] = '{';

                }
                else if (Char.Equals(data[x - 1, y], 'L'))
                {
                    if (!start)
                    {
                        data[x, y] = '-';
                    }
                }
                else
                {
                    leftBlocked(x, y, c, start);
                }
            }
        }

        public void leftBlocked(int x, int y, int check, bool start = false)
        {
            if ((Char.Equals(growingPlants, even[0])) ||
                (Char.Equals(growingPlants, even[1])) ||
                (Char.Equals(growingPlants, even[2])) ||
                (Char.Equals(growingPlants, even[3])))
            {
                checkUp(x, y, check + 1, start);
            }
            else
            {
                checkDown(x, y, check + 1, start);
            }
        }
    }
}
