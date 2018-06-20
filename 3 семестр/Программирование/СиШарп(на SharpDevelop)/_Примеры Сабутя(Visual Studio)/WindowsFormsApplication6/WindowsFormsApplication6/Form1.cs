using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        const int MaxPoints = 2001;
        double[] X = new Double[MaxPoints];
        double[] Y = new Double[MaxPoints];
        double[] Q = new Double[MaxPoints];
        double[] A = new Double[MaxPoints];
        double[] B = new Double[MaxPoints];
        double[] a = new Double[MaxPoints];
        double[] b = new Double[MaxPoints];
        double[] a1 = new Double[MaxPoints + 1];
        double[] b1 = new Double[MaxPoints + 1];

        double T = 2 * Math.PI;
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

        public double f(double x)
        {
            double Sum = 0;
            for (int k = 0; k < n; k++)
            {
                double M = 1;
                for (int i = 0; i < n; i++) if (i != k) M *= Math.Sin(Math.PI * (x - X[i]) / T);
                Sum += Q[k] * M;
            } 
         /*   double Sum = A[0];
            for (int k = 1; k <= n; k++)
            {
                Sum += A[k] * Math.Cos(k * Math.PI * x / T) + B[k] * Math.Sin(k * Math.PI * x / T);
            }  */
            return Sum;
        }

        private void DrawGraphics()
        {
            int Xscr1, Yscr1, Xscr2, Yscr2;

            double Lx = K * Math.Pow(2, trackBar2.Value) * (Xmax - Xmin);
            double Ly = K * Math.Pow(2, trackBar1.Value) * (Ymax - Ymin);

            XGmin = Xc - Dx - Lx / 2;
            XGmax = Xc - Dx + Lx / 2;
            YGmin = Yc + Dy - Ly / 2;
            YGmax = Yc + Dy + Ly / 2;
            Kx = (Bmp.Width - 1) / Lx;
            Ky = (Bmp.Height - 1) / Ly;

            Pic.Clear(Color.White);
            for (int i = 0; i <= 20; i++) Pic.DrawLine(PenCell, i * (Bmp.Width - 1) / 20, 0, i * (Bmp.Width - 1) / 20, Bmp.Height - 1);
            for (int i = 0; i <= 6; i++) Pic.DrawLine(PenCell, 0, i * (Bmp.Height - 1) / 6, Bmp.Width - 1, i * (Bmp.Height - 1) / 6);

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

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < MaxPoints; i++) { X[i] = 0; Y[i] = 0; }
            textBox1.Text = "X( 1 ) = ";
            textBox2.Text = String.Format("{0:f6}", X[0]);
            textBox3.Text = "Y( 1 ) = ";
            textBox4.Text = String.Format("{0:f6}", Y[0]);
            textBox5.Text = String.Format("{0:f12}", T);
            Bmp = new Bitmap(pictureBox1.Width - 4, pictureBox1.Height - 4);
            Pic = Graphics.FromImage(Bmp);
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
            if (listBox1.Items.Count >= 3) button4.Enabled = true;
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
                    X[i] = X[i + 1]; Y[i] = Y[i + 1];
                    listBox1.Items.Insert(i, String.Format("X( {0:d} ) = {1:f6}        Y( {0:d} ) = {2:f6}", i + 1, X[i], Y[i]));
                    listBox1.Items.RemoveAt(i + 1);
                }
                X[n] = 0; Y[n] = 0;
                if (ni == n) ni--;
                if (ni >= 0) listBox1.SetSelected(ni, true); else ni++;
                if (n < 3) button4.Enabled = false;
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
            T = Double.Parse(textBox5.Text);

            for (int k = 0; k < n; k++)
            {
                double M = 1;
                for (int i = 0; i < n; i++) if (i != k) M *= Math.Sin(Math.PI * (X[k] - X[i]) / T);
                Q[k] = Y[k] / M;
            }

            for (int i = 0; i <= n; i++) { A[i] = 0; B[i] = 0; }
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i <= n; i++) { a[i] = 0; b[i] = 0; }
                a[0] = Q[k];
                for (int i = 0; i < n; i++)
                    if (i != k)
                    {
                        for (int j = 0; j <= n + 1; j++) { a1[j] = 0; b1[j] = 0; }
                        a1[0] = (-a[1] * Math.Sin(Math.PI * X[i] / T) + b[1] * Math.Cos(Math.PI * X[i] / T)) / 2;
                        a1[1] = -a[0] * Math.Sin(Math.PI * X[i] / T);
                        b1[1] = a[0] * Math.Cos(Math.PI * X[i] / T);
                        a1[2] = -(a[1] * Math.Sin(Math.PI * X[i] / T) + b[1] * Math.Cos(Math.PI * X[i] / T)) / 2;
                        b1[2] = (a[1] * Math.Cos(Math.PI * X[i] / T) - b[1] * Math.Sin(Math.PI * X[i] / T)) / 2;
                        for (int j = 2; j <= n; j++)
                        {
                            a1[j - 1] += (-a[j] * Math.Sin(Math.PI * X[i] / T) + b[j] * Math.Cos(Math.PI * X[i] / T)) / 2;
                            b1[j - 1] += -(a[j] * Math.Cos(Math.PI * X[i] / T) + b[j] * Math.Sin(Math.PI * X[i] / T)) / 2;
                            a1[j + 1] += -(a[j] * Math.Sin(Math.PI * X[i] / T) + b[j] * Math.Cos(Math.PI * X[i] / T)) / 2;
                            b1[j + 1] += (a[j] * Math.Cos(Math.PI * X[i] / T) - b[j] * Math.Sin(Math.PI * X[i] / T)) / 2;
                        }
                        for (int j = 0; j <= n; j++) { a[j] = a1[j]; b[j] = b1[j]; }
                    }
                for (int i = 0; i <= n; i++) { A[i] += a[i]; B[i] += b[i]; }
            }

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
//            trackBar1.Value = 0;
//            trackBar2.Value = 0;
            Xc = (Xmin + Xmax) / 2;
            Yc = (Ymin + Ymax) / 2;
            K = 1;
            LG = true;
            DrawGraphics();
            listBox2.Items.Clear();
            listBox2.Items.Add(string.Format("A0 = {0:f12}", A[0]));
            for (int k = 1; k <= n; k++) 
                listBox2.Items.Add(string.Format("A{0:d} = {1:f12}             B{0:d} = {2:f12}", k, A[k], B[k]));
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!LG) return;
            if (e.Button == MouseButtons.Middle)
            {
                label3.Visible = false;
                Dx = (e.X - Xb) / Kx;
                Dy = (e.Y - Yb) / Ky;
                DrawGraphics();
            }
            else
            {
                label3.Visible = true;
                double x = XGmin + e.X / Kx;
                double y = YGmin + (Bmp.Height - 1 - e.Y) / Ky;
                label3.Text = string.Format("( {0:f4}, {1:f4} )", x, y);
                label3.Left = e.X + pictureBox1.Left + 12;
                label3.Top = e.Y + pictureBox1.Top + 12;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label3.Visible = false;
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
            label3.Visible = true;
            double x = XGmin + e.X / Kx;
            double y = YGmin + (Bmp.Height - 1 - e.Y) / Ky;
            label3.Text = string.Format("( {0:f4}, {1:f4} )", x, y);
            label3.Left = e.X + pictureBox1.Left + 12;
            label3.Top = e.Y + pictureBox1.Top + 12;
        }
    }
}
