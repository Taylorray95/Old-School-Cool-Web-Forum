
Imports System.Data.SqlClient
Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If (Request.QueryString("post_category_id")) = 1 Then
                Me.lbltheheader.Text = "Misc Posts"
                lblpostcategoryid.Text = Request.QueryString("post_category_id")
            End If
            If (Request.QueryString("post_category_id")) = 2 Then
                Me.lbltheheader.Text = "Current Events"
                lblpostcategoryid.Text = Request.QueryString("post_category_id")
            End If
            If (Request.QueryString("post_category_id")) = 3 Then
                Me.lbltheheader.Text = "College Help"
                lblpostcategoryid.Text = Request.QueryString("post_category_id")
            End If
            If (Request.QueryString("post_category_id")) = 4 Then
                Me.lbltheheader.Text = "DIY"
                lblpostcategoryid.Text = Request.QueryString("post_category_id")
            End If
            If (Request.QueryString("post_category_id")) = 5 Then
                Me.lbltheheader.Text = "Coronavirus"
                lblpostcategoryid.Text = Request.QueryString("post_category_id")
            End If
            If (Request.QueryString("post_category_id")) = 6 Then
                Me.lbltheheader.Text = "Pop Culture"
                lblpostcategoryid.Text = Request.QueryString("post_category_id")
            End If
            If (Request.QueryString("post_category_id")) = 7 Then
                Me.lbltheheader.Text = "Sports"
                lblpostcategoryid.Text = Request.QueryString("post_category_id")
            End If
            If (Request.QueryString("post_category_id")) = 8 Then
                Me.lbltheheader.Text = "Memes"
                lblpostcategoryid.Text = Request.QueryString("post_category_id")
            End If

            'ELECT Posts.Post_id, Posts.Post_Title, Posts.Post_Desc, Posts.Post_category_id, Posts.Deleted_flag, Posts.Active_Flag, Posts.Private_Flag, Posts.Reported_Flag, Posts.User_id, Posts.sys_date, Users.User_ID AS Expr1, Users.Username, Users.First_Name, Users.Last_Name, Users.Score, Users.Password, Users.Picture_Path, Users.Email, Users.Recovery_Question_ID, Users.Recovery_Answer, Users.Active_Flag AS Expr2, Users.Banned_Flag, Users.Reported_Flag AS Expr3, Users.sys_date AS Expr4 FROM Posts INNER JOIN Users ON Posts.User_id = Users.User_ID WHERE ([Post_category_id] = @Post_category_id)

            Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            Dim sqlconnection As New SqlConnection(connectionString)

            sqlconnection.Open()
            Dim command As New SqlCommand("SELECT Posts.Post_id, Posts.Post_Title, Posts.Post_Desc, Posts.Post_category_id, Posts.Deleted_flag, Posts.Active_Flag, Posts.Private_Flag, Posts.Reported_Flag, Posts.User_id, Posts.sys_date, Users.User_ID AS Expr1, Users.Username, Users.First_Name, Users.Last_Name, Users.Score, Users.Password, Users.Picture_Path, Users.Email, Users.Recovery_Question_ID, Users.Recovery_Answer, Users.Active_Flag AS Expr2, Users.Banned_Flag, Users.Reported_Flag AS Expr3, Users.sys_date AS Expr4 FROM Posts INNER JOIN Users ON Posts.User_id = Users.User_ID WHERE Post_category_id = @Post_category_id", sqlconnection)
            command.Parameters.AddWithValue("@Post_category_id", lblpostcategoryid.Text.Trim)
            Dim reader As SqlDataReader = command.ExecuteReader()

            Dim dt As New DataTable()
            dt.Load(reader)

            'Close the connection
            sqlconnection.Close()

            If dt.Rows.Count > 0 Then
                rptViewbyCategory.DataSource = dt
                rptViewbyCategory.DataBind()
            Else
                rptViewbyCategory.DataSource = Nothing
            End If

        End If
    End Sub

    Private Sub rptViewbyCategory_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptViewbyCategory.ItemCommand
        If e.CommandName = "view" Then
            If e.CommandName = "view" Then
                Response.Redirect("View.aspx?post_id=" & e.CommandArgument)
            End If
        End If
    End Sub

    Protected Sub btnNewPost_Click(sender As Object, e As EventArgs) Handles btnNewPost.Click
        lblpostcategoryid.Text = Request.QueryString("post_category_id")
        If lblpostcategoryid.Text <> "" Then
            Response.Redirect("UserPost.aspx?post_category_id=" & lblpostcategoryid.Text.Trim())
        Else
            Response.Redirect("UserPost.aspx")
        End If
    End Sub
End Class