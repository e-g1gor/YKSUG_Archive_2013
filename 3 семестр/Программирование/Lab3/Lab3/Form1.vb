Public Class Form1
    Dim a, b As Integer
    Dim c, x1, x2 As Single

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        a = Val(TextBox1.Text)
        b = Val(TextBox2.Text)
        c = a + b
        TextBox3.Text = Str(c)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        a = Val(TextBox1.Text)
        b = Val(TextBox2.Text)
        If b = 0 Then
            MsgBox("Не дели на ноль")
        Else
            c = a / b
            TextBox3.Text = Str(c)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        a = Val(TextBox1.Text)
        b = Val(TextBox2.Text)
        If a > b Then
            c = a / b
            TextBox3.Text = Str(c)
        ElseIf a = b Then
            MsgBox("Числа равны")
        Else
            c = b / a
            TextBox3.Text = Str(c)
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        RadioButton1.Checked = True
        RadioButton2.Checked = False
        qe.Visible = False
        Button1.Visible = True
        Button2.Visible = True
        Button3.Visible = True
        Button4.Visible = False
        l4.Visible = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        RadioButton1.Checked = False
        RadioButton2.Checked = True
        qe.Visible = True
        Button1.Visible = False
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = True
        l4.Visible = True
        qe.Text = Val(TextBox1.Text) & "x^2 + " & Val(TextBox2.Text) & "x + " & Val(TextBox3.Text) & " = 0"
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        a = Val(TextBox1.Text)
        b = Val(TextBox2.Text)
        c = Val(TextBox3.Text)
        If (b * b - 4 * a * c) >= 0 Then
            x1 = (0 - b - System.Math.Sqrt(b * b - 4 * a * c)) / (2 * a)
            x2 = (0 - b + System.Math.Sqrt(b * b - 4 * a * c)) / (2 * a)
            l4.Text = "x1 = " & x1 & "; x2 = " & x2
        Else
            l4.Text = "d = " & Str(b * b - 4 * a * c) & "; Нет корней"
        End If



    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        qe.Text = Val(TextBox1.Text) & "x^2 + " & Val(TextBox2.Text) & "x + " & Val(TextBox3.Text) & " = 0"
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        qe.Text = Val(TextBox1.Text) & "x^2 + " & Val(TextBox2.Text) & "x + " & Val(TextBox3.Text) & " = 0"
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        qe.Text = Val(TextBox1.Text) & "x^2 + " & Val(TextBox2.Text) & "x + " & Val(TextBox3.Text) & " = 0"
    End Sub
End Class
