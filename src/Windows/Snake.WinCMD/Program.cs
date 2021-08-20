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

            Game game = new(SetWin);
            game.Play();
            ReadKey();
        }
    }
}
