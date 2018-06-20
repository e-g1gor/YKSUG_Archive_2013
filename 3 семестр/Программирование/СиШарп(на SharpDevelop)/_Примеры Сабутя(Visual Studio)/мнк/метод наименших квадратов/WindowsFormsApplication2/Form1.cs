using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
   
    {
        double[] X = new Double[10000];
        double[] Y = new Double[10000];
        int n = 0;
        int ni = 0;
        double A0, A1, B0, B1, B2, C0, C1, C2, C3, D0, D1, D2, D3, D4, E0, E1, E2, E3, E4, E5, F0, F1, F2, F3, F4, F5, F6, S;
        double[,] MM = new Double[7, 7];
        string st;

        Graphics Pic;
        Pen PenCell = new Pen(Color.Chocolate);
        Pen PenAxis = new Pen(Color.DarkGray);
        Pen Pen1 = new Pen(Color.DarkSlateBlue);
        Pen Pen2 = new Pen(Color.BlueViolet);
        Pen Pen3 = new Pen(Color.DarkTurquoise);
        
        SolidBrush Brush1 = new SolidBrush(Color.Red);

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Text = "X( 1 ) = ";
            textBox1.Text = String.Format("{0:f6}", X[0]);
            textBox4.Text = "Y( 1 ) = ";
            textBox2.Text = String.Format("{0:f6}", Y[0]);
            Pic = pictureBox1.CreateGraphics();
        }
        private void DrawGraphics()
        {
            double x1, y1, x2, y2, Kx, Ky;         
            double Xmin = X[0];
            double Xmax = X[0];
            double Ymin = Y[0];
            double Ymax = Y[0];
            for (int i = 0; i < n; i++)
            {
                if (X[i] < Xmin) Xmin = X[i];
                if (X[i] > Xmax) Xmax = X[i];
                if (Y[i] < Ymin) Ymin = Y[i];
                if (Y[i] > Ymax) Ymax = Y[i];
            }
            if (Xmax != Xmin) { Kx = 0.95 * Math.Pow(2.0, trackBar1.Value) * pictureBox1.Width / (Xmax - Xmin); } else { Kx = 1; }
            if (Ymax != Ymin) { Ky = 0.95 * Math.Pow(2.0, trackBar2.Value) * pictureBox1.Height / (Ymax - Ymin); } else { Ky = 1; }

            Pic.Clear(Color.White);
            for (int i = 0; i <= 10; i++)
            {
                Pic.DrawLine(PenCell, i * pictureBox1.Width / 10, 0, i * pictureBox1.Width / 10, pictureBox1.Height);
                Pic.DrawLine(PenCell, 0, i * pictureBox1.Height / 10, pictureBox1.Width, i * pictureBox1.Height / 10);
            }

            y1 = (pictureBox1.Height / 2) + Ky * (Ymin + Ymax) / 2;
            if ((y1 >= 0) & (y1 <= pictureBox1.Height)) Pic.DrawLine(PenAxis, 0, (float)y1, pictureBox1.Width, (float)y1);
            x1 = pictureBox1.Width / 2 - Kx * (Xmin + Xmax) / 2;
            if ((x1 >= 0) & (x1 <= pictureBox1.Width)) Pic.DrawLine(PenAxis, (float)x1, 0, (float)x1, pictureBox1.Height);

            if (checkBox1.Checked & (n >= 2))
                for (int i = 0; i < pictureBox1.Width; i++)
                {
                    x1 = (i - pictureBox1.Width / 2) / Kx + (Xmin + Xmax) / 2;
                    y1 = (pictureBox1.Height / 2) - Ky * (A0 * x1 + A1 - (Ymin + Ymax) / 2);
                    x2 = (i + 1 - pictureBox1.Width / 2) / Kx + (Xmin + Xmax) / 2;
                    y2 = (pictureBox1.Height / 2) - Ky * (A0 * x2 + A1 - (Ymin + Ymax) / 2);
                    if (((y1 >= 0) & (y1 <= pictureBox1.Height)) | ((y2 >= 0) & (y2 <= pictureBox1.Height))) Pic.DrawLine(Pen1, (float)i, (float)y1, (float)(i + 1), (float)y2);
                }

            if (checkBox2.Checked & (n >= 3))
                for (int i = 0; i < pictureBox1.Width; i++)
                {
                    x1 = (i - pictureBox1.Width / 2) / Kx + (Xmin + Xmax) / 2;
                    y1 = (pictureBox1.Height / 2) - Ky * (B0 * x1 * x1 + B1 * x1 + B2 - (Ymin + Ymax) / 2);
                    x2 = (i + 1 - pictureBox1.Width / 2) / Kx + (Xmin + Xmax) / 2;
                    y2 = (pictureBox1.Height / 2) - Ky * (B0 * x2 * x2 + B1 * x2 + B2 - (Ymin + Ymax) / 2);
                    if (((y1 >= 0) & (y1 <= pictureBox1.Height)) | ((y2 >= 0) & (y2 <= pictureBox1.Height))) Pic.DrawLine(Pen2, (float)i, (float)y1, (float)(i + 1), (float)y2);
                }

            if (checkBox3.Checked & (n >= 4))
                for (int i = 0; i < pictureBox1.Width; i++)
                {
                    x1 = (i - pictureBox1.Width / 2) / Kx + (Xmin + Xmax) / 2;
                    y1 = (pictureBox1.Height / 2) - Ky * (C0 * x1 * x1 * x1 + C1 * x1 * x1 + C2 * x1 + C3 - (Ymin + Ymax) / 2);
                    x2 = (i + 1 - pictureBox1.Width / 2) / Kx + (Xmin + Xmax) / 2;
                    y2 = (pictureBox1.Height / 2) - Ky * (C0 * x2 * x2 * x2 + C1 * x2 * x2 + C2 * x2 + C3 - (Ymin + Ymax) / 2);
                    if (((y1 >= 0) & (y1 <= pictureBox1.Height)) | ((y2 >= 0) & (y2 <= pictureBox1.Height))) Pic.DrawLine(Pen3, (float)i, (float)y1, (float)(i + 1), (float)y2);
                }



            for (int i = 0; i < n; i++)
            {
                x1 = Kx * (X[i] - (Xmin + Xmax) / 2) + pictureBox1.Width / 2;
                y1 = pictureBox1.Height / 2 - Ky * (Y[i] - (Ymin + Ymax) / 2);
                Pic.FillEllipse(Brush1, (float)(x1 - 3), (float)(y1 - 3), 7, 7);
            }
        }

        public double DET(int nn)
 {
     double[,] AA = new Double[7, 7];
     double[,] BB = new Double[7, 7];
     double P = 0;
     for (int i = 0; i < nn; i++) for (int j = 0; j < nn; j++) BB[i, j] = 0;
     for (int i = 0; i < nn; i++) BB[i, i] = 1;
     for (int k = 1; k <= nn; k++)
     {
         for (int i = 0; i < nn; i++) for (int j = 0; j < nn; j++)
             {
                 AA[i, j] = 0;
                 for (int s = 0; s < nn; s++) AA[i, j] += MM[i, s] * BB[s, j];
             }
         P = 0;
         for (int i = 0; i < nn; i++) P += AA[i, i];
         P = -P / (double)k;
         for (int i = 0; i < nn; i++) for (int j = 0; j < nn; j++) BB[i, j] = AA[i, j];
         for (int i = 0; i < nn; i++) BB[i, i] += P;
     }
     return P;
 }


        private void button1_Click(object sender, EventArgs e)
        {
     if (ni == -1) ni = 0;
     X[ni] = Double.Parse(textBox1.Text);
     Y[ni] = Double.Parse(textBox2.Text);
     st = "X( " + String.Format("{0:d}", ni + 1) + " ) = " + String.Format("{0:f6}", X[ni]) + "        ";
     st += "Y( " + String.Format("{0:d}", ni + 1) + " ) = " + String.Format("{0:f6}", Y[ni]);
     listBox1.Items.Insert(ni, st);
     listBox1.SetSelected(ni, true);
     ni++;
     if (ni < listBox1.Items.Count) listBox1.Items.RemoveAt(ni);
     textBox3.Text = "X( " + String.Format("{0:d}", ni + 1) + " ) = ";
     textBox1.Text = String.Format("{0:f6}", X[ni]);
     textBox4.Text = "Y( " + String.Format("{0:d}", ni + 1) + " ) = ";
     textBox2.Text = String.Format("{0:f6}", Y[ni]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ni = listBox1.SelectedIndex;
            if (ni != -1)
            {
                listBox1.Items.RemoveAt(ni);
                n = listBox1.Items.Count;
                for (int i = ni; i < n; i++)
                {
                    X[i] = X[i + 1]; Y[i] = Y[i + 1];
                    st = "X( " + String.Format("{0:d}", i + 1) + " ) = " + String.Format("{0:f6}", X[i]) + "        ";
                    st += "Y( " + String.Format("{0:d}", i + 1) + " ) = " + String.Format("{0:f6}", Y[i]);
                    listBox1.Items.Insert(i, st);
                    listBox1.Items.RemoveAt(i + 1);
                }
                X[n] = 0; Y[n] = 0;
                if (ni == n) ni--;
                if (ni >= 0) { listBox1.SetSelected(ni, true); } else ni++;
                textBox3.Text = "X( " + String.Format("{0:d}", ni + 1) + " ) = ";
                textBox1.Text = String.Format("{0:f6}", X[ni]);
                textBox4.Text = "Y( " + String.Format("{0:d}", ni + 1) + " ) = ";
                textBox2.Text = String.Format("{0:f6}", Y[ni]);
            
        }

 


    }

        private void button3_Click(object sender, EventArgs e)
        {
         listBox1.Items.Clear();
     ni = 0;
     textBox3.Text = "X( 1 ) = ";
     textBox1.Text = String.Format("{0:f6}", X[0]);
     textBox4.Text = "Y( 1 ) = ";
     textBox2.Text = String.Format("{0:f6}", Y[0]);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         if (listBox1.SelectedIndex != -1)
     {
         ni = listBox1.SelectedIndex;
         textBox3.Text = "X( " + String.Format("{0:d}", ni + 1) + " ) = ";
         textBox1.Text = String.Format("{0:f6}", X[ni]);
         textBox4.Text = "Y( " + String.Format("{0:d}", ni + 1) + " ) = ";
         textBox2.Text = String.Format("{0:f6}", Y[ni]);
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
         double Sx, Sx2, Sx3, Sx4, Sx5, Sx6, Sx7, Sx8, Sx9, Sx10, Sx11, Sx12, Sy, Sxy, Sx2y, Sx3y, Sx4y, Sx5y, Sx6y;
     double XX;

     n = listBox1.Items.Count;
     listBox2.Items.Clear();

     Sx = 0; Sx2 = 0; Sx3 = 0; Sx4 = 0; Sx5 = 0; Sx6 = 0; Sx7 = 0; Sx8 = 0; Sx9 = 0; Sx10 = 0; Sx11 = 0; Sx12 = 0;
     Sy = 0; Sxy = 0; Sx2y = 0; Sx3y = 0; Sx4y = 0; Sx5y = 0; Sx6y = 0;
     for (int i = 0; i < n; i++)
     {
         Sy += Y[i];
         XX = X[i]; Sx += XX; Sxy += XX * Y[i];
         XX *= X[i]; Sx2 += XX; Sx2y += XX * Y[i];
         XX *= X[i]; Sx3 += XX; Sx3y += XX * Y[i];
         XX *= X[i]; Sx4 += XX; Sx4y += XX * Y[i];
         XX *= X[i]; Sx5 += XX; Sx5y += XX * Y[i];
         XX *= X[i]; Sx6 += XX; Sx6y += XX * Y[i];
         XX *= X[i]; Sx7 += XX;
         XX *= X[i]; Sx8 += XX;
         XX *= X[i]; Sx9 += XX;
         XX *= X[i]; Sx10 += XX;
         XX *= X[i]; Sx11 += XX;
         XX *= X[i]; Sx12 += XX;
     }

     if (checkBox1.Checked & (n >= 2))
     {
         A0 = (n * Sxy - Sx * Sy) / (n * Sx2 - Sx * Sx);
         A1 = (Sx2 * Sy - Sx * Sxy) / (n * Sx2 - Sx * Sx);
         S = 0;
         for (int i = 0; i < n; i++) S += (A0 * X[i] + A1 - Y[i]) * (A0 * X[i] + A1 - Y[i]);
         listBox2.Items.Add("1-ая степень:");
         listBox2.Items.Add("");
         listBox2.Items.Add("A0 = " + String.Format("{0:f6}", A0));
         listBox2.Items.Add("A1 = " + String.Format("{0:f6}", A1));
         listBox2.Items.Add("S = " + String.Format("{0:f6}", S));
         listBox2.Items.Add(""); listBox2.Items.Add("");
     }

     if (checkBox2.Checked & (n >= 3))
     {
         double dd = Sx4 * Sx2 * n + Sx3 * Sx * Sx2 + Sx2 * Sx3 * Sx - Sx2 * Sx2 * Sx2 - Sx3 * Sx3 * n - Sx4 * Sx * Sx;
         double d0 = Sx2y * Sx2 * n + Sx3 * Sx * Sy + Sx2 * Sxy * Sx - Sx2 * Sx2 * Sy - Sx3 * Sxy * n - Sx2y * Sx * Sx;
         double d1 = Sx4 * Sxy * n + Sx2y * Sx * Sx2 + Sx2 * Sx3 * Sy - Sx2 * Sxy * Sx2 - Sx2y * Sx3 * n - Sx4 * Sx * Sy;
         double d2 = Sx4 * Sx2 * Sy + Sx3 * Sxy * Sx2 + Sx2y * Sx3 * Sx - Sx2y * Sx2 * Sx2 - Sx3 * Sx3 * Sy - Sx4 * Sxy * Sx;
         B0 = d0 / dd; B1 = d1 / dd; B2 = d2 / dd;
         S = 0;
         for (int i = 0; i < n; i++) S += (B0 * X[i] * X[i] + B1 * X[i] + B2 - Y[i]) * (B0 * X[i] * X[i] + B1 * X[i] + B2 - Y[i]);
         listBox2.Items.Add("2-ая степень:");
         listBox2.Items.Add("");
         listBox2.Items.Add("A0 = " + String.Format("{0:f6}", B0));
         listBox2.Items.Add("A1 = " + String.Format("{0:f6}", B1));
         listBox2.Items.Add("A2 = " + String.Format("{0:f6}", B2));
         listBox2.Items.Add("S = " + String.Format("{0:f6}", S));
         listBox2.Items.Add(""); listBox2.Items.Add("");
     }

     if (checkBox3.Checked & (n >= 4))
     {
         MM[0, 0] = Sx6; MM[0, 1] = Sx5; MM[0, 2] = Sx4; MM[0, 3] = Sx3;
         MM[1, 0] = Sx5; MM[1, 1] = Sx4; MM[1, 2] = Sx3; MM[1, 3] = Sx2;
         MM[2, 0] = Sx4; MM[2, 1] = Sx3; MM[2, 2] = Sx2; MM[2, 3] = Sx;
         MM[3, 0] = Sx3; MM[3, 1] = Sx2; MM[3, 2] = Sx; MM[3, 3] = n;
         double dd = DET(4);
         MM[0, 0] = Sx3y; MM[1, 0] = Sx2y; MM[2, 0] = Sxy; MM[3, 0] = Sy;
         double d0 = DET(4);
         MM[0, 0] = Sx6; MM[1, 0] = Sx5; MM[2, 0] = Sx4; MM[3, 0] = Sx3;
         MM[0, 1] = Sx3y; MM[1, 1] = Sx2y; MM[2, 1] = Sxy; MM[3, 1] = Sy;
         double d1 = DET(4);
         MM[0, 1] = Sx5; MM[1, 1] = Sx4; MM[2, 1] = Sx3; MM[3, 1] = Sx2;
         MM[0, 2] = Sx3y; MM[1, 2] = Sx2y; MM[2, 2] = Sxy; MM[3, 2] = Sy;
         double d2 = DET(4);
         MM[0, 2] = Sx4; MM[1, 2] = Sx3; MM[2, 2] = Sx2; MM[3, 2] = Sx;
         MM[0, 3] = Sx3y; MM[1, 3] = Sx2y; MM[2, 3] = Sxy; MM[3, 3] = Sy;
         double d3 = DET(4);
         C0 = d0 / dd; C1 = d1 / dd; C2 = d2 / dd; C3 = d3 / dd;
         S = 0;
         for (int i = 0; i < n; i++) S += (C0 * X[i] * X[i] * X[i] + C1 * X[i] * X[i] + C2 * X[i] + C3 - Y[i]) * (C0 * X[i] * X[i] * X[i] + C1 * X[i] * X[i] + C2 * X[i] + C3 - Y[i]);
         listBox2.Items.Add("3-ая степень:");
         listBox2.Items.Add("");
         listBox2.Items.Add("A0 = " + String.Format("{0:f6}", C0));
         listBox2.Items.Add("A1 = " + String.Format("{0:f6}", C1));
         listBox2.Items.Add("A2 = " + String.Format("{0:f6}", C2));
         listBox2.Items.Add("A3 = " + String.Format("{0:f6}", C3));
         listBox2.Items.Add("S = " + String.Format("{0:f6}", S));
         listBox2.Items.Add(""); listBox2.Items.Add("");
     }


     DrawGraphics();
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((e.Delta > 0) & (trackBar1.Value < trackBar1.Maximum)) trackBar1.Value++;
            if ((e.Delta > 0) & (trackBar2.Value < trackBar2.Maximum)) trackBar2.Value++;
            if ((e.Delta < 0) & (trackBar1.Value > trackBar1.Minimum)) trackBar1.Value--;
            if ((e.Delta < 0) & (trackBar2.Value > trackBar2.Minimum)) trackBar2.Value--;
            DrawGraphics();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Select();
        }

       


    }
}

