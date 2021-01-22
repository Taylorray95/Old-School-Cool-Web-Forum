Imports System.Data.SqlClient
Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("user_id") = Nothing Then
                lblUserID.Text = Session("user_id")
            End If
            If Not Request.QueryString("Post_id") = Nothing Then
                    lblPostId.Text = Request.QueryString("Post_id")
                Else
                    Response.Redirect("error.aspx")
                End If

                If lblPostId.Text.Trim <> Nothing AndAlso lblPostId.Text.Trim <> "" Then
                    Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                    Dim sqlconnection As New SqlConnection(connectionString)

                    sqlconnection.Open()
                    Dim command As New SqlCommand("SELECT Posts.Post_id, Posts.Post_Title, Posts.Post_Desc, Posts.Post_category_id, Posts.Deleted_flag, Posts.Active_Flag, Posts.Private_Flag, Posts.Reported_Flag, Posts.User_id, Posts.sys_date, Users.User_ID AS Expr1, Users.Username, Users.First_Name, Users.Last_Name, Users.Score, Users.Password, Users.Picture_Path, Users.Email, Users.Recovery_Question_ID, Users.Recovery_Answer, Users.Active_Flag AS Expr2, Users.Banned_Flag, Users.Reported_Flag AS Expr3, Users.sys_date AS Expr4 FROM Posts INNER JOIN Users ON Posts.User_id = Users.User_ID WHERE Post_id = @Post_id", sqlconnection)
                    command.Parameters.AddWithValue("@Post_id", lblPostId.Text.Trim)
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

                    sqlconnection.Open()
                    Dim command2 As New SqlCommand("SELECT Comments.Comment_id, Comments.Post_id, Comments.Comment_Desc, Comments.User_id, Comments.Deleted_Flag, Comments.Removed_Flag, Comments.Reported_Flag, Comments.sys_date, Users.Username, Users.Score, Users.Picture_Path, Users.Reported_Flag AS Expr1, Users.sys_date AS Expr2, Users.User_ID AS Expr3 FROM Comments INNER JOIN Users ON Comments.User_id = Users.User_ID WHERE [Post_id] = @Post_id", sqlconnection)
                    command2.Parameters.AddWithValue("@Post_id", lblPostId.Text.Trim)
                    Dim reader2 As SqlDataReader = command2.ExecuteReader()

                    Dim dt2 As New DataTable()
                    dt2.Load(reader2)

                    'Close the connection
                    sqlconnection.Close()

                    If dt2.Rows.Count > 0 Then
                        rptComments.DataSource = dt2
                        rptComments.DataBind()
                    Else
                        rptComments.DataSource = Nothing
                    End If
                End If
            End If
        'rptViewbyCategory
    End Sub
    'SELECT Posts.Post_id, Posts.Post_Title, Posts.Post_Desc, Posts.Post_category_id, Posts.Deleted_flag, Posts.Active_Flag, Posts.Private_Flag, Posts.Reported_Flag, Posts.User_id, Posts.sys_date, Users.User_ID AS Expr1, Users.Username, Users.First_Name, Users.Last_Name, Users.Score, Users.Password, Users.Picture_Path, Users.Email, Users.Recovery_Question_ID, Users.Recovery_Answer, Users.Active_Flag AS Expr2, Users.Banned_Flag, Users.Reported_Flag AS Expr3, Users.sys_date AS Expr4 FROM Posts INNER JOIN Users ON Posts.User_id = Users.User_ID WHERE ([Post_id] = @Post_id)">
    '"SELECT Comments.Comment_id, Comments.Post_id, Comments.Comment_Desc, Comments.User_id, Comments.Deleted_Flag, Comments.Removed_Flag, Comments.Reported_Flag, Comments.sys_date, Users.Username, Users.Score, Users.Picture_Path, Users.Reported_Flag AS Expr1, Users.sys_date AS Expr2, Users.User_ID AS Expr3 FROM Comments INNER JOIN Users ON Comments.User_id = Users.User_ID WHERE ([Post_id] = @Post_id)"

    Private Sub rptComments_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptComments.ItemCommand
        If e.CommandName = "View" Then
            Response.Redirect("Profile.aspx?other_user_id=" & e.CommandArgument)
        End If
    End Sub

    Private Sub rptViewbyCategory_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptViewbyCategory.ItemCommand
        If e.CommandName = "View" Then
            Response.Redirect("Profile.aspx?other_user_id=" & e.CommandArgument)
        End If
    End Sub

    Private Sub rptComments_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptComments.ItemDataBound

        For Each item In rptComments.Items

            Dim lblUserComment As LinkButton = TryCast(item.FindControl("lblUserComment"), LinkButton)

            lblUserComment.Attributes.Add("href", "Profile.aspx?other_user_id=" & lblUserComment.CommandArgument)

        Next

    End Sub

    Private Sub rptViewbyCategory_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptViewbyCategory.ItemDataBound
        For Each item In rptViewbyCategory.Items

            Dim lblusername As LinkButton = TryCast(item.FindControl("lblusername"), LinkButton)

            lblusername.Attributes.Add("href", "Profile.aspx?other_user_id=" & lblusername.CommandArgument)

        Next
    End Sub

    Protected Sub btnSaveComment_Click(sender As Object, e As EventArgs) Handles btnSaveComment.Click
        Dim score As Integer = 0
        Dim newScore As Integer = 0
        Dim boolerror As Boolean = False
        pnlval.Visible = False
        lblValCommentEmpty.Visible = False
        lblValCommentShort.Visible = False
        lblValCommentEmpty.Text = ""
        lblValCommentShort.Text = ""

        If txtComment.Text.Trim = "" Then
            pnlval.Visible = True
            lblValCommentEmpty.Visible = True
            lblValCommentEmpty.Text = "Please enter text int the comment field before submitting your comment."
            boolerror = True
        End If

        If txtComment.Text.Trim.Length < 6 Then
            pnlval.Visible = True
            lblValCommentShort.Visible = True
            lblValCommentShort.Text = "Oops this comment seems just a bit too short, please write a bit more :)"
            boolerror = True
        End If

        If boolerror = True Then
            Exit Sub
        End If
        'select Users.score from Users WHERE users.User_id = @User_id

        Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim sqlconnection As New SqlConnection(connectionString)

        sqlconnection.Open()
        Dim command As New SqlCommand("select Users.score from Users WHERE users.User_id = @User_id", sqlconnection)
        command.Parameters.AddWithValue("@User_id", lblUserID.Text.Trim)
        Dim reader As SqlDataReader = command.ExecuteReader()

        Dim dt As New DataTable()
        dt.Load(reader)

        'Close the connection
        sqlconnection.Close()

        Dim w As New WebCommonLib

        Dim roww() As DataRow = dt.Select("score = score")
        If roww.Count > 0 Then
            score = roww(0).Item("score")
        End If

        newScore = w.impScoreComment(score)

        'Update Users SET users.Score = @score WHERE users.user_id = @User_id

        sqlconnection.Open()
        Dim command_update_score As New SqlCommand("Update Users SET users.Score = @score WHERE users.user_id = @User_id", sqlconnection)
        command_update_score.Parameters.AddWithValue("@User_id", lblUserID.Text.Trim)
        command_update_score.Parameters.AddWithValue("@Score", newScore)

        command_update_score.ExecuteNonQuery()
        sqlconnection.Close()

        'Insert into [Comments] (Post_id, Comment_Desc, User_Id) Values (@Post_id, @Comment_Desc, @User_Id)

        sqlconnection.Open()
        Dim command_new_comment As New SqlCommand("Insert into [Comments] (Post_id, Comment_Desc, User_Id) Values (@Post_id, @Comment_Desc, @User_Id)", sqlconnection)
        command_new_comment.Parameters.AddWithValue("@Post_id", lblPostId.Text.Trim)
        command_new_comment.Parameters.AddWithValue("@Comment_Desc", txtComment.Text.Trim)
        command_new_comment.Parameters.AddWithValue("@User_Id", lblUserID.Text.Trim)
        command_new_comment.ExecuteNonQuery()
        sqlconnection.Close()


        Response.Redirect("View.aspx?Post_id=" & lblPostId.Text.Trim)
    End Sub

End Class