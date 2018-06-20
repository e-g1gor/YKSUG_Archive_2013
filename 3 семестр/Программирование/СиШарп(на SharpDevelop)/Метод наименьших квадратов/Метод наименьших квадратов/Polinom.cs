/*
 * Сделано в SharpDevelop.
 * Пользователь: Алевтина
 * Дата: 20.12.2014
 * Время: 0:10
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Метод_наименьших_квадратов
{
	/// <summary>
	/// Description of Polinom.
	/// </summary>
	public partial class Polinom : UserControl {
		public int n;
		public Polinom()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void RadioButton2CheckedChanged(object sender, EventArgs e)
		{
			n=2;
		}
		
		void RadioButton3CheckedChanged(object sender, EventArgs e)
		{
			n=3;			
		}
		
		void RadioButton4CheckedChanged(object sender, EventArgs e)
		{
			n=4;			
		}
		
		void RadioButton5CheckedChanged(object sender, EventArgs e)
		{
			n=5;			
		}
		
		void RadioButton6CheckedChanged(object sender, EventArgs e)
		{
			n=6;			
		}
		
		void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			n=1;			
		}
		
		void RadioButton7CheckedChanged(object sender, EventArgs e)
		{
			n=7;
		}
	}
}
