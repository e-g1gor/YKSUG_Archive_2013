/*
 * Сделано в SharpDevelop.
 * Пользователь: Алевтина
 * Дата: 12.12.2014
 * Время: 22:10
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;

namespace Метод_наименьших_квадратов {
/// <summary>
/// Определитель, умнеожение матриц, вычисление корней.
/// </summary>
	public class MatrixCalc	{
		public MatrixCalc() {}

		
/// <summary>
/// Умножение матриц.
/// Y=A*B
/// Если матрицы невозможно умножить, вернёт false
/// </summary>
		public bool MulMat(double[,]A,double[,]B,double[,]Y,int xs,int ys,int zs) {
			double[,]X1 = (double[,])A.Clone();	
			double[,]X2 = (double[,])B.Clone();
			try {
				for(int i=0;i<xs;i++)
					for(int j=0;j<zs;j++) {
						Y[i,j]=0;
						for (int k=0;k<ys;k++) Y[i,j]+=X1[i,k]*X2[k,j];
					};
			} catch {return false;};
			return true;
		}
		
		
/// <summary>
/// Определитель nn x nn верхнего левого угла матрицы X.
/// </summary>
		public double DET(int nn,double[,]X0) {
//Метод Гаусса
			double[,]X=new Double[nn,nn];
			X=(double[,])X0.Clone();
            double p,d = 1;
            int j0=0;
//какой столбец зануляется
            for (int i=0;i<nn;i++) {
//Нахождение строки с ненулевым элементом
            	for (int j=i;j<nn;j++)
            		if (X[j,i]!=0) {j0=j;break;};
//Перестановка
if (j0!= i) d=-d;
			for (int j=0;j<nn;j++) {
				p=X[j0,j];
				X[j0,j]=X[i,j];
				X[i,j]=p;
			};
//Зануление i-того столбца
//обработка j-той строки
            	for (int j=0;j<nn;j++) {
            		p=X[j,i]/X[i,i];
//пробег по элементам j-той строки
            		if (j!=i) for (int k=0;k<nn;k++)
            			X[j,k]-=p*X[i,k];
            	};
            };
			for (int j=0;j<nn;j++) d*=X[j,j];
            return d;
        }
		
		
		
//Вычисление корней системы линейных уравнений(метод Крамера). 
//Входные данные - массив(матрица системы)[nn,nn+1], уравнение<=>1 индекс(строка). Номер меременной <=> второй индекс(столбец)
//Возвращает массив корней, индекс корня <=> индекс переменной.
		public bool rootArray(int nn, double[,]X0, double[]Y) {
//X[ny,ny+1] , Y[ny]
//Метод Гаусса
			double[,]X=new Double[nn,nn];
			X=(double[,])X0.Clone();
			double p,d = 1;
            int j0;
//какой столбец зануляется
            for (int i=0;i<nn;i++) {
//Нахождение строки с ненулевым элементом
				j0=-1;
            	for (int j=i;j<nn;j++)
            		if (X[j,i]!=0) {j0=j;break;};
//Если нет корней
            	if (j0==-1) return false;
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
            	};
            };
//Вычисление корней
            for (int j=0;j<nn;j++)
            	Y[j]=X[j,nn]/X[j,j];
            return true;
		}
		
		
		
	}
}
