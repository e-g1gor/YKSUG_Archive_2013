Public Class Form1
    Dim buff As Image
    Dim t, l, h, r As Single


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim x, y As Integer
        pb.Image = buff.Clone()
        pb.Invalidate()
        pb.Update()
        If t = 2 * Math.PI Then t = 0

        x = (pb.Width - l - 30) * (1 + Math.Sin(t)) / 2
        y = x * x * pb.Height / ((pb.Width - l - 20) ^ 2)

        Using gr As Graphics = pb.CreateGraphics

            gr.DrawEllipse(Pens.Green, l + x - r, pb.Height - h - y - r, 2 * r, 2 * r)
        End Using
        t = t + 0.05
        Label1.Text = t

    End Sub




    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        buff = New Bitmap(pb.Width, pb.Height)
        Dim a As Integer
        l = 20
        h = 20
        t = 0
        r = 10

        Using gr As Graphics = Graphics.FromImage(buff)
            For i = 0 To pb.Width - l - 30
                a = Math.Round(i * i * pb.Height / ((pb.Width - l - 20) ^ 2))
                gr.DrawEllipse(Pens.Red, i + l, pb.Height - h - a, 1, 1)
            Next
            gr.DrawLine(Pens.Black, l, 0, l, pb.Height - h)
            gr.DrawLine(Pens.Black, 0, pb.Height - h, pb.Width, pb.Height - h)
        End Using

    End Sub
End Class
