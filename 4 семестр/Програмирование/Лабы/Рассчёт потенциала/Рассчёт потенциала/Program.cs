/*
 * Сделано в SharpDevelop.
 * Пользователь: Алевтина
 * Дата: 16.03.2015
 * Время: 10:18
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;

namespace Рассчёт_потенциала {
	class Program {
		public static void Main(string[] args) {
		
	
		double F0 = 5, xl = 100, yl = 100;
		int dx=2,dy=2, nx=(int)xl/dx, ny=(int)yl/dy;
		double [,,]Ft = new double[nx,ny,2];
		
		for(int i = 0; i <nx; i++)
			for(int j = 0; j <ny; j++) {
				Ft[i,0,0]=F0;
				Ft[i,ny-1,0]=F0;
				Ft[0,j,0]=F0;
				Ft[nx-1,j,0]=F0;
			};
		
		
			for(int m=0;m<100;m++) {
				Console.WriteLine("set pm3d hidden3d");
				Console.WriteLine("splot [0:"+ny+"] [0:"+nx+"] \"-\" with lines");
				for(int i = 0; i <nx; i++) {
					for(int j = 0; j <ny; j++)
						Console.WriteLine(Ft[i,j,0]);
					Console.WriteLine();
				};
				Console.WriteLine("end");
				Console.WriteLine("pause 0.05");
				
				for(int i = 1; i <nx-1; i++)
					for(int j = 1; j <ny-1; j++)
						Ft[i,j,1] = (Ft[i+1,j,0]+ Ft[i-1,j,0] + Ft[i,j+1,0]  + Ft[i,j-1,0])/(double)4;
						
				
				for(int i = 1; i <nx-1; i++)
					for(int j = 1; j <ny-1; j++)
						Ft[i,j,0]=Ft[i,j,1];

			};
		
		}
	
	}
}