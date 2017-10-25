using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    class Address
    {
        public static string ConvertFromInt(int s)
        {
            switch (s)
            {
                case 1:
                    return "A";
                case 2:
                    return "B";
                case 3:
                    return "C";
                case 4:
                    return "D";
                case 5:
                    return "E";
                case 6:
                    return "F";
                case 7:
                    return "G";
                case 8:
                    return "H";
            }
            return "Something went wrong";
        }
        public static int InverseRow(int s)
        {
            switch (s)
            {
                case 1:
                    return 8;
                case 2:
                    return 7;
                case 3:
                    return 6;
                case 4:
                    return 5;
                case 5:
                    return 4;
                case 6:
                    return 3;
                case 7:
                    return 2;
                case 8:
                    return 1;
            }
            return -1;
        }
        public static int ConvertFromChar(char c)
        {
            switch (c)
            {
                case 'A':
                    return 1;
                case 'B':
                    return 2;
                case 'C':
                    return 3;
                case 'D':
                    return 4;
                case 'E':
                    return 5;
                case 'F':
                    return 6;
                case 'G':
                    return 7;
                case 'H':
                    return 8;
            }
            return -1;
        }
        public static string FlipRows(string s)
        {
            string result = "" + s[0] + InverseRow(int.Parse(s[1].ToString()));
            return result;
        }
        public static bool SquareExcisits(string address, int column, int row)
        {
            if (column >= 0 && row >= 0)
            {
                if (ConvertFromChar(address[0]) + column < 8 && address[1] + row < 8)
                {
                    return true;
                }
            }
            else if(column >= 0 && row < 0)
            {
                if (ConvertFromChar(address[0]) + column < 8 && address[1] + row > 0)
                {
                    return true;
                }
            }
            else if (column < 0 && row >= 0)
            {
                if (ConvertFromChar(address[0]) + column > 0 && address[1] + row < 8)
                {
                    return true;
                }
            }
            else if (column < 0 && row < 0)
            {
                if (ConvertFromChar(address[0]) + column > 0 && address[1] + row > 0)
                {
                    return true;
                }
            }


            return false;
        }
        public static string ModifyAddress(string origin, int column, int row)
        {
            if (SquareExcisits(origin, column, row))
            {
                return "" + ConvertFromInt((ConvertFromChar(origin[0]) + column)) + (origin[1] + row);
            }
            return origin;
        }
    }
}
