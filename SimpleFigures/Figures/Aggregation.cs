using SimpleFigures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFigures.Figures
{
    public class Aggregation : Figure
    {
        public Aggregation(List<IDrawable> drawables)
        {
            _drawables = drawables;
        }
    }
}
