using Library;
using Library.Geom.Base;
using static System.Console;
using static Library.Helpers.Config;

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

            Field.SetField(SetWin, null, new Size(150,25), new SimplePoint(1, 10));
            ReadKey();
        }
    }
}
