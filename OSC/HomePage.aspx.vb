Imports System.Data.SqlClient
Public Class WebForm5
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            Dim sqlconnection As New SqlConnection(connectionString)

            sqlconnection.Open()
            Dim command As New SqlCommand("SELECT [Post_Category_id], [Post_Category_Desc] FROM [Post_Categories]", sqlconnection)
            Dim reader As SqlDataReader = command.ExecuteReader()

            Dim dt As New DataTable()
            dt.Load(reader)

            'Close the connection
            sqlconnection.Close()

            rptViewbyCategory.DataSource = dt
            rptViewbyCategory.DataBind()

            Dim connectionString2 As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            Dim sqlconnection2 As New SqlConnection(connectionString2)

            sqlconnection2.Open()
            Dim command2 As New SqlCommand("SELECT top 15 Posts.Post_title, Posts.Post_id, posts.sys_date, users.Username FROM Posts INNER JOIN Users ON Posts.User_id = Users.User_ID Order by posts.sys_date DESC", sqlconnection2)
            Dim reader2 As SqlDataReader = command2.ExecuteReader()

            Dim dt2 As New DataTable()
            dt2.Load(reader2)

            'Close the connection
            sqlconnection2.Close()

            rptByNew.DataSource = dt2
            rptByNew.DataBind()

            Dim connectionString3 As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            Dim sqlconnection3 As New SqlConnection(connectionString3)

            sqlconnection3.Open()
            Dim command3 As New SqlCommand("SELECT top 15 user_id, sys_date, username, score from users where score >= 0 and username <> 'anon' order by score desc", sqlconnection3)
            Dim reader3 As SqlDataReader = command3.ExecuteReader()

            Dim dt3 As New DataTable()
            dt3.Load(reader3)

            'Close the connection
            sqlconnection3.Close()

            rptHotUsers.DataSource = dt3
            rptHotUsers.DataBind()


        End If
    End Sub

    Protected Sub btnNewPost_Click(sender As Object, e As EventArgs) Handles btnNewPost.Click
        Response.Redirect("UserPost.aspx")
    End Sub
    Private Sub rptViewbyCategory_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptViewbyCategory.ItemCommand
        If e.CommandName = "view" Then
            Response.Redirect("Viewposts.aspx?post_category_id=" & e.CommandArgument)
        End If
    End Sub

    Private Sub rptByNew_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptByNew.ItemCommand
        If e.CommandName = "view" Then
            Response.Redirect("View.aspx?post_id=" & e.CommandArgument)
        End If
    End Sub

    Private Sub rptHotUsers_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptHotUsers.ItemCommand
        If e.CommandName = "view" Then
            Response.Redirect("profile.aspx?other_user_id=" & e.CommandArgument)
        End If

    End Sub

End Class