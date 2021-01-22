Imports System.Data.SqlClient
Public Class WebForm4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Not Session("user_id") = Nothing AndAlso Session("user_id") <> 3 Then
                lblUserID.Text = Session("user_id")
            Else
                lblUserID.Text = 3
            End If

            If Not Request.QueryString("post_category_id") = Nothing Then
                    lblpostcategoryid.Text = Request.QueryString("post_category_id")

                    Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                    Dim sqlconnection As New SqlConnection(connectionString)

                    sqlconnection.Open()
                    Dim command As New SqlCommand("SELECT Post_Category_Desc FROM Post_Categories WHERE post_category_id = @post_category_id", sqlconnection)
                    command.Parameters.AddWithValue("@post_category_id", lblpostcategoryid.Text.Trim)
                    Dim reader As SqlDataReader = command.ExecuteReader()

                    Dim dt As New DataTable()
                    dt.Load(reader)

                    'Close the connection
                    sqlconnection.Close()

                    Dim rows() As DataRow = dt.Select("post_category_desc = post_category_desc")
                    If rows.Count > 0 Then
                        lblpostcategorydesc.Text = rows(0).Item("post_category_desc")
                        lblpostheader.Text = "Submit a Post in The "
                        Label1.Visible = True
                        lblpostcategorydesc.Visible = True
                    Else
                        lblpostheader.Text = "Submit a Post"
                        Label1.Visible = False
                        lblpostcategorydesc.Visible = False
                    End If
                Else
                    lblpostheader.Text = "Submit a Post"
                    Label1.Visible = False
                    cboCategory.Items.Insert(0, "")
                End If

                Dim connectionString2 As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                Dim sqlconnection2 As New SqlConnection(connectionString2)

                sqlconnection2.Open()
                Dim command2 As New SqlCommand("SELECT [Post_Category_Desc], [Post_Category_id] FROM [Post_Categories]", sqlconnection2)
                Dim reader2 As SqlDataReader = command2.ExecuteReader()

                Dim dt2 As New DataTable()
                dt2.Load(reader2)

                'Close the connection
                sqlconnection2.Close()

                If dt2.Rows.Count > 0 Then
                    cboCategory.DataSource = dt2
                    cboCategory.DataTextField = "Post_Category_Desc"
                    cboCategory.DataValueField = "Post_Category_id"
                    cboCategory.DataBind()
                End If


                If Not Request.QueryString("post_category_id") = Nothing Then
                    cboCategory.SelectedValue = Request.QueryString("post_category_id")
                    cboCategory.Enabled = False
                End If
            End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim boolerror = False
        Dim score As Integer = 0
        Dim newscore As Integer = 0
        Dim w As New WebCommonLib

        pnlvalidation.Visible = False
        lblValidationTitle.Visible = False
        lblValidationCategory.Visible = False
        lblValidationBody.Visible = False

        lblUserID.Text = Session("user_id")

        If txtTitle.Text.Trim = "" Then
            boolerror = True
            lblValidationTitle.Visible = True
            lblValidationTitle.Text = "Please enter a title for the post before submission."
        End If

        If cboCategory.SelectedItem.Text.Trim = "" Then
            boolerror = True
            lblValidationCategory.Visible = True
            lblValidationCategory.Text = "Please enter a Category for the post's submission."
        End If

        If txtPostBody.Text.Trim = "" Then
            boolerror = True
            lblValidationBody.Visible = True
            lblValidationBody.Text = "Please enter text into the post body before submission."
        End If

        If boolerror = True Then
            pnlvalidation.Visible = True
            Exit Sub
        End If

        Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim sqlconnection As New SqlConnection(connectionString)

        sqlconnection.Open()
        Dim command As New SqlCommand("Insert into [Posts] (Post_Title, Post_Desc, Post_Category_ID, User_id) Values (@Post_Title, @Post_Desc, @Post_category_id, @User_id)", sqlconnection)
        command.Parameters.AddWithValue("@Post_Title", txtTitle.Text.Trim)
        command.Parameters.AddWithValue("@Post_Desc", txtPostBody.Text.Trim)
        command.Parameters.AddWithValue("@Post_category_id", cboCategory.SelectedValue)
        command.Parameters.AddWithValue("@User_id", lblUserID.Text.Trim)
        command.ExecuteNonQuery()
        sqlconnection.Close()

        'select Users.score from Users WHERE users.User_id = @User_id

        sqlconnection.Open()
        Dim command2 As New SqlCommand("select Users.score from Users WHERE users.User_id = @User_id", sqlconnection)
        command2.Parameters.AddWithValue("@User_id", lblUserID.Text.Trim)
        Dim reader2 As SqlDataReader = command2.ExecuteReader()

        Dim dt2 As New DataTable()
        dt2.Load(reader2)

        'Close the connection
        sqlconnection.Close()

        Dim rows() As DataRow = dt2.Select("score = score")
        If rows.Count > 0 Then
            score = rows(0).Item("score")
            newscore = w.impScorePost(score)
        Else

        End If

        sqlconnection.Open()
        Dim command3 As New SqlCommand("Update Users SET users.Score = @score WHERE users.user_id = @User_id", sqlconnection)
        command3.Parameters.AddWithValue("@User_id", lblUserID.Text.Trim)
        command3.Parameters.AddWithValue("@Score", newscore)
        command3.ExecuteNonQuery()
        sqlconnection.Close()

        sqlconnection.Open()
        Dim command4 As New SqlCommand("select top 1 posts.post_id from Posts order by posts.sys_date desc", sqlconnection)
        Dim reader4 As SqlDataReader = command4.ExecuteReader()

        Dim dtt As New DataTable()
        dtt.Load(reader4)

        'Close the connection
        sqlconnection.Close()

        Dim rowss() As DataRow = dtt.Select("post_id = post_id")
        If rowss.Count > 0 Then
            lblpostid.Text = rowss(0).Item("post_id")
            Response.Redirect("View.aspx?post_id=" & lblpostid.Text.Trim)
        Else
            Response.Redirect("ViewPosts.aspx?post_category_id=" & cboCategory.SelectedValue)
        End If

    End Sub
End Class