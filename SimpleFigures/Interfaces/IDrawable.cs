using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFigures.Interfaces
{
    public interface IDrawable
    {
        void Draw();
        void Move();
        void Rotate(int pointOfOriginX, int pointOfOriginY);
    }
}
