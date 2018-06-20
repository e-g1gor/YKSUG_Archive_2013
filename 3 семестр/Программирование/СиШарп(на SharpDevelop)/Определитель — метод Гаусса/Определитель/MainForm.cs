/*
 * Сделано в SharpDevelop.
 * Пользователь: Алевтина
 * Дата: 07.10.2014
 * Время: 18:59
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Определитель {
	public partial class MainForm : Form {
		double[,]A;
		double[,]B;
		double[]C;
		int x,y,z;
		Random rnd = new Random();
		Graphics gr1,gr2,gr3;
		
		
		
		
		public MainForm() {InitializeComponent();}
		
		
		
		
		void Button1Click(object sender, EventArgs e) {
			gr1=pb1.CreateGraphics();
			gr2=pb2.CreateGraphics();
			gr3=pb3.CreateGraphics();
			gr1.Clear(Color.White);
			gr2.Clear(Color.White);
			gr3.Clear(Color.White);
			x=strm.Value;
			y=intm.Value;
			z=stlbm.Value;
			A=new Double[x,x+1];
			B=new Double[y,z];
			C=new Double[x+1];
			
			for(int i=0;i<x;i++)
				for(int j=0;j<y;j++) {
				A[i,j]=Math.Round(-0.5+rnd.NextDouble()*9);
				gr1.DrawString(A[i,j].ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 5-5*(float)Math.Floor(A[i,j]/10)+30*j, 5+30*i);
			};		
			
			for(int i=0;i<y;i++)
				for(int j=0;j<z;j++) {
				B[i,j]=Math.Round(1+rnd.NextDouble()*9);
				gr2.DrawString(B[i,j].ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 5-5*(float)Math.Floor(B[i,j]/10)+30*j, 5+30*i);
			};			

		}
		
		
	
		void Button2Click(object sender, EventArgs e) {
			rootArray(x,A,C);
			for(int i=0;i<x;i++) 
				gr3.DrawString(C[i].ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 5, 5+50*i);
			
			
			
			
		}
		
		
		
		//определ
		void Button3Click(object sender, EventArgs e) {
			label1.Text="det(A) = " + DET(x,A);
		}
				
		
		public void MulMat(double[,]X1,double[,]X2,double[,]X3,int xs,int ys,int zs) {//Х3=Х1*Х2
			for(int i=0;i<xs;i++)
				for(int j=0;j<zs;j++) {
					X3[i,j]=0;
					for (int k=0;k<ys;k++) X3[i,j]+=X1[i,k]*X2[k,j];
				};
		}
		
		
		public double DET(int nn,double[,]X) {
            double p,d = 1;
            int j0;
//какой столбец зануляется
            for (int i=0;i<nn;i++) {
//Нахождение строки с ненулевым элементом
				j0=-1;
            	for (int j=i;j<nn;j++)
            		if (X[j,i]!=0) {j0=j;break;};
//Перестановка
				if (j0!=i) d=-d;
				for (int j=0;j<nn+1;j++) {
					p=X[j0,j];
					X[j0,j]=X[i,j];
					X[i,j]=p;
				};
//Зануление i-того столбца
//обработка j-той строки
            	for (int j=0;j<nn;j++) {
            		p=X[j,i]/X[i,i];
//пробег по элементам j-той строки
            		if (j!=i) for (int k=0;k<nn+1;k++)
            			X[j,k]-=p*X[i,k];
            		gr3.Clear(Color.White);
            		for(int x=0;x<nn;x++)
						for(int y=0;y<nn+1;y++) 
							gr3.DrawString((Math.Round(10*X[x,y])/10).ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), 5+50*y, 5+30*x);
            		MessageBox.Show("Next","Next",MessageBoxButtons.OK);
            	};
            };
            for (int j=0;j<nn;j++)
            	d*=X[j,j];
            	
            return d;
        }
		
		
		
		//Вычисление корней системы линейных уравнений. 
		//Входные данные - массив(матрица системы)[х,х+1], уравнение<=>1 индекс(строка). Номер меременной <=> второй индекс(столбец)
		//Возвращает массив корней с первого до последнего.
		public void rootArray(int n, double[,]X, double[]Y) {//X[ny,ny+1] , Y[ny]
			double[,] TMP = new Double[n, n+1];
			double d=DET(n,X);
			for (int i = 0; i < n; i++) {
				TMP=(double[,])X.Clone();
				for (int j = 0; j < n; j++)
					TMP[j,i]=X[j,n];
				Y[i]=DET(n,TMP)/d;
			};
		}
		
		
	}
}
