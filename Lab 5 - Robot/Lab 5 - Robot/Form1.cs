using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab_5___Robot;

namespace Lab_5___Robot
{
    public partial class Form1 : Form
    {
        Robot robot = new Robot();
        ChildRobot childRobot = new ChildRobot();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            robot.Crash += RobotCrashed;
            UpdatePosition();
        }

        private void RobotCrashed(object sender, EventArgs e)
        {
            MessageBox.Show("Crash! The robot cannot move beyond the limit of 100 units in any direction.", "Crash", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdatePosition()
        {
            lblPosition.Text = $"Position: (X = {robot.Position.X}, Y = {robot.Position.Y})";
            lblDistance.Text = $"Distance: {childRobot.TotalDistance}";
            lblRobot.Text = robot.DirectionArrow;
            lblRobot.Location = new Point(100 + robot.Position.X, 100 - robot.Position.Y);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            robot.Direction = Robot.RobotDirection.N;
            UpdatePosition();
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            robot.Direction = Robot.RobotDirection.W;
            UpdatePosition();
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            robot.Direction = Robot.RobotDirection.S;  
            UpdatePosition();
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            robot.Direction = Robot.RobotDirection.E;
            UpdatePosition();
        }

        private void btnGo10_Click(object sender, EventArgs e)
        {
            robot.Go(10);
            childRobot.Go(10);
            UpdatePosition();
        }

        private void btnGo1_Click(object sender, EventArgs e)
        {
            robot.Go(1);
            childRobot.Go(1);
            UpdatePosition();
        }
    }
}
