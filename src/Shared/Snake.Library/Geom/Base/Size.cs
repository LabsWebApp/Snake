using System;

namespace Library.Geom.Base
{
    public struct Size
    {
        private int _width, _height;

        public int EndOfWidth
        {
            get => _width;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(EndOfWidth), "Ширина не может быть меньше 0");
                _width = value;
            }
        }

        public int EndOfHeight
        {
            get => _height;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(EndOfHeight), "Высота не может быть меньше 0");
                _height = value;
            }
        }


        public Size(int width, int height)
        {
            _width = width;
            _height = height;
        }
    }
}
