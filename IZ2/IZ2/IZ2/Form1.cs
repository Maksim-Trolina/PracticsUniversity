using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IZ2
{
    public partial class Form1 : Form
    {
        private GraphicsPath path1 = new GraphicsPath();
        private GraphicsPath path2 = new GraphicsPath();
        private GraphicsPath path3 = new GraphicsPath();
        private GraphicsPath path4 = new GraphicsPath();

        int rX = -200;

        int rY = 0;
         int x1 = -100;
         int y1 = 30;
         int x2 = 0;
         int y2 = -75;
         int x3 = 100;
         int y3 = 30;
         int x4 = 100;
         int y4 = 230;
         int x5 = 0;
         int y5 = 355;
         int x6 = -100;
         int y6 = 230;
         int x7 = 100;
         int y7 = 30;
         int x8 = 205;
         int y8 = 130;
         int x9 = 100;
         int y9 = 230;
         int x10 = -100;
         int y10 = 230;
         int x11 = -205;
         int y11 = 130;
         int x12 = -100;
         int y12 = 30;
        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TranslateTransform(400, 100);
            e.Graphics.DrawPath(Pens.Black, path1);
            e.Graphics.DrawPath(Pens.Black, path2);
            e.Graphics.DrawPath(Pens.Black, path3);
            e.Graphics.DrawPath(Pens.Black, path4);

            DrawTreeCircles((int)numericUpDown1.Value);


        }

        FractalTree GetFractalTree(PointF p1, PointF p2, PointF p3, int level)
        {
            FractalTree fractalTree = new FractalTree(level);

            FractalNode fractalNode = new FractalNode(p1, p2, p3, 1);

            fractalTree.CreateFractalTree(fractalNode);

            return fractalTree;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            path1 = new GraphicsPath();
            path2 = new GraphicsPath();
            path3 = new GraphicsPath();
            path4 = new GraphicsPath();

            int level = (int)numericUpDown1.Value;

            DrawFractals(level);

            Refresh();
        }

        void DrawTreeCircles(int level)
        {
            CircleTree circleTree = new CircleTree(level);

            Graphics graphics = pictureBox1.CreateGraphics();

            CircleNode root = new CircleNode(new PointF(0, 30), 60, 1);

            circleTree.CreateCircleTree(root);

            circleTree.DrawCircles(graphics);

            circleTree.DrawLines(graphics);
        }

        void DrawFractals(int level)
        {
            for (int i = 1; i <= Math.Min(3, level); i++)
            {
                DrawFractal(i, rX + (i - 1) * 420, rY);
            }

            for (int i = 4; i <= level; i++)
            {
                DrawFractal(i, rX + (i - 4) * 420, rY + 440);
            }
        }

        void DrawFractal(int iteration, int rX, int rY)
        {
            FractalTree topFractalTree = GetFractalTree(new PointF(x1 + rX, y1 + rY), new PointF(x2 + rX, y2 + rY), new PointF(x3 + rX, y3 + rY), iteration);
            FractalTree bottomFractalTree = GetFractalTree(new PointF(x4 + rX, y4 + rY), new PointF(x5 + rX, y5 + rY), new PointF(x6 + rX, y6 + rY), iteration);
            FractalTree rightFractalTree = GetFractalTree(new PointF(x7 + rX, y7 + rY), new PointF(x8 + rX, y8 + rY), new PointF(x9 + rX, y9 + rY), iteration);
            FractalTree leftFractalTree = GetFractalTree(new PointF(x10 + rX, y10 + rY), new PointF(x11 + rX, y11 + rY), new PointF(x12 + rX, y12 + rY), iteration);

            leftFractalTree.DrawFractal(path1);

            topFractalTree.DrawFractal(path2);

            rightFractalTree.DrawFractal(path3);

            bottomFractalTree.DrawFractal(path4);
        }
    }
}
