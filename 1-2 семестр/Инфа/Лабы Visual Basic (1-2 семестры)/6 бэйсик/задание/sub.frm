VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Лабораторная работа 2"
   ClientHeight    =   4410
   ClientLeft      =   165
   ClientTop       =   810
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   4410
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   285
      Left            =   480
      TabIndex        =   2
      Top             =   1440
      Width           =   735
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Пуск"
      Height          =   375
      Left            =   480
      TabIndex        =   1
      Top             =   1800
      Width           =   735
   End
   Begin VB.ComboBox Combo1 
      Height          =   315
      ItemData        =   "sub.frx":0000
      Left            =   0
      List            =   "sub.frx":002B
      TabIndex        =   0
      Text            =   "Варианты"
      Top             =   0
      Width           =   4575
   End
   Begin VB.Label Label2 
      Caption         =   "n"
      Height          =   255
      Left            =   120
      TabIndex        =   4
      Top             =   1440
      Width           =   255
   End
   Begin VB.Label Label1 
      Caption         =   "Задание"
      Height          =   615
      Left            =   120
      TabIndex        =   3
      Top             =   480
      Width           =   4455
   End
   Begin VB.Menu about 
      Caption         =   "О программе"
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim vari As Integer
Dim n As Integer

Private Sub about_Click()
Form2.Visible = True
Form1.Enabled = False
End Sub

Private Sub Combo1_Click()
tmpstr = "Найдите сумму первых n натуральных чисел, которые "
vari = Combo1.ListIndex
Select Case Combo1.ListIndex
Case 0
Label1.Caption = tmpstr + "являются степенью числа 5"
Case 1
Label1.Caption = tmpstr + "делятся на 3"
Case 2
Label1.Caption = tmpstr + "являются числами Фибоначи"
Case 3
Label1.Caption = tmpstr + "являются полными квадратами"
Case 4
Label1.Caption = tmpstr + "являются степенью числа 3"
Case 5
Label1.Caption = tmpstr + "делятся на 5"
Case 6
Label1.Caption = tmpstr + "делятся на 6"
Case 7
Label1.Caption = tmpstr + "делятся на 9"
Case 8
Label1.Caption = tmpstr + "делятся на 3 и 5"
Case 9
Label1.Caption = tmpstr + "делятся на 3 и 10"
Case 10
Label1.Caption = tmpstr + "делятся на 2 или 5"
Case 11
Label1.Caption = tmpstr + "делятся на 3 или 5"
Case Else
End Select
End Sub




Private Sub Command1_Click()
n = Val(Text1.Text)
MsgBox ("Ответ " + getansw)
End Sub




Private Function getansw() As String
Dim tmp, t1, t2, t3 As Single
tmp = 0

Select Case vari
Case 0
For i = 1 To n
If 5 ^ i <= n Then tmp = tmp + 5 ^ i
Next

Case 1
For i = 1 To n
If Math.Round(i / 3) = (i / 3) Then tmp = tmp + i
Next

Case 2
t1 = 0
t2 = 1
For i = 1 To n
t3 = t1 + t2
t1 = t2
t2 = t3
tmp = tmp + t3
Next

Case 3
For i = 1 To n
If 3 ^ i <= n Then tmp = tmp + 3 ^ i
Next

Case 4
For i = 1 To n
If Math.Round(Math.Sqr(i)) = Math.Sqr(i) Then tmp = tmp + i
Next

Case 5
For i = 1 To n
If Math.Round(i / 5) = (i / 5) Then tmp = tmp + i
Next

Case 6
For i = 1 To n
If Math.Round(i / 6) = (i / 6) Then tmp = tmp + i
Next

Case 7
For i = 1 To n
If Math.Round(i / 9) = (i / 9) Then tmp = tmp + i
Next

Case 8
For i = 1 To n
If Math.Round(i / 5) = (i / 5) And Math.Round(i / 3) = (i / 3) Then tmp = tmp + i
Next

Case 9
For i = 1 To n
If Math.Round(i / 10) = (i / 10) And Math.Round(i / 3) = (i / 3) Then tmp = tmp + i
Next

Case 10
For i = 1 To n
If Math.Round(i / 5) = (i / 5) Or Math.Round(i / 2) = (i / 2) Then tmp = tmp + i
Next

End Select

getansw = Str(tmp)
End Function

