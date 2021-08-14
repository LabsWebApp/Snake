using System;
using Library;
using static System.Console;
using Library.Shapes;

namespace WinCMD
{
    class Program
    {
        static void Main()
        {
            static void SetWin(int x, int y)
            {
                SetWindowSize(x, y);
                SetBufferSize(x, y);
            }

            Field.SetField(SetWin);
            ReadKey();
        }
    }
}
