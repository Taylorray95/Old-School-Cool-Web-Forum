Imports System.Data.SqlClient
Public Class SiteMaster
    Inherits MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("user_id") = Nothing Then
                Session("user_id") = 3
            End If


            If Session("user_id") = Nothing Or Session("user_id") = 3 Then
                lblUSername.Visible = True
                lblUSername.Text = "Anonymous User"
                lblLoggedInUser.Visible = True
                lblUSername.Visible = True

            Else
                lblLoggedInUser.Visible = True
                lblUSername.Visible = True
            End If

            If Not Session("User_id") = Nothing Then
                If Not Session("User_id") = 3 Then
                    Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                    Dim sqlconnection As New SqlConnection(connectionString)

                    sqlconnection.Open()
                    Dim command As New SqlCommand("Select [Username], [User_id] FROM [Users] Where User_id = @user_id", sqlconnection)
                    command.Parameters.AddWithValue("@user_id", Session("User_id"))
                    Dim reader As SqlDataReader = command.ExecuteReader()

                    Dim dt As New DataTable()
                    dt.Load(reader)

                    'Close the connection
                    sqlconnection.Close()

                    If dt.Rows.Count > 0 Then
                        lblUSername.Text = dt.Rows(0).Item(0)
                    End If

                End If



            End If
        End If
    End Sub

    Protected Sub lblUSername_Click(sender As Object, e As EventArgs) Handles lblUSername.Click
        If Session("User_id") = Nothing Or Session("User_id") = 3 Then
            Response.Redirect("Login.aspx")
        Else
            Response.Redirect("Profile.aspx")
        End If
    End Sub

    Private Sub btnprofile_ServerClick(sender As Object, e As EventArgs) Handles btnprofile.ServerClick
        If Session("user_id") = Nothing Or Session("user_id") = 3 Then
            Response.Redirect("login.aspx?anonacc_flag=1")
        End If
        If Not Session("user_id") = Nothing And Not Session("user_id") = 3 Then
            Response.Redirect("profile.aspx?")
        End If
    End Sub


End Class