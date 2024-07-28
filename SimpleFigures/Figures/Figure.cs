using SimpleFigures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFigures.Figures
{
    public class Figure : IDrawable
    {

        protected List<IDrawable> _drawables;

        // 
        public void Clear()
        {
            
        }

        public void Draw()
        {
            _drawables.ForEach(x => x.Draw());
        }

        public void Move()
        {
            _drawables.ForEach(x => x.Move());
        }
        public void Rotate(int pointOfOriginX, int pointOfOriginY)
        {
            _drawables.ForEach(x => x.Rotate(pointOfOriginX, pointOfOriginY));
        }

    }
}
