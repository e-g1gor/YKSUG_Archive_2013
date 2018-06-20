<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pb = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pbvt = New System.Windows.Forms.PictureBox
        Me.TrackBar1 = New System.Windows.Forms.TrackBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.TrackBar2 = New System.Windows.Forms.TrackBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.TrackBar3 = New System.Windows.Forms.TrackBar
        Me.Label3 = New System.Windows.Forms.Label
        Me.tmax = New System.Windows.Forms.Label
        Me.vmax = New System.Windows.Forms.Label
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbvt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pb
        '
        Me.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb.Location = New System.Drawing.Point(12, 12)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(346, 435)
        Me.pb.TabIndex = 0
        Me.pb.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'pbvt
        '
        Me.pbvt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbvt.Location = New System.Drawing.Point(368, 37)
        Me.pbvt.Name = "pbvt"
        Me.pbvt.Size = New System.Drawing.Size(215, 122)
        Me.pbvt.TabIndex = 2
        Me.pbvt.TabStop = False
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(410, 179)
        Me.TrackBar1.Maximum = 100
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(104, 45)
        Me.TrackBar1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(364, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "k = 0.1"
        '
        'TrackBar2
        '
        Me.TrackBar2.Location = New System.Drawing.Point(410, 230)
        Me.TrackBar2.Maximum = 9
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Size = New System.Drawing.Size(104, 45)
        Me.TrackBar2.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(364, 231)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "m = 1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(364, 376)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(218, 33)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Stop"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(364, 338)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(218, 32)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Start!"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TrackBar3
        '
        Me.TrackBar3.Location = New System.Drawing.Point(410, 281)
        Me.TrackBar3.Maximum = 9
        Me.TrackBar3.Name = "TrackBar3"
        Me.TrackBar3.Size = New System.Drawing.Size(104, 45)
        Me.TrackBar3.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(364, 282)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "g = 1"
        '
        'tmax
        '
        Me.tmax.AutoSize = True
        Me.tmax.Location = New System.Drawing.Point(544, 162)
        Me.tmax.Name = "tmax"
        Me.tmax.Size = New System.Drawing.Size(41, 13)
        Me.tmax.TabIndex = 8
        Me.tmax.Text = "t(max)="
        '
        'vmax
        '
        Me.vmax.AutoSize = True
        Me.vmax.Location = New System.Drawing.Point(365, 12)
        Me.vmax.Name = "vmax"
        Me.vmax.Size = New System.Drawing.Size(44, 13)
        Me.vmax.TabIndex = 9
        Me.vmax.Text = "v(max)="
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 462)
        Me.Controls.Add(Me.vmax)
        Me.Controls.Add(Me.tmax)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TrackBar3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TrackBar2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.pbvt)
        Me.Controls.Add(Me.pb)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbvt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pb As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents pbvt As System.Windows.Forms.PictureBox
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TrackBar2 As System.Windows.Forms.TrackBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TrackBar3 As System.Windows.Forms.TrackBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tmax As System.Windows.Forms.Label
    Friend WithEvents vmax As System.Windows.Forms.Label

End Class
