VERSION 5.00
Begin VB.Form Form2 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "О программе"
   ClientHeight    =   960
   ClientLeft      =   45
   ClientTop       =   390
   ClientWidth     =   3285
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   960
   ScaleWidth      =   3285
   StartUpPosition =   3  'Windows Default
   Visible         =   0   'False
   Begin VB.CommandButton Command1 
      Caption         =   "ОК"
      Height          =   375
      Left            =   2280
      TabIndex        =   2
      Top             =   480
      Width           =   855
   End
   Begin VB.Label Label2 
      Caption         =   "Автор: Егор Клёнин"
      Height          =   255
      Left            =   120
      TabIndex        =   1
      Top             =   480
      Width           =   2055
   End
   Begin VB.Label Label1 
      Caption         =   "Задания к лабораторной работе"
      Height          =   255
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   2895
   End
End
Attribute VB_Name = "Form2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim fl As Integer


Private Sub Command1_Click()
Form2.Visible = False
Form1.Enabled = True
End Sub

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
If KeyCode = 73 Then   'i
fl = 1
End If
End Sub

Private Sub Form_KeyUp(KeyCode As Integer, Shift As Integer)
If KeyCode = 73 Then   'i
fl = 0
End If
End Sub

Private Sub Label2_Click()
If fl = 1 Then
Label2.Caption = "Автор: Егор Клёнин"
End If
End Sub
