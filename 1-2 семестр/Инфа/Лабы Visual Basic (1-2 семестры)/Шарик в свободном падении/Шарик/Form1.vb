Public Class Form1
    Dim gr, grvt As Graphics
    Dim t, dt, h, m, g, R, v, k As Single
    Dim myfont As Font





    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim sch, scw As Single
        sch = g * m / k
        scw = -m * Math.Log(0.05) / k
        tmax.Text = "t(max)=" & scw & " c"
        vmax.Text = "v(max)=" & sch & " м/с"
        t = t + dt
        v = v + (g - (k * v) / m) * dt
        h = h + v * dt
        pb.Image = Nothing
        pb.Update()
        DrawScaleLines(h)
        gr.DrawEllipse(Pens.Red, CType(pb.Width / 2, Integer) - R, CType(pb.Height / 2, Integer) - R, 2 * R, 2 * R)
        grvt.DrawEllipse(Pens.Red, t * pbvt.Width / scw, pbvt.Height - v * pbvt.Height / sch, 1, 1)
    End Sub



    Private Sub DrawScaleLines(ByVal x As Single)
        Dim a, d As Integer
        d = 10
        a = Math.Floor(x / 10)

        For i = 0 To CType(Math.Floor(pb.Height / (10 * d)) + 1, Integer)
            gr.DrawString(Str(10 * a + 10 * i), Font, Brushes.Black, 0, 10 * i * d + d * (10 * a - x))
            gr.DrawLine(Pens.Black, 10, 10 * i * d + d * (10 * a - x), pb.Width, 10 * i * d + d * (10 * a - x))
        Next
    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gr = pb.CreateGraphics()
        grvt = pbvt.CreateGraphics()
        k = 0.1
        t = 0
        h = 0
        v = 0
        g = 1
        m = 1
        R = 20
        dt = 0.1
        TrackBar1.Value = 10
        TrackBar2.Value = 0
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        k = TrackBar1.Value / 100
        Label1.Text = "k = " + Str(k)
    End Sub

    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        m = TrackBar2.Value + 1
        Label2.Text = "m = " + Str(m)
    End Sub

    Private Sub TrackBar3_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar3.Scroll
        g = TrackBar3.Value + 1
        Label3.Text = "g = " + Str(g)
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TrackBar1.Enabled = False
        TrackBar2.Enabled = False
        TrackBar3.Enabled = False
        Timer1.Enabled = True
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TrackBar1.Enabled = True
        TrackBar2.Enabled = True
        TrackBar3.Enabled = True
        Timer1.Enabled = False
        t = 0
        h = 0
        v = 0
        pbvt.Invalidate()
        pb.Invalidate()
        pb.Update()
        DrawScaleLines(0)
    End Sub
End Class
