Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
    End Sub

   
    Private Sub Calc_Click(sender As Object, e As EventArgs) Handles Calc.Click

        Dim cx As Double
        Dim comy As Double
        Dim magn As Double
        Dim angle As Double
        If COM.Text <> "" Or CY.Text <> "" Then
            If COM.Text = "" Then
                cx = 0
            Else
                cx = COM.Text
            End If
            If CY.Text = "" Then
                comy = 0
            Else
                comy = CY.Text
            End If
            magn = Math.Sqrt((cx * cx) + (comy * comy))
            If cx = 0 Then
                angle = 90
            Else
                If comy = 0 Then
                    angle = 0
                Else
                    angle = comy / cx
                    angle = Math.Atan(angle)
                    angle = angle * (180 / Math.PI)

                    If cx > 0 And comy > 0 Then
                        angle = angle
                    ElseIf cx > 0 And comy < 0 Then
                        angle = 360 + angle
                    ElseIf cx < 0 And comy < 0 Then
                        angle = 270 - angle
                    ElseIf cx < 0 And comy > 0 Then
                        angle = 180 + angle
                    End If

                End If
            End If
            angulo.Text = "Ángulo= "
            angulo.Text = angulo.Text + angle.ToString
            magnitud.Text = "Magnitud= "
            magnitud.Text = magnitud.Text + magn.ToString
            Dim pendiente As Double
            pendiente = comy / cx
            pen.Text = "Pendiente= " + pendiente.ToString
            If pendiente < 0 And pendiente <> 0 Then
                dir.Text = "Direccion= descendiente"
            ElseIf pendiente <> 0 Then
                dir.Text = "Direccion= ascendiente "
            Else
                dir.Text = "No hay valores ingresados"
            End If

            Dim scale As Integer
            scale = 10
            Dim centerx As Integer
            Dim centery As Integer
            centerx = PictureBox1.Size.Height / 2
            centery = centerx
            Dim i As Integer
            i = 1
            PictureBox1.CreateGraphics.Clear(Color.Black)
            While i < PictureBox1.Size.Height

                PictureBox1.CreateGraphics.DrawLine(Pens.Aquamarine, i, 0, i, PictureBox1.Size.Height)
                PictureBox1.CreateGraphics.DrawLine(Pens.Aquamarine, 0, i, PictureBox1.Size.Height, i)
                i = i + 10
            End While
            Dim blackPen As New Pen(Color.PaleVioletRed, 4)
            PictureBox1.CreateGraphics.DrawLine(blackPen, centerx, centery, centerx + CInt(cx) * scale, centery - CInt(comy) * scale)
        Else
            magnitud.Text = "No se ingresaron valores"
        End If
    End Sub

    

    Private Sub CY_TextChanged(sender As Object, e As EventArgs) Handles CY.TextChanged

    End Sub

    Private Sub COM_TextChanged(sender As Object, e As EventArgs) Handles COM.TextChanged

    End Sub

    Private Sub magnitud_Click(sender As Object, e As EventArgs) Handles magnitud.Click

    End Sub

    Private Sub angulo_Click(sender As Object, e As EventArgs) Handles angulo.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class
