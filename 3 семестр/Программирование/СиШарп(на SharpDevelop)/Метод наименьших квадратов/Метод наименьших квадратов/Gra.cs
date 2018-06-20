/*
 * Сделано в SharpDevelop.
 * Пользователь: Алевтина
 * Дата: 19.12.2014
 * Время: 19:27
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Метод_наименьших_квадратов {
	/// <summary>
	/// Объект для работы с графиком.
	/// </summary>
	public partial class Gra : UserControl {
		//Внешние функции для отрисовки
		public delegate double ExternalFunction(double x);
		private ExternalFunction[] f = new ExternalFunction[20];
		private int NumOfF;
		private int[] FuncColors;

		
		private double ShiftX;//Сдвиг по ОХ в реальных еденицах
		private double ShiftY;//Сдвиг по ОY в реальных еденицах
		private double ScaleX;//Сколько пикселей в реальной еденице
		private double ScaleY;//Сколько пикселей в реальной еденице
		
		private double[] ScaleINFO;//Данные для обработки масштабирования
		private double[] DragINFO;//Данные для обработки перетаскивания
		private double[,] XY;//Точки для отрисовки
		private int NumOfPt;
		private Graphics Pic;
        private Bitmap Bmp;
		
		
		public Gra() {
			//(Application.OpenForms[0] as MainForm).listBox2.Items.Clear();
        	//MessageBox.Show(x.ToString(),y.ToString(),MessageBoxButtons.OK);
			NumOfF = 0;
			FuncColors = new int[20]; 
			ScaleINFO = new Double[3];
			XY = new double[2,0];
			NumOfPt = 0;			
			DragINFO = new double[5];
			DragINFO[0] = 0;
			InitializeComponent();
		}
		
		
		
		public bool SetXY(double[]X,double[]Y, int N) {
			XY=new double[2,N];
			NumOfPt = N;
			try {
				for(int i=0;i<N;i++) {
					XY[0,i]=X[i];
					XY[1,i]=Y[i];
				};
			} catch {return false;};
			return true;
		}
		
        
		
		/// <summary>
		/// Рисует точку с учетом текущего масштаба и смещения.
		/// </summary>
		public void PntXY(double x, double y, int size=6, int c=1) {
        	Brush Clr = Brushes.Black;
			switch(c) {
				case 0:	Clr = Brushes.Black; break;
				case 1:	Clr = Brushes.Red; break;
				case 2:	Clr = Brushes.Green; break;
				case 3:	Clr = Brushes.Yellow; break;
				case 4:	Clr = Brushes.Violet;	break;
				case 5:	Clr = Brushes.Chocolate; break;
				case 6:	Clr = Brushes.BlueViolet;	break;
			};
        	try {Pic.FillEllipse(Clr,(float)(ScaleX*(x-ShiftX))-size/2,(float)(pb.Height-ScaleY*(y-ShiftY))-size/2,size,size);} catch{};
		}
		
		
		
		/// <summary>
		/// Рисует линию с учетом текущего масштаба и смещения.
		/// </summary>
		public void DrawLine(double x1, double y1, double x2, double y2, int size=1, int c=0) {
			Pen Clr = new Pen(Color.Black);
			switch(c) {
				case 0:	Clr.Color = Color.Black; break;
				case 1:	Clr.Color = Color.Red; break;
				case 2:	Clr.Color = Color.Green; break;
				case 3:	Clr.Color = Color.Yellow; break;
				case 4:	Clr.Color = Color.Violet;	break;
				case 5:	Clr.Color = Color.Chocolate; break;
				case 6:	Clr.Color = Color.BlueViolet;	break;
				case 7:	Clr.Color = Color.Gray;	break;
			};
			Clr.Width = (float)size;
        	try {
        	Pic.DrawLine(Clr,(float)(ScaleX*(x1-ShiftX)),(float)(pb.Height-ScaleY*(y1-ShiftY)),(float)(ScaleX*(x2-ShiftX)),(float)(pb.Height-ScaleY*(y2-ShiftY)));
        	} catch{};
		}
				
		
		
		/// <summary>
		/// Отрисовка заданных точек и линий
		/// </summary>
		public void DrawAll(bool auto=true) {
			//Bmp = new Bitmap(pb.Width,pb.Height);
			//Pic = Graphics.FromImage(Bmp);
			Pic.Clear(Color.White);
			float xmax=(float)((pb.Width)/ScaleX+ShiftX);
			float d=(float)(xmax-ShiftX)/128;
//Отрисовка заданных функций
			for(int i=0;i<NumOfF;i++)
				for (float x=(float)ShiftX;x<xmax;x+=d)
					DrawLine(x,f[i](x),x+d,f[i](x+d),1,FuncColors[i]);
           	

//Сеточка 10х10
			
            for(int i=(int)Math.Round(10*ShiftX*ScaleX/pb.Width);i<(int)Math.Round(10*ShiftX*ScaleX/pb.Width)+11;i++)
             	DrawLine(i*pb.Width/(10*ScaleX),ShiftY,i*pb.Width/(10*ScaleX),ShiftY+pb.Height/ScaleY,1,7);
            
       		Parallel.For((int)Math.Round(10*ShiftY*ScaleY/pb.Height),(int)Math.Round(10*ShiftY*ScaleY/pb.Height)+11,i=>{
				DrawLine(ShiftX,i*pb.Height/(10*ScaleY),ShiftX+pb.Width/ScaleX,i*pb.Height/(10*ScaleY),1,7);
             });
//Отрисовка координатных осей
			DrawLine(0,ShiftY,0,ShiftY+ pb.Height/ScaleY,2);
			DrawLine(ShiftX,0,ShiftX+pb.Width/ScaleX,0,2);
//Расстановка заданных точек
			if (auto)
				Parallel.For(0,NumOfPt,i=>{
					PntXY(XY[0,i],XY[1,i]);
				});
			pb.Image = Bmp;
		}
		
		
		
		/// <summary>
		/// Очищает область вывода и сбрасывает масштаб.
		/// </summary>
		public void Clear(Color c) {
			//Pic = Graphics.FromImage(Bmp);
			Pic.Clear(c);
			Hscale.Value = 0;
			Vscale.Value = 0;
			ScaleY = ScaleX = 1;
			ShiftX = ShiftY = 0;
		}
		
		
		
		/// <summary>
		/// Определяет прямоугольную область, которая будет отображаться.
		/// Если auto=true, установление в согласии с внутренним массивом точек 
		/// </summary>
		public bool SelectArea(double xmin=0, double ymin=0, double xmax=0, double ymax=0, int h=10, bool auto=false) {
			Hscale.Value = 0;
			Vscale.Value = 0;
			if(xmin==xmax && ymin==ymax) {xmin=0;ymin=0;xmax=1;ymax=1; auto=true;};
//Определение области отображения по заданным точкам
			if (auto) {
				xmin=xmax=XY[0,0];
				ymin=ymax=XY[1,0];
//Область, содержащая все точки
				for(int i=0;i<NumOfPt;i++) {
					if (xmin>XY[0,i]) xmin=XY[0,i];
					if (xmax<XY[0,i]) xmax=XY[0,i];
					if (ymin>XY[1,i]) ymin=XY[1,i];
					if (ymax<XY[1,i]) ymax=XY[1,i];
			};
				};
				ScaleX = Math.Pow(2,Hscale.Value)*(pb.Width*(1-0.02*h))/(xmax-xmin);
				ScaleY = Math.Pow(2,Vscale.Value)*(pb.Height*(1-0.02*h))/(ymax-ymin);
				ShiftX = xmin-(pb.Width*0.01*h)/ScaleX;
				ShiftY = ymin-(pb.Height*0.01*h)/ScaleY;	
				ScaleINFO[0] = ScaleX;
				ScaleINFO[1] = ScaleY;
				return true;
			
			
		}
		
		
		
		/// <summary>
		/// Добавление внешних функций для отрисовки
		/// </summary>
		public bool AddF(ExternalFunction f0, int c=0) {
			//Не добавлена ли уже эта функция?
			for (int i=0;i<NumOfF;i++)
				if (f0.Equals(f[i])) return false;
			//Расширить массив по необходимости
			if (NumOfF>=f.Length-10) {
				Array.Resize(ref FuncColors, FuncColors.Length + 20);
				Array.Resize(ref f, f.Length+20);
			};
			//Добавить новую функцию Для отобраэения
			this.f[NumOfF]= (ExternalFunction)f0;
			FuncColors[NumOfF] = c;
			NumOfF++;
			return true;
		}
		
		
		
		
		/// <summary>
		/// Набор событий, обрабатывающих перетаскивание и масштабирование
		/// </summary>
		void PbMouseDown(object sender, MouseEventArgs e) {
			DragINFO[0]=1;
			DragINFO[1]=e.X;
			DragINFO[2]=e.Y;
			DragINFO[3]=ShiftX;
			DragINFO[4]=ShiftY;
		}
		
		void PbMouseMove(object sender, MouseEventArgs e) {
			XYtip.Visible=true;
			if(DragINFO[0]==1) {
				ShiftX = DragINFO[3] + (DragINFO[1]-e.X)/ScaleX;
				ShiftY = DragINFO[4] - (DragINFO[2]-e.Y)/ScaleY;
				Pic.Clear(Color.White);
				DrawAll();
				DragINFO[0]=0;
				timer1.Enabled = true;
			};
			XYtip.Top = e.Y+13;
			XYtip.Left = e.X+13;
			XYtip.Text = "X = " + (e.X/ScaleX + ShiftX).ToString("G4") + ";\nY =  " + ((pb.Height - e.Y)/ScaleY + ShiftY).ToString("G4");
		}
		
		void PbMouseUp(object sender, MouseEventArgs e) {
			DragINFO[0] = 0;
			timer1.Enabled = false;
		}
		
		void HscaleScroll(object sender, EventArgs e) {
			ScaleX = ScaleINFO[0]*Math.Pow(2,Hscale.Value);
			DrawAll();
		}
		
		void VscaleScroll(object sender, EventArgs e) {
			ScaleY = ScaleINFO[1]*Math.Pow(2,Vscale.Value);
			DrawAll();			
		}
		
		void PbMouseLeave(object sender, EventArgs e) {
			XYtip.Visible=false;
		}
		
		
		void GraLoad(object sender, EventArgs e)
		{
			
			Bmp = new Bitmap(pb.Width,pb.Height);
			Pic = Graphics.FromImage(Bmp);
		}
		
		void Timer1Tick(object sender, EventArgs e) {
			DragINFO[0]=1;
			timer1.Enabled = false;
		}
	}
}
