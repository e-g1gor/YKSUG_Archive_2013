Public Class Form1
    Dim v(11), x(11), N, m, k, s, dt, R, En As Double



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dt = 0.05
        k = 1
        m = 2
        N = 3
        s = 50
        R = 10
        Randomize()
        En = 0
        v(1) = 20
        For i = 0 To 11
            'v(i) = 10 * Rnd()
            En = En + v(i) ^ 2
            x(i) = s * i
        Next
        v(0) = 0
        v(11) = 11
        En = En * m / 2
    End Sub


    Private Sub normenergy()
        Dim En1 As Single
        En1 = 0
        For i = 1 To N
            En1 = En1 + v(i) ^ 2
        Next
        En1 = En1 * m / 2

        For i = 1 To N
            v(i) = v(i) * Math.Sqrt(En / En1)
        Next
    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim tmp(3) As Integer
        pb.Invalidate()
        pb.Update()
        Using gr As Graphics = pb.CreateGraphics()
            For i = 1 To N
                v(i) = v(i) + k * (x(i - 1) + x(i + 1) - 2 * x(i)) * dt / m
                x(i) = x(i) + v(i) * dt
                tmp(0) = Math.Round(x(i) - R)
                tmp(1) = Math.Round(10 - R)
                tmp(2) = 2 * Math.Round(R)
                tmp(3) = 2 * Math.Round(R)
                gr.DrawEllipse(Pens.Black, tmp(0), tmp(1), tmp(2), tmp(3))
                tmp(2) = x(N + 1)
                gr.DrawLine(Pens.Black, 0, 10, tmp(2), 10)
                gr.DrawLine(Pens.Black, 0, 0, 0, 20)
                tmp(0) = x(N + 1)
                tmp(2) = x(N + 1)
                gr.DrawLine(Pens.Black, tmp(0), 0, tmp(2), 20)
            Next
        End Using
        'normenergy()
    End Sub

End Class
