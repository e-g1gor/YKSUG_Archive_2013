Imports System.Math

Public Class Form1

    Dim a(30) As String
    Dim b(30) As Integer
    Dim c(20) As Single
    Dim sum As Single
    Dim i As Integer
    Dim d As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        a(1) = "Иванов"
        b(1) = System.Math.Round(Rnd() * 10)
        a(2) = "Петров"
        b(2) = System.Math.Round(Rnd() * 10)
        a(3) = "Сидоров"
        b(3) = System.Math.Round(Rnd() * 10)
        For i = 1 To 3 Step 1
            ListBox1.Items.Add(a(i) + " " + Str(b(i)))
        Next

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        For i = 1 To 10 Step 1
            c(i) = Rnd() * 100
            ListBox1.Items.Add("C(" + Str(i) + ")=" + Str(c(i)))
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        sum = 0
        For i = 0 To Val(TextBox1.Text) Step 1
            sum = sum + c(i)
        Next
        MsgBox("Сумма " + TextBox1.Text + " чисел = " + Str(sum))
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ListBox1.Items.Clear()
        sum = 0
        For i = 0 To (Val(TextBox4.Text) - 1) Step 1
            sum = sum + Val(TextBox2.Text) + i * Val(TextBox3.Text)
            ListBox1.Items.Add("a" + Str(i + 1) + " = " + Str(Val(TextBox2.Text) + i * Val(TextBox3.Text)))

        Next
        Label5.Text = "Сумма " + TextBox4.Text + " членов равна " + Str(sum)



    End Sub
End Class
