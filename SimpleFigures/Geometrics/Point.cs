using SimpleFigures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFigures.Geometrics
{
    public class Point : IDrawable
    {
        private readonly int _x;
        private readonly int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Rotate(int pointOfOriginX, int pointOfOriginY)
        {
            throw new NotImplementedException();
        }
    }
}
