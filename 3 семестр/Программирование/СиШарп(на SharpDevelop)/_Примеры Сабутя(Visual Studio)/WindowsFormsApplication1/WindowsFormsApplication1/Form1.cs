using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Bitmap Bitmap1;
        Bitmap Bitmap2;
        Graphics Pic1;
        Graphics Pic2;
        Pen Pen1 = new Pen(Color.Red); 
        Pen Pen2 = new Pen(Color.Blue);
        const int n = 10;
        const int N = 100000;
        double[] T = new double[n+1];
        bool stop;


        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap1 = new Bitmap(pictureBox1.Width - 4, pictureBox1.Height - 4);
            Bitmap2 = new Bitmap(pictureBox2.Width - 4, pictureBox2.Height - 4); 
            Pic1 = Graphics.FromImage(Bitmap1);
            Pic2 = Graphics.FromImage(Bitmap2);
 
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
            double FiMax = Math.PI * Double.Parse(textBox1.Text) / 180;          
            double L = Double.Parse(textBox2.Text);
            double g = Double.Parse(textBox3.Text);
//------------------------------------------------------------------------------------------------------------
            double dFi = 2 * FiMax / n;
            double K = Math.Sin(FiMax / 2);
            double tt1 = -Math.PI / 2;
            double tt2;
            T[0] = 0;
            for (int k = 1; k <= n; k++)
            {
                if (k < n) tt2 = Math.Asin(Math.Sin((k * dFi - FiMax) / 2) / K); else tt2 = Math.PI / 2;
                double h = (tt2 - tt1) / N;
                double S = ( 1 / Math.Sqrt(1 - K * K * Math.Sin(tt1) * Math.Sin(tt1)) + 1 / Math.Sqrt(1 - K * K * Math.Sin(tt2) * Math.Sin(tt2)) ) / 2;
                for (int i = 1; i < N; i++)
                {
                    double tt = tt1 + i * h;
                    S += 1 / Math.Sqrt(1 - K * K * Math.Sin(tt) * Math.Sin(tt));
                }
                T[k] = T[k - 1] + S * h;
                tt1 = tt2;
            }

            listBox1.Items.Clear();
            for (int k = 0; k <= n; k++) listBox1.Items.Add(string.Format("t( {0:d} ) = {1:f12}         f( {0:d} ) = {2:f12}", k, T[k] * Math.Sqrt(L / g), k * dFi - FiMax));
            for (int k = 1; k <= n; k++) listBox1.Items.Add(string.Format("t( {0:d} ) = {1:f12}         f( {0:d} ) = {2:f12}", n + k, (T[n] + T[k]) * Math.Sqrt(L / g), FiMax - k * dFi));
            textBox4.Text = String.Format("{0:f12}", 2 * T[n] * Math.Sqrt(L / g));
            textBox5.Text = String.Format("{0:f12}", Math.Sqrt(2 * g * L * (1 - Math.Cos(FiMax))));
            textBox6.Text = String.Format("{0:f12}", g * L * (1 - Math.Cos(FiMax)));
            //------------------------------------------------------------------------------------------------------------
            double Kx = Bitmap2.Width / (2 * T[n]);
            double Ky = (Bitmap2.Height - 40) / (2 * FiMax);
            stop = false;
        L0: ;
            for (int i = 1; i <= n; i++)
            {
                double Fi = i * dFi - FiMax;
                int X = (int)Math.Round(Bitmap1.Width / 2 + 150 * Math.Sin(Fi));
                int Y = (int)Math.Round(50 + 150 * Math.Cos(Fi));
                Pic1.Clear(Color.White);
                Pic1.DrawEllipse(Pen1, X - 10, Y - 10, 20, 20);
                Pic1.DrawLine(Pen2, Bitmap1.Width / 2, 50, X, Y);
                Pic2.Clear(Color.White);
                Pic2.DrawLine(Pen2, 0, Bitmap2.Height / 2, Bitmap2.Width, Bitmap2.Height / 2);
                Pic2.DrawLine(Pen2, 0, 0, 0, Bitmap2.Height);
                for (int j = 1; j <= n; j++) Pic2.DrawLine(Pen1, (float)(Kx * T[j - 1]), Bitmap2.Height / 2 - (float)(Ky * (dFi * (j - 1) - FiMax)), (float)(Kx * T[j]), Bitmap2.Height / 2 - (float)(Ky * (dFi * j - FiMax)));
                for (int j = n - 1; j >= 0; j--) Pic2.DrawLine(Pen1, (float)(Kx * (T[n] + T[n - (j + 1)])), Bitmap2.Height / 2 - (float)(Ky * (dFi * (j + 1) - FiMax)), (float)(Kx * (T[n] + T[n - j])), Bitmap2.Height / 2 - (float)(Ky * (dFi * j - FiMax)));
                Pic2.DrawEllipse(Pen2, (float)(Kx * T[i]) - 3, Bitmap2.Height / 2 - (float)(Ky * (dFi * i - FiMax)) - 3, 6, 6);
                pictureBox1.Image = Bitmap1;
                pictureBox2.Image = Bitmap2;
                double Interval = (5E+08) * (T[i] - T[i-1]);
                for (int j = 1; j <= Interval; j++) { }
                Application.DoEvents();
                if (stop) goto L1;
            }
            for (int i = n-1; i >= 0; i--)
            {
                double Fi = i * dFi - FiMax;
                int X = (int)Math.Round(Bitmap1.Width / 2 + 150 * Math.Sin(Fi));
                int Y = (int)Math.Round(50 + 150 * Math.Cos(Fi));
                Pic1.Clear(Color.White);
                Pic1.DrawEllipse(Pen1, X - 10, Y - 10, 20, 20);
                Pic1.DrawLine(Pen2, Bitmap1.Width / 2, 50, X, Y);
                Pic2.Clear(Color.White);
                Pic2.DrawLine(Pen2, 0, Bitmap2.Height / 2, Bitmap2.Width, Bitmap2.Height / 2);
                Pic2.DrawLine(Pen2, 0, 0, 0, Bitmap2.Height);
                for (int j = 1; j <= n; j++) Pic2.DrawLine(Pen1, (float)(Kx * T[j - 1]), Bitmap2.Height / 2 - (float)(Ky * (dFi * (j - 1) - FiMax)), (float)(Kx * T[j]), Bitmap2.Height / 2 - (float)(Ky * (dFi * j - FiMax)));
                for (int j = n - 1; j >= 0; j--) Pic2.DrawLine(Pen1, (float)(Kx * (T[n] + T[n - (j + 1)])), Bitmap2.Height / 2 - (float)(Ky * (dFi * (j + 1) - FiMax)), (float)(Kx * (T[n] + T[n - j])), Bitmap2.Height / 2 - (float)(Ky * (dFi * j - FiMax)));
                Pic2.DrawEllipse(Pen2, Bitmap2.Width/2 + (float)(Kx * T[n-i]) - 3, Bitmap2.Height / 2 - (float)(Ky * (dFi * i - FiMax)) - 3, 6, 6);
                pictureBox1.Image = Bitmap1;
                pictureBox2.Image = Bitmap2;
                double Interval = (5E+08) * (T[i+1] - T[i]);
                for (int j = 1; j <= Interval; j++) { }
                Application.DoEvents();
                if (stop) goto L1;
            }
            goto L0;
        L1: ;
        button1.Enabled = true;
        button2.Enabled = false;
        button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stop = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
