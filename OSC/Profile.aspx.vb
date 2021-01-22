Imports System.Data.SqlClient
Public Class WebForm8
    Inherits System.Web.UI.Page
    'select comment_desc, comment_id, post_id, sys_date from comments WHERE User_id = @User_id
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            Dim sqlconnection As New SqlConnection(connectionString)
            Dim w As New WebCommonLib

            If Not Request.QueryString("other_user_id") = Nothing AndAlso (Session("user_id") <> Request.QueryString("other_user_id")) Then
                lblUserid.Text = Request.QueryString("other_user_id")
                btnLogout.Visible = False
                btnEditaccount.Visible = False
                lblMyActivityHeader.Text = "Activity"
            Else
                If Session("user_id") <> Nothing Then
                    If Session("user_id") <> 3 Then
                        lblUserid.Text = Session("user_id")


                        If Session("user_id") = Nothing Or Session("user_id") = 3 Then

                            lblMyActivityHeader.Text = "Account Activity"
                        Else
                            lblMyActivityHeader.Text = "My Activity"

                        End If
                    Else
                        Response.Redirect("login.aspx/anonacc_flag=1")
                    End If
                End If
            End If

            'If (Session("user_id") = Nothing Or Session("user_id") = 3) AndAlso Request.QueryString("other_user_id") = Nothing Or IsNumeric(Request.QueryString("other_user_id")) = False Then
            ' Response.Redirect("login.aspx")
            ' End If


            'if request.querystring("other_user_id") = nothing andalso isnumeric(request.querystring("other_user_id")) = false andalso session("user_id") <> nothing then


            '    if session("user_id") <> 3 or session("user_id") <> nothing then


            '        lbluserid.text = session("user_id")

            '        sqlconnection.open()
            '        dim command5 as new sqlcommand("select users.username, users.score, users.first_name + ' ' + users.last_name as name from users where users.user_id = @user_id", sqlconnection)
            '        command5.parameters.addwithvalue("@user_id", lbluserid.text.trim)
            '        dim reader5 as sqldatareader = command5.executereader()

            '        dim dt5 as new datatable()
            '        dt5.load(reader5)

            '        'close the connection
            '        sqlconnection.close()

            '        dim row_usernamee() as datarow = dt5.select("username = username")
            '        dim row_scoree() as datarow = dt5.select("score = score")
            '        dim rownamee() as datarow = dt5.select("name = name")

            '        if row_usernamee.count > 0 then
            '            lblusername.text = row_usernamee(0).item("username")
            '        else
            '            lblusername.text = "error"
            '        end if
            '        if row_scoree.count > 0 then
            '            lblscore.text = row_scoree(0).item("score")
            '        else
            '            lblscore.text = "error"
            '        end if
            '        if row_scoree.count > 0 then
            '            lblname.text = row_scoree(0).item("score")
            '        else
            '            lblname.text = "error"
            '        end if

            '        lbluserrank.text = w.getrank(lblscore.text.trim)

            '        sqlconnection.open()
            '        dim command_commentss as new sqlcommand("select comment_desc, comment_id, post_id, sys_date from comments where user_id = @user_id", sqlconnection)
            '        command_commentss.parameters.addwithvalue("@user_id", lbluserid.text.trim)
            '        dim reader_commentss as sqldatareader = command_commentss.executereader()

            '        dim dt_commentss as new datatable()
            '        dt_commentss.load(reader_commentss)

            '        if dt_commentss.rows.count > 0 then
            '            rptcommentactivity.datasource = dt_commentss
            '            rptcommentactivity.databind()
            '        else
            '            rptcommentactivity.datasource = nothing
            '        end if

            '        dim ccommand_total_comments as new sqlcommand("select count(*) as number_of_comments from comments where user_id = @user_id", sqlconnection)
            '        ccommand_total_comments.parameters.addwithvalue("@user_id", lbluserid.text.trim)
            '        dim rreader_total_comments as sqldatareader = ccommand_total_comments.executereader()

            '        dim dtt_total_comments as new datatable()
            '        dtt_total_comments.load(rreader_total_comments)

            '        dim rrow_total_comments() as datarow = dtt_total_comments.select("number_of_comments = number_of_comments")
            '        if rrow_total_comments.count > 0 then
            '            lbltotalcomments.text = rrow_total_comments(0).item("username")
            '        else
            '            lbltotalcomments.text = "error"
            '        end if

            '        dim ccommand_total_posts as new sqlcommand("select count(*) as number_of_posts from posts where user_id = @user_id", sqlconnection)
            '        ccommand_total_posts.parameters.addwithvalue("@user_id", lbluserid.text.trim)
            '        dim rreader_total_posts as sqldatareader = ccommand_total_posts.executereader()

            '        dim dddt_total_posts as new datatable()
            '        dddt_total_posts.load(rreader_total_posts)

            '        dim rrrow_total__posts() as datarow = dddt_total_posts.select("number_of_posts = number_of_posts")
            '        if rrrow_total__posts.count > 0 then
            '            lbltotalposts.text = rrrow_total__posts(0).item("number_of_posts")
            '        else
            '            lbltotalposts.text = "error"
            '        end if

            '        'select post_title, post_id, sys_date from posts where user_id = @user_id

            '        dim command_posts2 as new sqlcommand("select post_title, post_id, sys_date from posts where user_id = @user_id", sqlconnection)
            '        command_posts2.parameters.addwithvalue("@user_id", lbluserid.text.trim)
            '        dim reader_posts2 as sqldatareader = command_posts2.executereader()

            '        dim dt_posts2 as new datatable()
            '        dt_posts2.load(reader_posts2)

            '        if dt_posts2.rows.count > 0 then
            '            rptrecentposts.datasource = dt_posts2
            '            rptrecentposts.databind()
            '        else
            '            rptrecentposts.datasource = nothing
            '        end if

            '        sqlconnection.close()
            '    else
            '        response.redirect("login.aspx")
            '    end if

            'else
            '    response.redirect("login.aspx")
            'end if

            'lblUserid.Text = Request.QueryString("other_user_id")

            sqlconnection.Open()
            Dim command As New SqlCommand("select Users.username, Users.score, Users.First_Name + ' ' + users.Last_name as name from Users WHERE users.User_id = @User_id", sqlconnection)
            command.Parameters.AddWithValue("@User_id", lblUserid.Text.Trim)
            Dim reader As SqlDataReader = command.ExecuteReader()

            Dim dt As New DataTable()
            dt.Load(reader)

            'Close the connection
            sqlconnection.Close()

            Dim row_username() As DataRow = dt.Select("username = username")
            Dim row_score() As DataRow = dt.Select("score = score")
            Dim rowname() As DataRow = dt.Select("name = name")
            If row_username.Count > 0 Then
                lblUsername.Text = row_username(0).Item("username")
            Else
                lblUsername.Text = "error"
            End If
            If row_score.Count > 0 Then
                lblscore.Text = row_score(0).Item("score")
            Else
                lblscore.Text = "error"
            End If
            If row_score.Count > 0 Then
                lblname.Text = row_score(0).Item("name")
            Else
                lblname.Text = "name"
            End If

            lblUserRank.Text = w.GetRank(lblscore.Text.Trim)

            sqlconnection.Open()
            Dim command_comments As New SqlCommand("select comment_desc, comment_id, post_id, sys_date from comments WHERE User_id = @User_id", sqlconnection)
            command_comments.Parameters.AddWithValue("@User_id", lblUserid.Text.Trim)
            Dim reader_comments As SqlDataReader = command_comments.ExecuteReader()

            Dim dt_comments As New DataTable()
            dt_comments.Load(reader_comments)

            If dt_comments.Rows.Count > 0 Then
                rptCommentActivity.DataSource = dt_comments
                rptCommentActivity.DataBind()
            Else
                rptCommentActivity.DataSource = Nothing
            End If

            Dim command_total_comments As New SqlCommand("select count(*) as number_of_comments from Comments WHERE User_id = @User_id", sqlconnection)
            command_total_comments.Parameters.AddWithValue("@User_id", lblUserid.Text.Trim)
            Dim reader_total_comments As SqlDataReader = command_total_comments.ExecuteReader()

            Dim dt_total_comments As New DataTable()
            dt_total_comments.Load(reader_total_comments)

            Dim row_total_comments() As DataRow = dt_total_comments.Select("number_of_comments = number_of_comments")
            If row_total_comments.Count > 0 Then
                lblTotalComments.Text = row_username(0).Item(0)
            Else
                lblTotalComments.Text = "error"
            End If

            Dim command_total_posts As New SqlCommand("select count(*) as number_of_posts from Posts WHERE User_id = @User_id", sqlconnection)
            command_total_posts.Parameters.AddWithValue("@User_id", lblUserid.Text.Trim)
            Dim reader_total_posts As SqlDataReader = command_total_posts.ExecuteReader()

            Dim dt_total_posts As New DataTable()
            dt_total_posts.Load(reader_total_posts)

            Dim row_total__posts() As DataRow = dt_total_posts.Select("number_of_posts = number_of_posts")
            If row_total__posts.Count > 0 Then
                lblTotalPosts.Text = row_total__posts(0).Item("number_of_posts")
            Else
                lblTotalPosts.Text = "error"
            End If

            'select post_title, post_id, sys_date from Posts WHERE User_id = @User_id

            Dim command_posts As New SqlCommand("select post_title, post_id, sys_date from Posts WHERE User_id = @User_id", sqlconnection)
            command_posts.Parameters.AddWithValue("@User_id", lblUserid.Text.Trim)
            Dim reader_posts As SqlDataReader = command_posts.ExecuteReader()

            Dim dt_posts As New DataTable()
            dt_posts.Load(reader_posts)


            If row_total__posts.Count > 0 Then
                rptRecentPosts.DataSource = dt_posts
                rptRecentPosts.DataBind()
            Else
                rptRecentPosts.DataSource = Nothing
            End If

            sqlconnection.Close()
        End If



        'End If
    End Sub
    'select Users.username, Users.score, Users.First_Name + ' ' + users.Last_name as name from Users WHERE users.User_id = @User_id
    Protected Sub btnEditaccount_Click(sender As Object, e As EventArgs) Handles btnEditaccount.Click

        Response.Redirect("EditAccount.aspx?")

    End Sub

    Protected Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Session("User_id") = Nothing
        Response.Redirect("homepage.aspx")
    End Sub

    Private Sub rptCommentActivity_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptCommentActivity.ItemCommand
        If e.CommandName = "view" Then
            Response.Redirect("View.aspx?post_id=" & e.CommandArgument)
        End If
    End Sub

    Private Sub rptRecentPosts_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptRecentPosts.ItemCommand
        If e.CommandName = "view" Then
            Response.Redirect("View.aspx?post_id=" & e.CommandArgument)
        End If
    End Sub

    Public Function CheckLength(strComment As String) As String
        Dim returnString As String = ""

        If strComment.Length > 35 Then
            returnString = strComment.Substring(0, 35)
            Return returnString
        Else
            Return strComment
        End If
    End Function

End Class