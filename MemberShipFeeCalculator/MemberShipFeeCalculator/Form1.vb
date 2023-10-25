Public Class Form1
    Private Sub radAdult_CheckedChanged(sender As Object, e As EventArgs) Handles radAdult.CheckedChanged

    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        Dim decBaseFee As Decimal
        Dim decTotalFee As Decimal
        Dim intMonths As Integer
        Dim blnInputOk As Boolean = True

        Const decAdultFee As Decimal = 40
        Const decChildFee As Decimal = 20
        Const decStudentFee As Decimal = 25
        Const decSeniorFee As Decimal = 30

        Const decYogaFee As Decimal = 10
        Const decKarateFee As Decimal = 30
        Const decTrainerFee As Decimal = 50

        lblStatus.Text = String.Empty
        If Integer.TryParse(txtMonths.Text, intMonths) = False Then
            lblStatus.Text = " Months must be an integer"
            blnInputOk = False

        ElseIf intMonths < 1 Or intMonths > 24 Then
        lblStatus.Text = "Months must be in the range of 1-24"
            blnInputOk = False
        End If

        If blnInputOk = True Then
            If radAdult.Checked = True Then
                decBaseFee = decAdultFee
            ElseIf radChild.Checked = True Then
                decBaseFee = decChildFee
            ElseIf radStudent.Checked = True Then
                decBaseFee = decStudentFee
            ElseIf radSenior.Checked = True Then
                decBaseFee = decSeniorFee
            End If

            If chkYoga.Checked = True Then
                decBaseFee += decYogaFee
            End If

            If chkKarate.Checked = True Then
                decBaseFee += decKarateFee
            End If

            If chkTrainer.Checked = True Then
                decBaseFee += decTrainerFee
            End If

            decTotalFee = decBaseFee * intMonths

            lblMonthlyFee.Text = decBaseFee.ToString("c")
            lblTotalFee.Text = decTotalFee.ToString("c")
        End If


    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        Select Case MsgBox("This will clear all data.Are you sure to proceed?", vbYesNo, "Clear Input")


            Case MsgBoxResult.Yes

                radAdult.Checked = True

                chkKarate.Checked = False
                chkYoga.Checked = False
                chkTrainer.Checked = False

                txtMonths.Clear()

                lblMonthlyFee.Text = String.Empty
                lblTotalFee.Text = String.Empty
                lblStatus.Text = String.Empty

                txtMonths.Focus()

                MsgBox("You have clear all data", vbOKOnly, "Clear Input")

        End Select
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Select Case MsgBox("You will exit the application.Are you sure to proceed?", vbYesNo, "Exit Application")


            Case MsgBoxResult.Yes
                Me.Close()
                MsgBox("You have exit the application", vbOKOnly, "Exit Application")

        End Select
    End Sub
End Class
