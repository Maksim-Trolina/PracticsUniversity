using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IZ1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointF[] points = new PointF[1000];
            Graphics graphics;
            float x = 0;
            float y;
            int i = 0;
            float step = (float)numericUpDown4.Value;
            float incrementX = pictureBox1.Width / step;
            while (x < pictureBox1.Size.Width)
            {
                y = (float)(20 * Math.Cos(x / 20)) + 100;
                points[i] = new PointF(x, y);
                DrawFigure(x, y);
                graphics = pictureBox1.CreateGraphics();
                DrawCoordinate();
                graphics.DrawLines(GetColorFromComboBox3(), points);
                x+= incrementX;
                i++;
                Thread.Sleep((int)numericUpDown3.Value);
            }

            y = (float)(20 * Math.Cos(x / 20)) + 100;
            points[i] = new PointF(x, y);
            DrawFigure(x, y);
            graphics = pictureBox1.CreateGraphics();
            DrawCoordinate();
            graphics.DrawLines(GetColorFromComboBox3(), points);
            x += incrementX;
            i++;
            Thread.Sleep((int)numericUpDown3.Value);
        }

        private void DrawFigure(float x, float y)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.Clear(Color.White);

            float verticalDiagonal = (float)numericUpDown1.Value;
            float horizontalDiagonal = (float)numericUpDown2.Value;

            PointF leftPoint = new PointF(x, y);
            PointF rightPoint = new PointF(leftPoint.X + horizontalDiagonal, leftPoint.Y);
            PointF topPoint = new PointF(leftPoint.X + horizontalDiagonal / 2, leftPoint.Y - verticalDiagonal / 2);
            PointF bottomPoint = new PointF(leftPoint.X + horizontalDiagonal / 2, leftPoint.Y + verticalDiagonal / 2);

            graphics.FillPolygon(GetColorFromComboBox1(), new[] { leftPoint, topPoint, rightPoint, bottomPoint });
        }

        private void DrawCoordinate()
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            Point point1 = new Point(0, 100);
            Point point2 = new Point(pictureBox1.Size.Width, point1.Y);
            graphics.DrawLine(new Pen(Color.Red), point1, point2);
            point1 = new Point(pictureBox1.Size.Width / 2, 0);
            point2 = new Point(point1.X, pictureBox1.Size.Height);
            graphics.DrawLine(new Pen(Color.Red), point1, point2);
        }

        Brush GetColorFromComboBox1()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    return new SolidBrush(Color.Green);
                case 1:
                    return new SolidBrush(Color.Yellow);
                case 2:
                    return new SolidBrush(Color.Blue);
                default:
                    return new SolidBrush(Color.Black);
            }
        }

        Pen GetColorFromComboBox3()
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    return new Pen(Color.Green);
                case 1:
                    return new Pen(Color.Yellow);
                case 2:
                    return new Pen(Color.Blue);
                default:
                    return new Pen(Color.Black);
            }

        }
    }
}
