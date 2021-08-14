using System;
using static System.Console;
using Library.Shapes;

namespace WinCMD
{
    class Program
    {
        static void Main()
        {
            WriteLine("Hello World!");
            ReadKey();
            Clear();
            SetWindowSize(80,25);
            SetBufferSize(80,25);
            var p1 = new Point(5, 6, '1');
            var p2 = new Point(10, 17, '2');

            p1.Draw();
            p2.Draw();

            ReadKey();

            var p3 = p1;

            p3.Symbol = '3';
            p1.X = 20;

            p1.Draw();
            p3.Draw();

            ReadKey();
        }
    }
}
