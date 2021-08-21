using System;
using static System.Console;

namespace Library.Geom.Base
{
    public class SetResetColor : IDisposable
    {
        private readonly bool _mustDo;
        public SetResetColor(ConsoleColor color)
        {
            _mustDo = ForegroundColor != color;
            if (_mustDo) ForegroundColor = color;
        }

        public static void ForAction(ConsoleColor color, Action action)
        {
            using var _ = new SetResetColor(color);
            action.Invoke();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _mustDo) ResetColor();
        }
    }
}