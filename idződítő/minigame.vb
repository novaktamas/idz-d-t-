Public Class minigame
    Dim bmp As New Bitmap(700, 400)
    Dim grp As Graphics = Graphics.FromImage(bmp)
    Dim fonn As Boolean = False
    Dim allas, allas2, allas3, isrunning As Boolean
    Dim Y, X As Point
    Dim szamlalo As Integer = 0
    Dim aktp As Boolean = False


    Private Sub minigame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Y.X = 100
        Y.Y = 280
        X.Y = 260
        X.X = 700
        grp.FillRectangle(Brushes.Black, X.X, X.Y, 40, 40)
        grp.FillRectangle(Brushes.Red, Y.X, Y.Y, 20, 20)
        terep()
        PictureBox1.Image = bmp
        allas = False
        allas2 = False
        allas3 = False
        Me.Width = 700
        Me.Height = 400
        PictureBox1.Top = 0
        PictureBox1.Left = 0
        Do While isrunning = True
            elleno()

        Loop
    End Sub
    Private Sub elleno()
        If X.X Then

        End If
    End Sub
    Private Sub hatter()
        Dim hbm As New Bitmap(800, 500)
        Dim htg As Graphics = Graphics.FromImage(hbm)
        htg.FillRectangle(Brushes.Gray, 0, 0, 800, 500)
        htg.DrawLine(Pens.Black, 0, 0, 50, 50)
        htg.DrawLine(Pens.Black, 0, 500, 50, 450)
        htg.DrawLine(Pens.Black, 800, 0, 750, 50)
        htg.DrawLine(Pens.Black, 800, 500, 750, 450)
        Me.BackgroundImage = hbm
    End Sub
    Private Sub skin()
        grp.Clear(SystemColors.Control)
        grp.FillRectangle(Brushes.Red, Y.X, Y.Y, 20, 20)
        grp.FillRectangle(Brushes.Black, X.X, X.Y, 40, 40)
        PictureBox1.Image = bmp
    End Sub
    Private Sub terep()
        grp.DrawRectangle(Pens.Black, 0, 0, 699, 399)
        grp.FillRectangle(Brushes.Red, 680, 1, 19, 20)
        grp.DrawString("X", Me.Font, Brushes.Black, 685, 5)
        grp.FillRectangle(Brushes.Yellow, 660, 1, 20, 20)
        grp.DrawString("||", Me.Font, Brushes.Black, 665, 5)
        grp.DrawLine(Pens.Black, 0, 300, 700, 300)
        grp.FillRectangle(Brushes.Green, 640, 1, 20, 20)
        grp.DrawString("_", Me.Font, Brushes.Black, 645, 5)

    End Sub
    Private Sub ugras()

        If szamlalo Mod 2 = 0 Then
            If Y.Y <= 300 And aktp = False Then
                Y.Y -= 10

            ElseIf aktp = True And Y.Y < 280 Then
                Y.Y += 10
            ElseIf Y.Y = 280 And aktp = True Then
                aktp = False
                fonn = False
            End If
        End If
        If Y.Y = 150 Then
            aktp = True
        End If
    End Sub
    Private Sub seta()
        fonn = False
        Y.Y = 300 - 20

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        bokor()
        skin()
        terep()
        If fonn = True Then
            ugras()
        Else
            seta()
        End If
        szamlalo += 1
    End Sub


    Private Sub minigame_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If allas = False Then
            Timer1.Start()
            allas = True
        Else
            If Asc(e.KeyChar) = 32 Then
                fonn = True
            End If
        End If

    End Sub
    Private Sub bokor()
        X.X -= 5
        If X.X < 2 Then
            X.X = 700
        End If

    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        If 680 < e.X Then
            If 20 > e.Y Then
                Me.Close()
            End If
        ElseIf 660 < e.X Then
            If 680 > e.X Then
                If 20 > e.Y Then
                    If allas2 = False Then
                        allas2 = True
                        Timer1.Stop()
                        grp.DrawString("||", Me.Font, Brushes.Red, 665, 5)
                        PictureBox1.Image = bmp
                    ElseIf allas2 = True Then
                        Timer1.Start()
                        allas2 = False
                    End If
                End If
            End If
        ElseIf 640 < e.X Then
            If 660 > e.X Then
                If 20 > e.Y Then
                    Me.SendToBack()

                End If
            End If
        End If
    End Sub

    Private Sub minigame_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Timer1.Stop()
        allas3 = True
    End Sub

    Private Sub minigame_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        If allas3 = True Then
            Timer1.Start()
        End If
    End Sub
End Class