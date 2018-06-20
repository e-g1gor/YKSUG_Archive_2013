Public Class Form1
    Dim v(3), Vmod, R As Single
    Dim br(2000), nmbr, tmpnmbr, coor(1) As Long
    Dim setobstflag, obstfigure, lastobst, dsa(2), obsttype As Integer
    Dim strt As Boolean
    Dim buff As Bitmap


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        buff = New Bitmap(pb.Width, pb.Height)
        lastobst = -1
        obsttype = 0

        nmbr = 4

        br(0) = 5
        br(1) = 5
        br(2) = 5
        br(3) = 445

        br(4) = 5
        br(5) = 5
        br(6) = 695
        br(7) = 5

        br(8) = 5
        br(9) = 445
        br(10) = 695
        br(11) = 445

        br(12) = 695
        br(13) = 5
        br(14) = 695
        br(15) = 445
        drawallborders()
        tmpnmbr = 0
        coor(0) = 50
        coor(1) = 50
        Vmod = 300
        R = 40
        v(0) = Vmod * Math.Cos(1)
        v(1) = Vmod * Math.Sin(1)
        strt = False
        setobstflag = 0
    End Sub



    Private Function howfarborder(ByVal x1, ByVal y1, ByVal x2, ByVal y2) As Single()
        Dim v1(1), v2(1), vln(1), sm(1), vm, tmp, h(2) As Single
        v1(0) = (x1 - coor(0))
        v1(1) = (y1 - coor(1))
        v2(0) = (x2 - coor(0))
        v2(1) = (y2 - coor(1))
        vln(0) = (x1 - x2)
        vln(1) = (y1 - y2)
        sm(0) = v1(0) * vln(0) + v1(1) * vln(1)
        sm(1) = v2(0) * vln(0) + v2(1) * vln(1)
        vm = v1(0) * vln(1) - v1(1) * vln(0)
        tmp = sm(0) * sm(1)
        If tmp < 0 Then
            h(0) = Math.Sign(vm) * Math.Sqrt(Math.Abs(v1(0) ^ 2 + v1(1) ^ 2 - (sm(0) ^ 2) / (vln(0) ^ 2 + vln(1) ^ 2)))
            h(1) = h(0)
            h(2) = Math.Sign(vm) * h(0)
            h(0) = h(0) * vln(1) / Math.Sqrt(vln(0) ^ 2 + vln(1) ^ 2)
            h(1) = -h(1) * vln(0) / Math.Sqrt(vln(0) ^ 2 + vln(1) ^ 2)
        Else
            h(2) = Math.Sqrt(Math.Min(v1(0) ^ 2 + v1(1) ^ 2, v2(0) ^ 2 + v2(1) ^ 2))
            If v1(0) ^ 2 + v1(1) ^ 2 < v2(0) ^ 2 + v2(1) ^ 2 Then
                h(0) = v1(0)
                h(1) = v1(1)
            Else
                h(0) = v2(0)
                h(1) = v2(1)
            End If
        End If
        Return h
    End Function



    Private Sub ballCld()
        Dim h(2), tt(2) As Single

        tt = howfarborder(br(0), br(1), br(2), br(3))
        dsa(0) = tt(0)
        dsa(1) = tt(1)
        dsa(2) = tt(2)
        For i = 0 To nmbr
            h = howfarborder(br(4 * (i)), br(4 * (i) + 1), br(4 * (i) + 2), br(4 * (i) + 3))
            'h = howfarborder(br(4 * (0)), br(4 * (0) + 1), br(4 * (0) + 2), br(4 * (0) + 3))
            If h(2) < tt(2) Then
                tt(2) = h(2)
                dsa(0) = h(0)
                dsa(1) = h(1)
                dsa(2) = h(2)
            End If
            If Math.Abs(h(2)) > R Then lastobst = -1

            If Math.Abs(h(2)) < R And lastobst <> i Then
                If h(2) <> 0 Then
                    v(2) = v(0) - 2 * Math.Abs(h(0) * v(0) + h(1) * v(1)) * h(0) / (h(2) ^ 2)
                    v(3) = v(1) - 2 * Math.Abs(h(0) * v(0) + h(1) * v(1)) * h(1) / (h(2) ^ 2)
                    v(0) = Vmod * Math.Sin(Math.Atan2(v(2), v(3)))
                    v(1) = Vmod * Math.Cos(Math.Atan2(v(2), v(3)))
                End If
                lastobst = i
                'strt = False
            End If
            Label4.Text = v(0) ^ 2 + v(1) ^ 2
        Next
    End Sub



    Private Sub drawallborders()
        For i = 0 To nmbr + tmpnmbr - 1
            Dim tmp(3) As Integer
            tmp(0) = br(4 * (i))
            tmp(1) = br(4 * (i) + 1)
            tmp(2) = br(4 * (i) + 2)
            tmp(3) = br(4 * (i) + 3)
            Using gr As Graphics = Graphics.FromImage(CType(buff, Image))
                gr.DrawLine(Pens.Black, tmp(0), tmp(1), tmp(2), tmp(3))
            End Using
            pb.Image = buff.Clone()
        Next
    End Sub




    Private Sub shownewborders()
        pb.Image = buff.Clone()
        For i = nmbr To nmbr + tmpnmbr - 1
            Dim tmp(3) As Integer
            tmp(0) = br(4 * (i))
            tmp(1) = br(4 * (i) + 1)
            tmp(2) = br(4 * (i) + 2)
            tmp(3) = br(4 * (i) + 3)
            Using gr As Graphics = Graphics.FromImage(pb.Image)
                gr.DrawLine(Pens.Black, tmp(0), tmp(1), tmp(2), tmp(3))
            End Using
        Next
    End Sub



    Private Sub SetTriangleObst(ByVal isittemp As Boolean, ByVal x As Integer, ByVal y As Integer)
        If isittemp Then
            Select Case setobstflag
                Case 3
                    nmbr += 2
                    drawallborders()
                    tmpnmbr = 0
                    setobstflag = 0
                Case 2
                    br(4 * nmbr + 2) = x
                    br(4 * nmbr + 3) = y
                    nmbr += 1
                    drawallborders()
                    br(4 * nmbr) = br(4 * (nmbr - 1))
                    br(4 * nmbr + 1) = br(4 * (nmbr - 1) + 1)
                    br(4 * nmbr + 2) = x
                    br(4 * nmbr + 3) = y
                    br(4 * nmbr + 4) = br(4 * (nmbr - 1) + 2)
                    br(4 * nmbr + 5) = br(4 * (nmbr - 1) + 3)
                    br(4 * nmbr + 6) = x
                    br(4 * nmbr + 7) = y
                    tmpnmbr = 2
                    setobstflag = 3
                Case 1
                    br(4 * nmbr) = x
                    br(4 * nmbr + 1) = y
                    setobstflag = 2
            End Select
        Else
            Select Case setobstflag
                Case 2
                    br(4 * nmbr + 2) = x
                    br(4 * nmbr + 3) = y
                    tmpnmbr = 1
                Case 3
                    br(4 * nmbr) = br(4 * (nmbr - 1))
                    br(4 * nmbr + 1) = br(4 * (nmbr - 1) + 1)
                    br(4 * nmbr + 2) = x
                    br(4 * nmbr + 3) = y
                    br(4 * nmbr + 4) = br(4 * (nmbr - 1) + 2)
                    br(4 * nmbr + 5) = br(4 * (nmbr - 1) + 3)
                    br(4 * nmbr + 6) = x
                    br(4 * nmbr + 7) = y
            End Select
        End If
    End Sub




    Private Sub pb_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pb.MouseDown
        SetTriangleObst(True, e.X, e.Y)
    End Sub



    Private Sub pb_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pb.MouseMove
        SetTriangleObst(False, e.X, e.Y)
    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Timer1.Enabled = False
        Dim tmp(1) As Single
        tmp(0) = howfarborder(br(0), br(1), br(2), br(3))(0)
        tmp(1) = howfarborder(br(0), br(1), br(2), br(3))(1)
        pb.Image = buff.Clone()
        If nmbr + tmpnmbr > 0 Then shownewborders()
        If strt Then
            ballCld()
            coor(0) = coor(0) + 0.01 * v(0)
            coor(1) = coor(1) + 0.01 * v(1)
        End If
        Using gr As Graphics = Graphics.FromImage(pb.Image)
            'gr.DrawLine(Pens.Green, coor(0), coor(1), coor(0) + v(0), coor(1) + v(1))
            'gr.DrawLine(Pens.Blue, coor(0), coor(1), coor(0) + dsa(0), coor(1) + dsa(1))
            gr.DrawEllipse(Pens.Violet, Math.Round(coor(0)) - R, Math.Round(coor(1)) - R, 2 * R, 2 * R)
        End Using
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If setobstflag = 0 Then
            setobstflag = 1
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        strt = Not strt
    End Sub
End Class
