/*
 * Сделано в SharpDevelop.
 * Пользователь: Алевтина
 * Дата: 16.12.2014
 * Время: 19:26
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Метод_наименьших_квадратов {
	/// <summary>
	/// Набор методов, реализующих приближение полиномом по методу наименьших квадратов. 
	/// </summary>
	public class MNK{
		private MatrixCalc Mtx;
		
		public double[,]A;
		public double[]PP;
		private int Pnum;
		private double[]XX;
		private double[]YY;
		private int N;
		
		
		/// <summary>
		/// Конструктор с передачей объекту готовых массивов с измерениями.
		/// </summary>
		public MNK(double[]X,double[]Y, int nn) {
			Mtx = new MatrixCalc();
			N=nn;
			XX=(double[])X.Clone();
			YY=(double[])Y.Clone();
		}
		
		
		/// <summary>
		/// Конструктор, не заполняющий таблицу измерений.
		/// </summary>
		public MNK() {
			Mtx = new MatrixCalc();
			N=0;
			XX=new double[100];
			YY=new double[100];
		}
		
		
		/// <summary>
		/// Расчет полинома степени inputnum.
		/// Если рассчет не удался, вернёт false.
		/// </summary>
		public bool MNKmake(int num) {
			num=num+1;
			//Проверка на решаемость системы
			Pnum=num;
			//if (Pnum<N) return false;
			//Составление системы для приближения полиномом
			A=new double[num,num+1];
			PP=new double[num];
			for(int x=0;x<num;x++)
					for(int y=0;y<num;y++) {
						A[y,x]=0;
						for(int i=0;i<N;i++)
							A[y,x]+=Math.Pow(XX[i],x+y);
				};
			for(int y=0;y<num;y++) {
					A[y,num]=0;
					for(int i=0;i<N;i++)
						A[y,num]+=YY[i]*Math.Pow(XX[i],y);	
			};
			if(Mtx.rootArray(num,A,PP)) return true; else return false;
			
		}
		
		
		/// <summary>
		/// Добавить измерение.
		/// </summary>
		public void Add(double x, double y) {
			if (N>=XX.Length-10) Array.Resize(ref XX, XX.Length+100);
			XX[N]=x;
			YY[N]=y;
			N++;
		}
		
		
		/// <summary>
		/// Заменить измерение.
		/// </summary>
		public bool Replace(double x, double y, int id) {
			if (id>=N) return false;
			XX[id]=x;
			YY[id]=y;
			N++;
			return true;
		}
		
		
		
		/// <summary>
		/// Очистить таблицу измерений.
		/// </summary>
		public void Clear() {
			N=0;
		}
		
		
		/// <summary>
		/// Функция-полином от х, приближенный методом наименьших квадратов.
		/// </summary>
		public double MNKfunc(double x) {
			double f=0;
			for(int i=0;i<Pnum;i++)
				f+=PP[i]*Math.Pow(x,i);
			return f;
		}
		
	}
}
