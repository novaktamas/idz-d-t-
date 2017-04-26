Public Class Form1
    Dim rnd As New Random
    Dim szam As Integer
    Dim a, b, u, i, o, k, l, j As Integer


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            szam = rnd.Next(a, b)
        Catch ex As Exception
            MsgBox("A minimum nem lehet nagyobb mint a maximum!", Title:="ERROR")
        End Try
        TextBox1.Text = szam

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        a = 0
        b = 10
        Timer1.Start()
        u = 0
        i = 0
        o = 0
        TextBox5.Text = My.Settings.szoveg

    End Sub
    Private Sub looop() Handles NumericUpDown1.ValueChanged, NumericUpDown2.ValueChanged
        a = NumericUpDown1.Value
        b = NumericUpDown2.Value

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged, TextBox2.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RadioButton1.Checked Then
            Dim c As Integer
            c = rnd.Next(0, 2)
            If c = 0 Then
                TextBox2.Text = "Igen"
            ElseIf c = 1 Then
                TextBox2.Text = "Nem"
            End If
        Else
            Dim c As Integer
            c = rnd.Next(0, 2)
            If c = 0 Then
                TextBox2.Text = TextBox3.Text
            ElseIf c = 1 Then
                TextBox2.Text = TextBox4.Text
            End If
        End If

    End Sub

    Private Sub RadioButton1_Check(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            Button2.Text = "Igen/Nem"
        Else
            Button2.Text = "Saját"
            TextBox3.Enabled = True
            TextBox4.Enabled = True


        End If
    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3.ValueChanged, NumericUpDown4.ValueChanged, NumericUpDown5.ValueChanged
        Label6.Text = NumericUpDown3.Value.ToString.PadLeft(2, "0") & ":" & NumericUpDown4.Value.ToString.PadLeft(2, "0") & ":" & NumericUpDown5.Value.ToString.PadLeft(2, "0")
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Timer3.Start()
        j = NumericUpDown5.Value
        k = NumericUpDown4.Value
        l = NumericUpDown3.Value

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        minigame.Show()

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

        j -= 1

        If j < 0 And k > 0 Then
            j = 59
            k -= 1
        ElseIf k < 0 And l > 0 Then
            k = 59
            l -= 1
        ElseIf j = 0 And k = 0 And l = 0 Then
            Timer3.Stop()
            Label6.Text = "00" & ":" & "00" & ":" & "00"
        End If

        Label6.Text = l.ToString.PadLeft(2, "0") & ":" & k.ToString.PadLeft(2, "0") & ":" & j.ToString.PadLeft(2, "0")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label4.Text = TimeString

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Timer2.Start()
    End Sub
    Private Sub buton4(sender As Object, e As EventArgs) Handles Button4.Click
        Timer2.Stop()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        u += 1
        If u + 1 = 60 Then
            u = 0
            i += 1
        ElseIf i + 1 = 60 Then
            i = 0
            o += 1
        End If
        Label5.Text = o.ToString.PadLeft(2, "0") & ":" & i.ToString.PadLeft(2, "0") & ":" & u.ToString.PadLeft(2, "0")
    End Sub

    Private Sub Label6_DoubleClick(sender As Object, e As EventArgs) Handles Label6.DoubleClick
        Timer3.Stop()
        Label6.Text = "00" & ":" & "00" & ":" & "00"
    End Sub

    Private Sub TextBox5_textt(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        My.Settings.szoveg = TextBox5.Text

    End Sub
End Class
