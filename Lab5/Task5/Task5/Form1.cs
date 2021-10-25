using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {
        Color color = Color.Red;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            Brush brush = new SolidBrush(color);
            graphics.Clear(SystemColors.Control);
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    graphics.FillRectangle(brush, 60, 60, 120, 180);                    
                    break;
                case 1:
                    graphics.FillEllipse(brush, 60, 60, 120, 180);
                    break;
                case 2:
                    graphics.FillEllipse(brush, 60, 60, 120, 120);
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    color = Color.Red;
                    break;
                case 1:
                    color = Color.Green;
                    break;
                case 2:
                    color = Color.Blue;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox2.CreateGraphics();
            graphics.Clear(Color.White);
            graphics.DrawLine(new Pen(color), (int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value, (int)numericUpDown4.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox3.CreateGraphics();
            graphics.Clear(Color.White);
            Point point1 = new Point((int)numericUpDown5.Value, (int)numericUpDown6.Value);
            Point point2 = new Point((int)numericUpDown7.Value, (int)numericUpDown8.Value);
            Point point3 = new Point((int)numericUpDown9.Value, (int)numericUpDown10.Value);
            graphics.DrawLines(new Pen(color), new[] { point1, point2, point3, point1 });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox4.CreateGraphics();
            graphics.Clear(Color.White);
            graphics.DrawEllipse(new Pen(color), (int)numericUpDown11.Value, (int)numericUpDown12.Value, (int)numericUpDown13.Value, (int)numericUpDown14.Value);
        }
    }
}
