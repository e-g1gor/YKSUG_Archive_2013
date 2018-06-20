/*
 * Сделано в SharpDevelop.
 * Пользователь: Алевтина
 * Дата: 15.11.2014
 * Время: 11:55
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Метод_наименьших_квадратов {	
	public partial class MainForm : Form {
		MNK mnkcal;
		int inx;
		double[] X,Y;
		
		
		public MainForm() {
			X = new Double[1000];
			Y = new Double[1000];
			inx=-1;
			InitializeComponent();
			for (int i=0;i<20;i++)
				comboBox1.Items.Add(i);
		}
		
		
				
//Заполнение таблицы измерений(listbox1).
//Индекс элемента
		void ListBox1MouseDown(object sender, MouseEventArgs e) {inx=listBox1.SelectedIndex;}
//Ввод строки
		void BtINClick(object sender, System.EventArgs e) {
			if (inx==-1) inx=listBox1.Items.Count; else 
				listBox1.Items.RemoveAt(inx);
			Double.TryParse(Xtxt.Text,out X[inx]);
			Double.TryParse(Ytxt.Text,out Y[inx]);
			listBox1.Items.Insert(inx,"y = "+Y[inx]+";          x = "+X[inx]);
			inx=-1;
		}
//Удаление строки
		void BtDELClick(object sender, EventArgs e) {
			if (inx!=-1) {
				for(int i=inx;i<listBox1.Items.Count;i++) {
					X[i]=X[i+1];
					Y[i]=Y[i+1];
				};
				listBox1.Items.RemoveAt(inx);
			};
			inx=-1;
		}
//Очистка списка
		void BtCLRClick(object sender, EventArgs e) {
			if (DialogResult.Yes==MessageBox.Show("Очистить список?","Внимание!",MessageBoxButtons.YesNo,MessageBoxIcon.Question)) {
				listBox1.Items.Clear();
				inx=-1;
			};
		}
//Переход к другому полю и ввод клавишей ENTER
		void XtxtKeyDown(object sender, KeyEventArgs e) {
			if (e.KeyValue==13) {BtINClick(sender,e);Xtxt.Focus();Xtxt.SelectAll();}
		}
		void YtxtKeyDown(object sender, KeyEventArgs e) {
			if (e.KeyValue==13) {Ytxt.Focus();Ytxt.SelectAll();}
		}
		
		
//Отображение графика.				
		void Button1Click(object sender, EventArgs e) {
			mnkcal = new MNK(X,Y,listBox1.Items.Count);
			gra1.SetXY(X,Y,listBox1.Items.Count);
//Область, содержащая все точки
			gra1.SelectArea();

//MNK		
			if(comboBox1.SelectedIndex>=0)
				mnkcal.MNKmake(comboBox1.SelectedIndex);	
			else
				mnkcal.MNKmake(1);
		
			gra1.AddF((x)=>mnkcal.MNKfunc(x));
			gra1.DrawAll();
		}	
		
		
		void Button2Click(object sender, EventArgs e) {
			Random rnd = new Random();
			for (int i=0; i<100;i++) {
				inx=listBox1.Items.Count;
				X[inx] = i;
				Y[inx] = i + 10*(rnd.NextDouble()-0.5);
				listBox1.Items.Insert(inx,"y = "+Y[inx]+";          x = "+X[inx]);	
			};
		}
		

	}
}

