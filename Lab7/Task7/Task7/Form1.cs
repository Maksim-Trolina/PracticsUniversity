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

namespace Task7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawFigure();
        }

        void Paint_Circle(int cX, int cY, int centX, int centY, int radius, int x, int y)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawEllipse(Pens.Black, centX + cX - radius, cY - radius - centY, radius * 2, radius * 2);
            graphics.DrawLine(Pens.Black, centX + cX, cY - centY, cX + x, cY + y);
            // прорисовка радиуса большей окружности
        }

        void Paint_Graphic(int cX, int cY, int r2, int x, int y, Point[] p)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.Clear(BackColor);
            Paint_Circle(cX, cY, 0, 0, r2, x, y);
            graphics.DrawLines(Pens.Red, p); // траектория
        }

        void DrawFigure()
        {
            double InitT = 0, LastT = 6.3; // оборот в 360 градусов (6,28 радиан)
            double Step = 0.1, angle = InitT;
            double x, y, x1, y1;
            int cX = 120, cY = 120; // центр большой окружности
            int R2 = 90; // радиус большой окружности
            int k = 20; // число областей на траектории
            int R1 = R2 / k; // радиус меньшей (движущейся) окружности
            int i = 0; // количество точек прорисовки
            Point[] p;
            p = new Point[64]; // точки для прорисовки (LastT/Step)
            while (angle <= LastT)
            {
                x = R1 * (k - 1) * (Math.Cos(angle) + Math.Cos((k - 1) * angle) / (k - 1));
                y = R1 * (k - 1) * (Math.Sin(angle) - Math.Sin((k - 1) * angle) / (k - 1));
                p[i] = new Point(cX + Convert.ToInt32(x), cY + Convert.ToInt32(y)); // расчет очередной точки траектории
                Paint_Graphic(cX, cY, R2, Convert.ToInt32(x), Convert.ToInt32(y), p);
                x1 = (R2 - R1) * Math.Sin(angle + 1.57);
                y1 = (R2 - R1) * Math.Cos(angle + 1.57);
                Paint_Circle(cX, cY, Convert.ToInt32(x1), Convert.ToInt32(y1), R1, Convert.ToInt32(x), Convert.ToInt32(y));
                angle += Step;
                Thread.Sleep(40); //время приостановки прорисовки
                i++;
            }
        }
    }
}
