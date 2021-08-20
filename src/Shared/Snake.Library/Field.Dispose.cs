using System;
using static System.Console;

namespace Library
{
    public partial class Field
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing) CursorVisible = true;
        }
    }
}