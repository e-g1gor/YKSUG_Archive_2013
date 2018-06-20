Public Class Form1

    Dim oo(25), opn(25), cheatflag As Boolean
    Dim cntoo, life, lifemax, n, i As Integer


    'Справочные материалы:
    'обрщение к объектам поименно: http://social.msdn.microsoft.com/Forums/ru-RU/32a2723e-68a3-432d-826d-d281c9b1f780/-?forum=fordesktopru
    'привязать обработчик к событиям нескольких объектов: http://www.cyberforum.ru/vb-net/thread580849.html



    Private Sub strt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles strt.Click
        Dim k, x1, x2 As Integer
        cheatflag = False
        cntoo = 0
        life = 0
        k = 0

        lifemax = Math.Round(Math.Abs(Val(TextBox2.Text)))
        n = Math.Round(Math.Abs(Val(TextBox1.Text)))
        If n > 24 Then
            n = 24
        End If

        If n = 0 Then
            n = 1
        End If

        If lifemax = 0 Then
            lifemax = 1
        End If
        TextBox1.Text = n
        TextBox2.Text = lifemax

        For i = 1 To 25
            mothpan.Controls("Panel" & i).Enabled = True
            mothpan.Controls("Panel" & i).BackgroundImage = Image.FromFile("block.bmp")
            oo(i) = True
            opn(i) = True
        Next

        i = 0
        While i < 100000
            x1 = Math.Round(4 * Rnd())
            x2 = 1 + Math.Round(4 * Rnd())
            If oo(x1 * 5 + x2) Then
                oo(x1 * 5 + x2) = False
                k = k + 1
            End If
            If k = n Then
                i = 200000
            End If
        End While
    End Sub




    Private Sub PanMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim coor As Integer
        Dim tmp As Panel
        tmp = CType(sender, Panel)
        coor = Val(tmp.Tag)
        If opn(coor) Then
            tmp.BackgroundImage = Image.FromFile("down.bmp")
        End If
    End Sub

    Private Sub PanMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim coor As Integer
        Dim tmp As Panel
        tmp = CType(sender, Panel)
        coor = Val(tmp.Tag)
        If opn(coor) Then
            tmp.BackgroundImage = Image.FromFile("up.bmp")
        End If
    End Sub

    Private Sub PanMouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim coor As Integer
        Dim tmp As Panel
        Dim cht As String
        cht = ""
        tmp = CType(sender, Panel)
        coor = Val(tmp.Tag)
        If Not oo(coor) And cheatflag Then
            cht = "1"
        End If
        If opn(coor) Then
            tmp.BackgroundImage = Image.FromFile("block" + cht + ".bmp")
        End If
    End Sub

    Private Sub PanMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim coor As Integer
        Dim tmp As Panel
        tmp = CType(sender, Panel)
        coor = Val(tmp.Tag)
        If opn(coor) Then
            If oo(coor) Then
                cntoo += 1
                tmp.BackgroundImage = Image.FromFile("o.bmp")
            Else
                life += 1
                tmp.BackgroundImage = Image.FromFile("x.bmp")
            End If
        End If
        opn(coor) = False
        If cntoo = (25 - n) Then
            MsgBox("You Win!")
            For i = 1 To 25
                mothpan.Controls("Panel" & i).Enabled = False
            Next
        End If
        If life = lifemax Then
            MsgBox("You Loose!")
            For i = 1 To 25
                mothpan.Controls("Panel" & i).Enabled = False
            Next
        End If
    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cheatflag = Not cheatflag
        If cheatflag Then
            For i = 1 To 25
                If opn(i) And Not oo(i) Then
                    mothpan.Controls("Panel" & i).BackgroundImage = Image.FromFile("block1.bmp")
                End If
            Next
        Else
            For i = 1 To 25
                If opn(i) Then
                    mothpan.Controls("Panel" & i).BackgroundImage = Image.FromFile("block.bmp")
                End If
            Next
        End If
    End Sub




    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i = 1 To 25
            AddHandler mothpan.Controls("Panel" & i).MouseUp, AddressOf PanMouseUp
            AddHandler mothpan.Controls("Panel" & i).MouseDown, AddressOf PanMouseDown
            AddHandler mothpan.Controls("Panel" & i).MouseEnter, AddressOf PanMouseEnter
            AddHandler mothpan.Controls("Panel" & i).MouseLeave, AddressOf PanMouseLeave
            mothpan.Controls("Panel" & i).Enabled = True
            mothpan.Controls("Panel" & i).BackgroundImage = Image.FromFile("block.bmp")
        Next
    End Sub





End Class
