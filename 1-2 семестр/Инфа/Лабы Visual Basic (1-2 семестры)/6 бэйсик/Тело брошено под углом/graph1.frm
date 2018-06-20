VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   5625
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   4455
   LinkTopic       =   "Form1"
   ScaleHeight     =   5625
   ScaleWidth      =   4455
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text2 
      Height          =   285
      Left            =   600
      TabIndex        =   3
      Text            =   "60"
      Top             =   4800
      Width           =   2415
   End
   Begin VB.TextBox Text1 
      Height          =   285
      Left            =   600
      TabIndex        =   2
      Text            =   "30"
      Top             =   4440
      Width           =   2415
   End
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Interval        =   100
      Left            =   3480
      Top             =   3600
   End
   Begin VB.CommandButton Ris 
      Caption         =   "Command1"
      Height          =   735
      Left            =   3240
      TabIndex        =   1
      Top             =   4440
      Width           =   1095
   End
   Begin VB.PictureBox Graph 
      Height          =   4200
      Left            =   120
      ScaleHeight     =   4309.294
      ScaleMode       =   0  'Пользовательское
      ScaleWidth      =   4184.837
      TabIndex        =   0
      Top             =   120
      Width           =   4200
   End
   Begin VB.Label Label1 
      Caption         =   "а"
      Height          =   255
      Left            =   120
      TabIndex        =   5
      Top             =   4800
      Width           =   255
   End
   Begin VB.Label Lbl1 
      Caption         =   "v"
      Height          =   255
      Left            =   120
      TabIndex        =   4
      Top             =   4440
      Width           =   255
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim t As Single
Dim v As Single
Dim a As Single
Dim dt As Single
Dim g As Single

Private Sub Ris_Click()
Graph.Scale (-5, 105)-(105, -10)
Graph.Line (0, 0)-(0, 100)
Graph.Line (0, 100)-(-2, 94)
Graph.Line (0, 100)-(2, 94)
Graph.Line (0, 0)-(100, 0)
Graph.Line (100, 0)-(94, 2)
Graph.Line (100, 0)-(94, -2)
Graph.Line (50, -2)-(50, 2)
Graph.Line (-2, 50)-(2, 50)
Graph.PSet (48, -2)
Graph.Print "50"
Graph.PSet (-5, 48)
Graph.Print "50"
Graph.PSet (5, 100)
Graph.Print "Y,м"
Graph.PSet (90, -3)
Graph.Print "Х,м"
g = 9.81
dt = 0.01
t = 0
v = Val(Text1.Text)
a = Val(Text2.Text) * 3.1415 / 180
Timer1.Interval = dt * 1000
Timer1.Enabled = True
End Sub

Private Sub Timer1_Timer()
Graph.PSet (v * Math.Cos(a) * t, v * Math.Sin(a) * t - g * t * t / 2)
t = t + dt
Timer1.Enabled = True
If (v * Math.Sin(a) * t - 9.81 * t * t / 2) < 0 Or (v * Math.Cos(a) * t) > 100 Or (v * Math.Sin(a) * t - 9.81 * t * t / 2) > 100 Then
Timer1.Enabled = False
End If
End Sub
