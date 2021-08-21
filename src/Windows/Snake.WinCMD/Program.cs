using System;
using Library;
using static System.Console;
//using static Library.Helpers.Config;

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

            for (;;)
            {
                using (Game game = new(SetWin))
                {
                    game.Play();
                }
                WriteLine();
                WriteLine("!!!! GAME OVER !!!!");
                Write("\rДля запуска нажмите любую клавишу или ESC для выхода: ");
                if (ReadKey(false).Key == ConsoleKey.Escape)
                    break;
            }
        }
    }
}
