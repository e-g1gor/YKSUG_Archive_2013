/*
 * Сделано в SharpDevelop.
 * Пользователь: Алевтина
 * Дата: 19.12.2014
 * Время: 19:27
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
namespace Метод_наименьших_квадратов
{
	partial class Gra
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.components = new System.ComponentModel.Container();
			this.pb = new System.Windows.Forms.PictureBox();
			this.Vscale = new System.Windows.Forms.TrackBar();
			this.Hscale = new System.Windows.Forms.TrackBar();
			this.XYtip = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Vscale)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Hscale)).BeginInit();
			this.SuspendLayout();
			// 
			// pb
			// 
			this.pb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pb.Location = new System.Drawing.Point(3, 3);
			this.pb.Name = "pb";
			this.pb.Size = new System.Drawing.Size(176, 186);
			this.pb.TabIndex = 0;
			this.pb.TabStop = false;
			this.pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbMouseDown);
			this.pb.MouseLeave += new System.EventHandler(this.PbMouseLeave);
			this.pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbMouseMove);
			this.pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbMouseUp);
			// 
			// Vscale
			// 
			this.Vscale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Vscale.Location = new System.Drawing.Point(194, 3);
			this.Vscale.Maximum = 5;
			this.Vscale.Minimum = -5;
			this.Vscale.Name = "Vscale";
			this.Vscale.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.Vscale.Size = new System.Drawing.Size(45, 186);
			this.Vscale.TabIndex = 1;
			this.Vscale.Scroll += new System.EventHandler(this.VscaleScroll);
			// 
			// Hscale
			// 
			this.Hscale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Hscale.Location = new System.Drawing.Point(3, 192);
			this.Hscale.Maximum = 5;
			this.Hscale.Minimum = -5;
			this.Hscale.Name = "Hscale";
			this.Hscale.Size = new System.Drawing.Size(185, 45);
			this.Hscale.TabIndex = 2;
			this.Hscale.Scroll += new System.EventHandler(this.HscaleScroll);
			// 
			// XYtip
			// 
			this.XYtip.AutoSize = true;
			this.XYtip.BackColor = System.Drawing.Color.LemonChiffon;
			this.XYtip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.XYtip.Location = new System.Drawing.Point(60, 71);
			this.XYtip.Name = "XYtip";
			this.XYtip.Size = new System.Drawing.Size(34, 15);
			this.XYtip.TabIndex = 3;
			this.XYtip.Text = "XYtip";
			// 
			// timer1
			// 
			this.timer1.Interval = 20;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// Gra
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.XYtip);
			this.Controls.Add(this.Hscale);
			this.Controls.Add(this.Vscale);
			this.Controls.Add(this.pb);
			this.Name = "Gra";
			this.Size = new System.Drawing.Size(239, 240);
			this.Load += new System.EventHandler(this.GraLoad);
			((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Vscale)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Hscale)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label XYtip;
		private System.Windows.Forms.TrackBar Hscale;
		private System.Windows.Forms.TrackBar Vscale;
		private System.Windows.Forms.PictureBox pb;
	}
}
