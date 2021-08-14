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
            void SetWin(int x, int y)
            {
                SetWindowSize(x, y);
                SetBufferSize(x, y);
            }

            Field.SetField(SetWin);
            ReadKey();
            Field.SetField(SetWin, 0,0);
            ReadKey();
            Field.SetField(SetWin, 100000,100000);
            ReadKey();
        }
    }
}
