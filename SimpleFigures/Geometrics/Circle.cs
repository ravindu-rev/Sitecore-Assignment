using SimpleFigures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFigures.Geometrics
{
    public class Circle : IDrawable
    {

        private readonly int _radius;
        private readonly int _x;
        private readonly int _y;

        public Circle(int x, int y, int radius) 
        {
            _x = x;
            _y = y;
            _radius = radius;
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
