using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZ2
{
    class FractalNode
    {
        public PointF Point1 { get; set; }
        public PointF Point2 { get; set; }
        public PointF Point3 { get; set; }
        public int Level { get; set; }
        public FractalNode LeftChild { get; set; }
        public FractalNode MidlChild { get; set; }
        public FractalNode RightChild { get; set; }

        public FractalNode(PointF point1, PointF point2, PointF point3, int level)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
            Level = level;
        }
    }

    class CircleNode
    {
        public PointF Point { get; set; }
        public float Diameter { get; set; }
        public int Level { get; set; }
        public CircleNode LeftChild { get; set; }
        public CircleNode MidlChild { get; set; }
        public CircleNode RightChild { get; set; }
        public CircleNode(PointF point1, float diameter, int level)
        {
            Point = point1;
            Diameter = diameter;
            Level = level;
        }
    }
    class FractalTree
    {
        public FractalNode Root { get; private set; }

        int level;

        public FractalTree(int level)
        {
            this.level = level;
        }

        public void DrawFractal(GraphicsPath path)
        {
            DrawNode(Root, path);
        }

        public void CreateFractalTree(FractalNode node)
        {
            Root = node;

            AddNode(node);
        }

        void DrawNode(FractalNode node, GraphicsPath path)
        {
            PointF p1 = node.Point1;
            PointF p2 = node.Point2;
            PointF p3 = node.Point3;

            path.AddLine(p1, p2);
            path.AddLine(p2, p3);
            path.CloseFigure();

            if(node.LeftChild != null)
            {
                DrawNode(node.LeftChild, path);
            }

            if(node.MidlChild != null)
            {
                DrawNode(node.MidlChild, path);
            }

            if(node.RightChild != null)
            {
                DrawNode(node.RightChild, path);
            }
        }

        void AddNode(FractalNode node)
        {
            int nextLevel = node.Level + 1;

            if (nextLevel <= level)
            {
                var p12 = new PointF(node.Point1.X + (node.Point2.X - node.Point1.X) / 2, node.Point1.Y + (node.Point2.Y - node.Point1.Y) / 2);
                var p23 = new PointF(node.Point2.X + (node.Point3.X - node.Point2.X) / 2, node.Point2.Y + (node.Point3.Y - node.Point2.Y) / 2);
                var p13 = new PointF(node.Point1.X + (node.Point3.X - node.Point1.X) / 2, node.Point1.Y + (node.Point3.Y - node.Point1.Y) / 2);

                FractalNode leftChild = new FractalNode(node.Point1, p12, p13, nextLevel);
                FractalNode midlChild = new FractalNode(p12, node.Point2, p23, nextLevel);
                FractalNode rightChild = new FractalNode(p13, p23, node.Point3, nextLevel);

                node.LeftChild = leftChild;
                node.MidlChild = midlChild;
                node.RightChild = rightChild;

                AddNode(leftChild);
                AddNode(midlChild);
                AddNode(rightChild);
            }
        }
    }

    class CircleTree
    {
        public CircleNode Root { get; private set; }

        int level;

        float[] lastXForLevel;

        public CircleTree(int level)
        {
            this.level = level;
            lastXForLevel = new float[level];
        }

        public void DrawCircles(Graphics graphics)
        {
            DrawCircle(Root, graphics);
        }

        public void CreateCircleTree(CircleNode node)
        {
            Root = node;

            AddNode(node);
        }

        public void DrawLines(Graphics graphics)
        {
            DrawLine(Root, graphics);
        }

        void DrawLine(CircleNode node, Graphics graphics)
        {
            if(node.LeftChild == null)
            {
                return;
            }

            graphics.DrawLine(new Pen(Color.Blue), new PointF(node.Point.X + node.Diameter/2, node.Point.Y + node.Diameter / 2), new PointF(node.LeftChild.Point.X + node.LeftChild.Diameter/2, node.LeftChild.Point.Y + node.LeftChild.Diameter/2));
            graphics.DrawLine(new Pen(Color.Blue), new PointF(node.Point.X + node.Diameter / 2, node.Point.Y + node.Diameter / 2), new PointF(node.MidlChild.Point.X + node.MidlChild.Diameter / 2, node.MidlChild.Point.Y + node.MidlChild.Diameter / 2));
            graphics.DrawLine(new Pen(Color.Blue), new PointF(node.Point.X + node.Diameter / 2, node.Point.Y + node.Diameter / 2), new PointF(node.RightChild.Point.X + node.RightChild.Diameter / 2, node.RightChild.Point.Y + node.RightChild.Diameter / 2));

            DrawLine(node.LeftChild, graphics);
            DrawLine(node.MidlChild, graphics);
            DrawLine(node.RightChild, graphics);
        }

        void DrawCircle(CircleNode node, Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Red, node.Point.X, node.Point.Y, node.Diameter, node.Diameter);

            if (node.LeftChild != null)
            {
                DrawCircle(node.LeftChild, graphics);
            }

            if (node.MidlChild != null)
            {
                DrawCircle(node.MidlChild, graphics);
            }

            if (node.RightChild != null)
            {
                DrawCircle(node.RightChild, graphics);
            }
        }

        void AddNode(CircleNode node)
        {
            int nextLevel = node.Level + 1;

            if (nextLevel <= level)
            {
                float lastX = lastXForLevel[node.Level - 1];
                float newDiameter = node.Diameter / (float)1.7;
                CircleNode leftChild = new CircleNode(new PointF(lastX, node.Point.Y + 2 * node.Diameter), newDiameter, nextLevel);
                lastX += newDiameter;
                CircleNode midlChild = new CircleNode(new PointF(lastX, node.Point.Y + 2 * node.Diameter), newDiameter, nextLevel);
                lastX += newDiameter;
                CircleNode rightChild = new CircleNode(new PointF(lastX, node.Point.Y + 2 * node.Diameter), newDiameter, nextLevel);
                lastX += newDiameter;
                lastXForLevel[node.Level - 1] = lastX;

                node.LeftChild = leftChild;
                node.MidlChild = midlChild;
                node.RightChild = rightChild;

                AddNode(leftChild);
                AddNode(midlChild);
                AddNode(rightChild);
            }
        }
    }
}
