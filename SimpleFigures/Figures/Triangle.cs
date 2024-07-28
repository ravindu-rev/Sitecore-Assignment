using SimpleFigures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFigures.Figures
{
    public class Triangle : Figure
    { 

        public Triangle(int x, int y)
        {
            // construct lines for triangle
            var drawables = new List<IDrawable>();

            _drawables = drawables;
        } 
    }
}
