/*
 * Сделано в SharpDevelop.
 * Пользователь: Алевтина
 * Дата: 15.11.2014
 * Время: 11:55
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace Метод_наименьших_квадратов
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.btIN = new System.Windows.Forms.Button();
			this.btDEL = new System.Windows.Forms.Button();
			this.btCLR = new System.Windows.Forms.Button();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.Ytxt = new System.Windows.Forms.TextBox();
			this.Xtxt = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.gra1 = new Метод_наименьших_квадратов.Gra();
			this.button2 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(12, 9);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(234, 316);
			this.listBox1.TabIndex = 0;
			this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBox1MouseDown);
			// 
			// btIN
			// 
			this.btIN.Location = new System.Drawing.Point(12, 331);
			this.btIN.Name = "btIN";
			this.btIN.Size = new System.Drawing.Size(66, 34);
			this.btIN.TabIndex = 1;
			this.btIN.Text = "ВВОД";
			this.btIN.UseVisualStyleBackColor = true;
			this.btIN.Click += new System.EventHandler(this.BtINClick);
			// 
			// btDEL
			// 
			this.btDEL.Location = new System.Drawing.Point(84, 331);
			this.btDEL.Name = "btDEL";
			this.btDEL.Size = new System.Drawing.Size(81, 34);
			this.btDEL.TabIndex = 2;
			this.btDEL.Text = "УДАЛИТЬ";
			this.btDEL.UseVisualStyleBackColor = true;
			this.btDEL.Click += new System.EventHandler(this.BtDELClick);
			// 
			// btCLR
			// 
			this.btCLR.Location = new System.Drawing.Point(171, 331);
			this.btCLR.Name = "btCLR";
			this.btCLR.Size = new System.Drawing.Size(75, 34);
			this.btCLR.TabIndex = 3;
			this.btCLR.Text = "ОЧИСТИТЬ";
			this.btCLR.UseVisualStyleBackColor = true;
			this.btCLR.Click += new System.EventHandler(this.BtCLRClick);
			// 
			// listBox2
			// 
			this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.listBox2.FormattingEnabled = true;
			this.listBox2.Location = new System.Drawing.Point(573, 12);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(245, 316);
			this.listBox2.TabIndex = 7;
			// 
			// Ytxt
			// 
			this.Ytxt.Location = new System.Drawing.Point(165, 371);
			this.Ytxt.Name = "Ytxt";
			this.Ytxt.Size = new System.Drawing.Size(81, 20);
			this.Ytxt.TabIndex = 11;
			this.Ytxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XtxtKeyDown);
			// 
			// Xtxt
			// 
			this.Xtxt.Location = new System.Drawing.Point(38, 371);
			this.Xtxt.Name = "Xtxt";
			this.Xtxt.Size = new System.Drawing.Size(76, 20);
			this.Xtxt.TabIndex = 12;
			this.Xtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.YtxtKeyDown);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 376);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(21, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "x = ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(138, 376);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(21, 15);
			this.label2.TabIndex = 14;
			this.label2.Text = "y = ";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(573, 334);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(245, 31);
			this.button1.TabIndex = 15;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// gra1
			// 
			this.gra1.Location = new System.Drawing.Point(252, 9);
			this.gra1.Name = "gra1";
			this.gra1.Size = new System.Drawing.Size(315, 316);
			this.gra1.TabIndex = 17;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 397);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(234, 29);
			this.button2.TabIndex = 19;
			this.button2.Text = "Случайные точки на прямой";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(358, 325);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(83, 21);
			this.comboBox1.TabIndex = 20;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(252, 331);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 21;
			this.label3.Text = "Полином степени";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(830, 661);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.gra1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Xtxt);
			this.Controls.Add(this.Ytxt);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.btCLR);
			this.Controls.Add(this.btDEL);
			this.Controls.Add(this.btIN);
			this.Controls.Add(this.listBox1);
			this.Name = "MainForm";
			this.Text = "Метод наименьших квадратов";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button2;
		private Метод_наименьших_квадратов.Gra gra1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox Xtxt;
		private System.Windows.Forms.TextBox Ytxt;
		public System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Button btCLR;
		private System.Windows.Forms.Button btDEL;
		private System.Windows.Forms.Button btIN;
		private System.Windows.Forms.ListBox listBox1;
		

		

	}
}
