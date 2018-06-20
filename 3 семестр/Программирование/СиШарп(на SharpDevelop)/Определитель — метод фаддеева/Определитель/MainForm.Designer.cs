/*
 * Сделано в SharpDevelop.
 * Пользователь: Алевтина
 * Дата: 07.10.2014
 * Время: 18:59
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace Определитель
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
			this.pb1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.strm = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.intm = new System.Windows.Forms.TrackBar();
			this.pb2 = new System.Windows.Forms.PictureBox();
			this.stlbm = new System.Windows.Forms.TrackBar();
			this.pb3 = new System.Windows.Forms.PictureBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.strm)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.intm)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stlbm)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb3)).BeginInit();
			this.SuspendLayout();
			// 
			// pb1
			// 
			this.pb1.Location = new System.Drawing.Point(63, 12);
			this.pb1.Name = "pb1";
			this.pb1.Size = new System.Drawing.Size(244, 225);
			this.pb1.TabIndex = 0;
			this.pb1.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 243);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(122, 43);
			this.button1.TabIndex = 1;
			this.button1.Text = "make";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(140, 243);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(114, 43);
			this.button2.TabIndex = 2;
			this.button2.Text = "mult";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// strm
			// 
			this.strm.Location = new System.Drawing.Point(12, 12);
			this.strm.Maximum = 16;
			this.strm.Minimum = 2;
			this.strm.Name = "strm";
			this.strm.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.strm.Size = new System.Drawing.Size(45, 225);
			this.strm.TabIndex = 3;
			this.strm.Value = 3;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 289);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(647, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "det(A)=...; p=...;";
			// 
			// intm
			// 
			this.intm.Location = new System.Drawing.Point(313, 12);
			this.intm.Maximum = 16;
			this.intm.Minimum = 2;
			this.intm.Name = "intm";
			this.intm.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.intm.Size = new System.Drawing.Size(45, 225);
			this.intm.TabIndex = 3;
			this.intm.Value = 3;
			// 
			// pb2
			// 
			this.pb2.Location = new System.Drawing.Point(364, 12);
			this.pb2.Name = "pb2";
			this.pb2.Size = new System.Drawing.Size(244, 225);
			this.pb2.TabIndex = 0;
			this.pb2.TabStop = false;
			// 
			// stlbm
			// 
			this.stlbm.Location = new System.Drawing.Point(614, 12);
			this.stlbm.Maximum = 6;
			this.stlbm.Minimum = 2;
			this.stlbm.Name = "stlbm";
			this.stlbm.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.stlbm.Size = new System.Drawing.Size(45, 225);
			this.stlbm.TabIndex = 3;
			this.stlbm.Value = 3;
			// 
			// pb3
			// 
			this.pb3.Location = new System.Drawing.Point(665, 12);
			this.pb3.Name = "pb3";
			this.pb3.Size = new System.Drawing.Size(305, 285);
			this.pb3.TabIndex = 0;
			this.pb3.TabStop = false;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(260, 243);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(112, 43);
			this.button3.TabIndex = 5;
			this.button3.Text = "det(A)";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(476, 346);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 6;
			this.button4.Text = "button4";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(395, 346);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 7;
			this.button5.Text = "button5";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(982, 414);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.stlbm);
			this.Controls.Add(this.intm);
			this.Controls.Add(this.strm);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pb3);
			this.Controls.Add(this.pb2);
			this.Controls.Add(this.pb1);
			this.Name = "MainForm";
			this.Text = "Определитель";
			((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.strm)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.intm)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stlbm)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.PictureBox pb3;
		private System.Windows.Forms.TrackBar stlbm;
		private System.Windows.Forms.PictureBox pb2;
		private System.Windows.Forms.TrackBar intm;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar strm;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pb1;
	}
}
