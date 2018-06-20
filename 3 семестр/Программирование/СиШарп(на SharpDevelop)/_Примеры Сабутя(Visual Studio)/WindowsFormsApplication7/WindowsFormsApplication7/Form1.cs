using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        double[] X = new Double[1000];
        double[] Y = new Double[1000];
        double[] A;
        double[] B;
        double[,] F;
        int n = 0;
        int ni = 0;

        Graphics Pic;
        Bitmap Bmp;
        Pen PenCell = new Pen(Color.Gray);
        Pen PenAxis = new Pen(Color.Blue, 2);
        Pen PenGraph = new Pen(Color.Green, 2);
        SolidBrush BrushPoints = new SolidBrush(Color.Red);
        double Xmin, Xmax, Ymin, Ymax;
        double Xc, Yc, Xb, Yb, Dx, Dy, K, Kx, Ky, XGmin, XGmax, YGmin, YGmax;
        bool LG = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++) { X[i] = 0;  Y[i] = 0; }
            textBox1.Text = "X( 1 ) = ";
            textBox2.Text = String.Format("{0:f6}", X[0]);
            textBox3.Text = "Y( 1 ) = ";
            textBox4.Text = String.Format("{0:f6}", Y[0]);
            Bmp = new Bitmap(pictureBox1.Width - 4, pictureBox1.Height - 4);
            Pic = Graphics.FromImage(Bmp);
            
        }

        public double f(double x)
        {
            double Sum = A[0];
            double xx = 1;
            for (int i = 1; i < n; i++)
            {
                xx *= x;
                Sum += A[i] * xx;
            }
            return Sum;
        }

        private void DrawGraphics()
        {
            int Xscr1, Yscr1, Xscr2, Yscr2;

            double Lx = K * Math.Pow(2, trackBar1.Value) * (Xmax - Xmin);
            double Ly = K * Math.Pow(2, trackBar2.Value) * (Ymax - Ymin);

            XGmin = Xc - Dx - Lx / 2;
            XGmax = Xc - Dx + Lx / 2;
            YGmin = Yc + Dy - Ly / 2;
            YGmax = Yc + Dy + Ly / 2;
            Kx = (Bmp.Width - 1) / Lx;
            Ky = (Bmp.Height - 1) / Ly;

            Pic.Clear(Color.White);
            for (int i = 0; i <= 10; i++)
            {
                Pic.DrawLine(PenCell, i * (Bmp.Width - 1) / 10, 0, i * (Bmp.Width - 1) / 10, Bmp.Height - 1);
                Pic.DrawLine(PenCell, 0, i * (Bmp.Height - 1) / 10, Bmp.Width - 1, i * (Bmp.Height - 1) / 10);
            }

            Yscr1 = (Bmp.Height - 1) + (int)(Ky * YGmin);
            if ((Yscr1 >= 0) && (Yscr1 < Bmp.Height)) Pic.DrawLine(PenAxis, 0, Yscr1, Bmp.Width - 1, Yscr1);
            Xscr1 = (int)(-Kx * XGmin);
            if ((Xscr1 >= 0) && (Xscr1 < Bmp.Width)) Pic.DrawLine(PenAxis, Xscr1, 0, Xscr1, Bmp.Height - 1);

            Xscr1 = 0;
            Yscr1 = (Bmp.Height - 1) - (int)(Ky * (f(XGmin) - YGmin));
            for (int i = 1; i < Bmp.Width; i++)
            {
                Xscr2 = i;
                double x = XGmin + Xscr2 / Kx;
                Yscr2 = (Bmp.Height - 1) - (int)(Ky * (f(x) - YGmin));
                if (((Yscr1 >= 0) && (Yscr1 < Bmp.Height)) || ((Yscr2 >= 0) && (Yscr2 < Bmp.Height))) Pic.DrawLine(PenGraph, Xscr1, Yscr1, Xscr2, Yscr2);
                Xscr1 = Xscr2;
                Yscr1 = Yscr2;
            }


            for (int i = 0; i < n; i++)
            {
                Xscr1 = (int)(Kx * (X[i] - XGmin));
                Yscr1 = (Bmp.Height - 1) - (int)(Ky * (Y[i] - YGmin));
                Pic.FillEllipse(BrushPoints, Xscr1 - 3, Yscr1 - 3, 7, 7);
            }

            pictureBox1.Image = Bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            X[ni] = Double.Parse(textBox2.Text);
            Y[ni] = Double.Parse(textBox4.Text);
            listBox1.Items.Insert(ni, String.Format("X( {0:d} ) = {1:f6}        Y( {0:d} ) = {2:f6}", ni + 1, X[ni], Y[ni]));
            listBox1.SetSelected(ni, true);
            ni++;
            if (ni < listBox1.Items.Count) listBox1.Items.RemoveAt(ni);
            textBox1.Text = String.Format("X( {0:d} ) = ", ni + 1);
            textBox2.Text = String.Format("{0:f6}", X[ni]);
            textBox3.Text = String.Format("Y( {0:d} ) = ", ni + 1);
            textBox4.Text = String.Format("{0:f6}", Y[ni]);
            if (listBox1.Items.Count > 1) button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) 
            {
                ni = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(ni);
                n = listBox1.Items.Count;
                for (int i = ni; i < n; i++)
                {
                    X[i] = X[i + 1];  Y[i] = Y[i + 1];
                    listBox1.Items.Insert(i, String.Format("X( {0:d} ) = {1:f6}        Y( {0:d} ) = {2:f6}", i + 1, X[i], Y[i]));
                    listBox1.Items.RemoveAt(i+1);
                }
                X[n] = 0; Y[n] = 0;
                if (ni == n) ni--;
                if (ni >= 0) listBox1.SetSelected(ni, true); else ni++;
                if (n < 1) button4.Enabled = false;
                textBox1.Text = String.Format("X( {0:d} ) = ", ni + 1);
                textBox2.Text = String.Format("{0:f6}", X[ni]);
                textBox3.Text = String.Format("Y( {0:d} ) = ", ni + 1);
                textBox4.Text = String.Format("{0:f6}", Y[ni]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            button4.Enabled = false;
            Pic.Clear(Color.White);
            pictureBox1.Image = Bmp;
            ni = 0;
            for (int i = 0; i < 1000; i++) { X[i] = 0; Y[i] = 0; }
            textBox1.Text = "X( 1 ) = ";
            textBox2.Text = String.Format("{0:f6}", X[0]);
            textBox3.Text = "Y( 1 ) = ";
            textBox4.Text = String.Format("{0:f6}", Y[0]);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                ni = listBox1.SelectedIndex;
                textBox1.Text = String.Format("X( {0:d} ) = ", ni + 1);
                textBox2.Text = String.Format("{0:f6}", X[ni]);
                textBox3.Text = "Y( " + String.Format("Y( {0:d} ) = ", ni + 1);
                textBox4.Text = String.Format("{0:f6}", Y[ni]);            
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            DrawGraphics();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            DrawGraphics();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            n = listBox1.Items.Count;
            A = new Double[n];
            B = new Double[n];
            F = new Double[n, n];


            for (int i = 0; i < n; i++) F[i, 0] = Y[i];
            for (int j = 1; j < n; j++)
                for (int i = 0; i < n - j; i++)
                {
                    F[i, j] = (F[i + 1, j - 1] - F[i, j - 1]) / (X[i + j] - X[i]);
                }

            for (int i = 0; i < n; i++) A[i] = 0;
            for (int j = 0; j < n; j++)
            {
                B[0] = F[0, j];
                for (int i = 1; i < n; i++) B[i] = 0;
                for (int k = 0; k < j; k++)
                {
                    for (int i = n - 1; i > 0; i--) B[i] = B[i - 1] - B[i] * X[k];
                    B[0] = -B[0] * X[k];
                }   
                for (int i = 0; i < n; i++) A[i] += B[i];
            }

            listBox2.Items.Clear();
            listBox2.Items.Add("Коэффициенты интерполяционного");
            listBox2.Items.Add("многочлена:");
            listBox2.Items.Add("");
            for (int k = 0; k < n; k++) listBox2.Items.Add(String.Format("A( {0:d} ) = {1:f6}", k, A[n-1-k]));

            Xmin = X[0];
            Xmax = X[0];
            Ymin = Y[0];
            Ymax = Y[0];
            for (int i = 0; i < n; i++)
            {
                if (X[i] < Xmin) Xmin = X[i];
                if (X[i] > Xmax) Xmax = X[i];
                if (Y[i] < Ymin) Ymin = Y[i];
                if (Y[i] > Ymax) Ymax = Y[i];
            }
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            Xc = (Xmin + Xmax) / 2;
            Yc = (Ymin + Ymax) / 2;
            K = 1;
            LG = true; 
            DrawGraphics();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!LG) return;
            if (e.Button == MouseButtons.Middle)
            {
                label1.Visible = false;
                Dx = (e.X - Xb) / Kx;
                Dy = (e.Y - Yb) / Ky;
                DrawGraphics();
            }
            else
            {
                label1.Visible = true;
                double x = XGmin + e.X / Kx;
                double y = YGmin + (Bmp.Height - 1 - e.Y) / Ky;
                label1.Text = string.Format("( {0:f2}, {1:f2} )", x, y);
                label1.Left = e.X + pictureBox1.Left + 12;
                label1.Top = e.Y + pictureBox1.Top + 12;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!LG) return;
            if (e.Button == MouseButtons.Middle)
            {
                Xb = e.X;
                Yb = e.Y;
                pictureBox1.Cursor = Cursors.SizeAll;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!LG) return;
            if (e.Button == MouseButtons.Middle)
            {
                Xc -= (e.X - Xb) / Kx;
                Yc += (e.Y - Yb) / Ky;
                Dx = 0;
                Dy = 0;
                pictureBox1.Cursor = Cursors.Cross;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!LG) return;
            K *= Math.Pow(1.1, e.Delta / 120);
            DrawGraphics();
            label1.Visible = true;
            double x = XGmin + e.X / Kx;
            double y = YGmin + (Bmp.Height - 1 - e.Y) / Ky;
            label1.Text = string.Format("( {0:f2}, {1:f2} )", x, y);
            label1.Left = e.X + pictureBox1.Left + 12;
            label1.Top = e.Y + pictureBox1.Top + 12;
        }
    }
}
