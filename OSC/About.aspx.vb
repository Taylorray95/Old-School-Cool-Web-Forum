Imports System.Data.SqlClient
Public Class WebForm7
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("user_id") = Nothing Then
                lblUserID.Text = Session("user_id")
            Else
                lblUserID.Text = 3
            End If
        End If
    End Sub

    Protected Sub btnReportabug_Click(sender As Object, e As EventArgs) Handles btnReportabug.Click

        pnlvalidation.Visible = False
        pnlReportBug.Visible = False
        pnlReportForm.Visible = True

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        pnlvalidation.Visible = False
        lblValidationMessage.Text = ""
        pnlReportBug.Visible = True
        pnlReportForm.Visible = False
        txtboxBug.Text = ""
    End Sub

    Private Sub btnSubmitBug_Click(sender As Object, e As EventArgs) Handles btnSubmitBug.Click
        pnlvalidation.Visible = False

        If txtboxBug.Text.Trim = "" Then
            lblValidationMessage.Text = "Must enter in a big report before submitting."
            pnlvalidation.Visible = True
            Exit Sub
        Else
            'Insert into [Bug_Reports] (user_id, bug_report_desc) values (@user_id, @bug_report_desc)

            Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            Dim sqlconnection As New SqlConnection(connectionString)

            sqlconnection.Open()
            Dim command As New SqlCommand("Insert into [Bug_Reports] (user_id, bug_report_desc, active_flag) values (@user_id, @bug_report_desc, 1)", sqlconnection)
            command.Parameters.AddWithValue("@user_id", lblUserID.Text.Trim)
            command.Parameters.AddWithValue("@bug_report_desc", txtboxBug.Text.Trim)

            command.ExecuteNonQuery()
            sqlconnection.Close()


            lblsucc.Visible = True
            pnlReportBug.Visible = True
            pnlReportForm.Visible = False
        End If
    End Sub

End Class