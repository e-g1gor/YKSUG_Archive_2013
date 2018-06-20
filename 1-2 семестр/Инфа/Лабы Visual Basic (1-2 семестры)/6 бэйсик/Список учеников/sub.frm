VERSION 5.00
Begin VB.Form Form1 
   BackColor       =   &H00FFFFFF&
   Caption         =   "Школка"
   ClientHeight    =   4440
   ClientLeft      =   165
   ClientTop       =   810
   ClientWidth     =   7920
   ScaleHeight     =   4440
   ScaleWidth      =   7920
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox List2 
      Height          =   1035
      Left            =   120
      TabIndex        =   9
      Top             =   3120
      Width           =   7695
   End
   Begin VB.ListBox List1 
      Height          =   2010
      Left            =   120
      TabIndex        =   0
      Top             =   480
      Width           =   1935
   End
   Begin VB.Label Label9 
      Caption         =   "Лучшие ученики"
      Height          =   255
      Left            =   120
      TabIndex        =   10
      Top             =   2760
      Width           =   7695
   End
   Begin VB.Label Label8 
      Height          =   255
      Left            =   2280
      TabIndex        =   8
      Top             =   2280
      Width           =   5535
   End
   Begin VB.Label Label7 
      Height          =   255
      Left            =   2280
      TabIndex        =   7
      Top             =   1920
      Width           =   5535
   End
   Begin VB.Label Label6 
      Height          =   255
      Left            =   2280
      TabIndex        =   6
      Top             =   1560
      Width           =   5535
   End
   Begin VB.Label Label5 
      Height          =   255
      Left            =   2280
      TabIndex        =   5
      Top             =   1200
      Width           =   5535
   End
   Begin VB.Label Label4 
      Height          =   255
      Left            =   2280
      TabIndex        =   4
      Top             =   840
      Width           =   5535
   End
   Begin VB.Label Label3 
      Height          =   255
      Left            =   2280
      TabIndex        =   3
      Top             =   480
      Width           =   5535
   End
   Begin VB.Label Label2 
      Height          =   255
      Left            =   2280
      TabIndex        =   2
      Top             =   120
      Width           =   5535
   End
   Begin VB.Label Label1 
      Caption         =   "Label1"
      Height          =   255
      Left            =   120
      TabIndex        =   1
      Top             =   120
      Width           =   1935
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
Dim x As Integer, mas(30, 7) As Integer

Private Sub about_Click()
Form2.Visible = True
Form1.Enabled = False
End Sub

Private Sub Form_Load()
Randomize (DateTime.Timer)
Dim i As Integer, j As Integer
Dim names(20) As String, fam(14) As String
names(1) = "Саша"
names(2) = "Егор"
names(3) = "Оля"
names(4) = "Вика"
names(5) = "Алукард"
names(6) = "Петя"
names(7) = "Адольф"
names(8) = "Андрей"
names(9) = "Дима"
names(10) = "Эдуард"
names(11) = "Филлип"
names(12) = "Аня"
names(13) = "Оксана"
names(14) = "Ксения"
names(15) = "Леонид"
names(16) = "Маргарита"
names(17) = "Алексей"
names(18) = "Виталий"
names(19) = "Влад"
names(20) = "Женя"
fam(1) = "Иванов"
fam(2) = "Петров"
fam(3) = "Сидоров"
fam(4) = "Оскирко"
fam(5) = "Калинов"
fam(6) = "Гитлер"
fam(7) = "Сатанин"
fam(8) = "Карпичко"
fam(9) = "Слабыш"
fam(10) = "Шурхаев"
fam(11) = "Валько"
fam(12) = "Синица"
fam(13) = "Воробей"
fam(14) = "Кулик"

x = Round(30 * Rnd(DateTime.Timer))
Label1.Caption = Str(x) + " Учеников"
For i = 1 To x
List1.AddItem (fam(Round(13 * Rnd() + 1)) + " " + names(Round(19 * Rnd() + 1)))
    mas(i, 7) = 0
    For j = 1 To 6
    mas(i, j) = Round(5 * Rnd())
    Next
Next
End Sub

Private Sub List1_Click()
Dim tmp As Integer
tmp = List1.ListIndex + 1
Label2.Caption = "Оценки ученика " + List1.List(List1.ListIndex) + ":"
Label3.Caption = "Физика: " + Str(mas(tmp, 1))
Label4.Caption = "Литература: " + Str(mas(tmp, 2))
Label5.Caption = "Математика: " + Str(mas(tmp, 3))
Label6.Caption = "Русский язык: " + Str(mas(tmp, 4))
Label7.Caption = "Химия: " + Str(mas(tmp, 5))
Label8.Caption = "Физкультура: " + Str(mas(tmp, 6))
End Sub
