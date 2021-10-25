using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        const string pathToCar = "C:\\Users\\Максим\\Desktop\\LabsForPractics\\Lab3\\Task3\\Task3\\bin\\Debug\\car.jpg";
        const string pathToCat = "C:\\Users\\Максим\\Desktop\\LabsForPractics\\Lab3\\Task3\\Task3\\bin\\Debug\\cat.jpg";
        public Form1()
        {
            InitializeComponent();
            Font = new Font("Times New Roman", 12, FontStyle.Bold);
            pictureBox2.Image = new Bitmap(pathToCar);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string text = string.Format("{0}", textBox1.Text);
            Brush brush = new SolidBrush(Color.LimeGreen);
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);//очистка от предыдущего текста
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.DrawString(text, Font, brush, 150, 50); // Координаты размещения текста
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    pictureBox2.Image = new Bitmap(pathToCar);
                    break;
                case 1:
                    pictureBox2.Image = new Bitmap(pathToCat);
                    break;
            }
        }
    }
}
