using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5___Robot
{
    internal class ChildRobot : Robot
    {
        public int TotalDistance { get; set; }

        public new void Go(int input)
        {
            int oldX = Position.X;
            int oldY = Position.Y;

            base.Go(input);

            if (oldX != Position.X || oldY != Position.Y)
            {
                TotalDistance += input;
            }  
        }
    }
}
