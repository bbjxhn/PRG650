using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5___Robot
{
    internal class Robot
    {
        private int x = 0, y = 0;
        private const int MaxRange = 100;

        public enum RobotDirection { N, S, E, W }

        public Point Position { get { return new Point(x, y); } }
        public RobotDirection Direction { get; set; }

        public Robot()
        {
            x = 0;
            y = 0; 
            Direction = RobotDirection.N;
        }

        public string DirectionArrow
        {
            get
            {
                switch (Direction)
                {
                    case RobotDirection.N:
                        return ((char)227).ToString();
                    case RobotDirection.S:
                        return ((char)228).ToString();
                    case RobotDirection.E:
                        return ((char)226).ToString();
                    case RobotDirection.W:
                        return ((char)225).ToString();
                    default:
                        return null;
                }
            }
        }

        public void Go(int input)
        {
            int newX = x;
            int newY = y;

            switch (Direction)
            {
                case RobotDirection.N:
                    newY += input;
                    break;
                case RobotDirection.S:
                    newY -= input;
                    break;
                case RobotDirection.E:
                    newX += input;
                    break;
                case RobotDirection.W:
                    newX -= input;
                    break;
            }
            
            if (newX > MaxRange || newY > MaxRange)
            {
                Crash?.Invoke(this, EventArgs.Empty);
            } 
            else
            {
                x = newX;
                y = newY;
            }
        }
        public delegate void CrashHandler(object sender, EventArgs e);
        public event CrashHandler Crash;
    }
}
