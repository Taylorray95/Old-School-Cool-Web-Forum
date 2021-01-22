Imports System.Data.SqlClient

Public Class WebForm6

    Inherits System.Web.UI.Page
    Dim cbochanged As Boolean = False
    Dim strrecovanswer As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("user_id") = Nothing Then
                lblUserid.Text = Session("user_id")

                Dim connectionString2 As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                Dim sqlconnection2 As New SqlConnection(connectionString2)

                sqlconnection2.Open()
                Dim command2 As New SqlCommand("SELECT [Recovery_Questions_Desc], [Recovery_Question_id] FROM [Recovery_Questions]", sqlconnection2)
                Dim reader2 As SqlDataReader = command2.ExecuteReader()

                Dim dt2 As New DataTable()
                dt2.Load(reader2)

                'Close the connection
                sqlconnection2.Close()

                If dt2.Rows.Count > 0 Then
                    cboResetRecovery.DataSource = dt2
                    cboResetRecovery.DataTextField = "Recovery_Questions_Desc"
                    cboResetRecovery.DataValueField = "Recovery_Question_id"
                    cboResetRecovery.DataBind()
                End If


                lblUserid.Text = Session("user_id")
                Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                Dim sqlconnection As New SqlConnection(connectionString)

                sqlconnection.Open()
                Dim command As New SqlCommand("select Users.username, Users.First_Name, users.Last_name, users.recovery_question_id, users.email,users.recovery_answer, users.password from Users WHERE users.User_id = @User_id", sqlconnection)
                command.Parameters.AddWithValue("@User_id", lblUserid.Text.Trim)
                Dim reader As SqlDataReader = command.ExecuteReader()

                Dim dt As New DataTable()
                dt.Load(reader)

                'Close the connection
                sqlconnection.Close()

                If dt.Rows.Count > 0 Then
                   
                    Dim row_username() As DataRow = dt.Select("username = username")
                    Dim row_First_Namee() As DataRow = dt.Select("First_Name = First_Name")
                    Dim row_Last_name() As DataRow = dt.Select("Last_name = Last_name")
                    Dim row_email() As DataRow = dt.Select("email = email")
                    Dim row_recovery_answer() As DataRow = dt.Select("recovery_answer = recovery_answer")
                    Dim row_question_id() As DataRow = dt.Select("recovery_question_id = recovery_question_id")

                    If row_recovery_answer.Count > 0 Then
                        strrecovanswer = row_recovery_answer(0).Item("recovery_answer")
                    End If

                    If row_question_id.Count > 0 Then
                        cboResetRecovery.SelectedValue = row_question_id(0).Item("recovery_question_id")
                        lblNewRecovQuestionid.Text = row_question_id(0).Item("recovery_question_id").ToString
                        lblRecoveryQuestionid.Text = row_question_id(0).Item("recovery_question_id").ToString
                    End If

                    If row_username.Count > 0 Then
                        txtUsername.Text = row_username(0).Item("username")
                    Else
                        txtUsername.Text = ""
                    End If

                    If row_First_Namee.Count > 0 Then
                        txtFirst.Text = row_First_Namee(0).Item("First_Name")
                    Else
                        txtFirst.Text = ""
                    End If

                    If row_Last_name.Count > 0 Then
                        txtLastName.Text = row_Last_name(0).Item("Last_name")
                    Else
                        txtLastName.Text = ""
                    End If

                    If row_email.Count > 0 Then
                        txtEmail.Text = row_email(0).Item("email")
                    Else
                        txtEmail.Text = ""
                    End If

                    If row_recovery_answer.Count > 0 Then
                        txtRecoveryQuestionAnswer.Text = row_recovery_answer(0).Item("recovery_answer")
                        lblrecoveryanswer.Text = row_recovery_answer(0).Item("recovery_answer")
                    Else
                        txtRecoveryQuestionAnswer.Text = ""
                    End If

                Else

                End If
            Else
                Response.Redirect("error.aspx")
            End If
        Else

        End If


    End Sub

    Protected Sub btnSaveChanges_Click(sender As Object, e As EventArgs) Handles btnSaveChanges.Click
        resetValidationPnl()
        Dim boolerror As Boolean = False
        Dim w As New WebCommonLib

        lblNewRecovAnswer.Text = txtRecoveryQuestionAnswer.Text.Trim

        If lblNewRecovQuestionid.Text.Trim <> lblRecoveryQuestionid.Text Then
            If lblNewRecovAnswer.Text.Trim = lblrecoveryanswer.Text.Trim Then
                pnlCreateAccountValidation.Visible = True
                lblvalrecovery.Visible = True
                lblvalrecovery.Text = "You seem to have changed your recovery question however have not changed the answer to your recovery question. Please either cancel the account edit or change both your recovery question and answer,"
            End If
        End If

        If cboResetRecovery.SelectedItem.Text.Trim = "" Or txtRecoveryQuestionAnswer.Text.Trim = "" Then
            lblNoRecoveryQuestionOrAnswer.Visible = True
            lblNoRecoveryQuestionOrAnswer.Text = "Must select a recovery question as well as an answer."
            boolerror = True
            pnlCreateAccountValidation.Visible = True
        End If

        If txtUsername.Text = "" Or txtEmail.Text.Trim = "" Then
            lblValUserNameAlreadyExists.Visible = True
            lblValUserNameAlreadyExists.Text = "Must enter both a username and an email address for your account."
            boolerror = True
            pnlCreateAccountValidation.Visible = True
            Exit Sub
        End If

        If txtUsername.Text.Trim <> "" Then
            'If valCheckUsername(txtUsername.Text.Trim) = False Then
            '    pnlCreateAccountValidation.Visible = True
            '    boolerror = True
            '    lblValUserNameAlreadyExists.Visible = True
            '    lblValUserNameAlreadyExists.Text = "Your given username already exists, please choose a different username."
            'End If
        End If

        If txtEmail.Text.Trim <> "" Then
            If w.IsValidEmailFormat(txtEmail.Text.Trim) = False Then
                pnlCreateAccountValidation.Visible = True
                boolerror = True
                lblValEmailNotCorrectFormt.Visible = True
                lblValEmailNotCorrectFormt.Text = "Email address does not seem to be valid."
            End If
        End If

        If boolerror = True Then
            Exit Sub
        End If
        'Update Users SET Password = @Password, Username= @username, Recovery_Question_Id = @Recovery_Question_Id, Recovery_Answer = @Recovery_Answer, email = @Email, first_name = @First_name, last_name = @Last_name  WHERE users.user_id = @User_id

        Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim sqlconnection As New SqlConnection(connectionString)

        sqlconnection.Open()
        Dim command As New SqlCommand("Update Users SET Username = @Username, Recovery_Question_Id = @Recovery_Question_Id, Recovery_Answer = @Recovery_Answer, email = @Email, first_name = @First_name, last_name = @Last_name  WHERE users.user_id = @User_id", sqlconnection)
        command.Parameters.AddWithValue("@User_id", lblUserid.Text.Trim)
        command.Parameters.AddWithValue("@Username", txtUsername.Text.Trim)
        command.Parameters.AddWithValue("@Recovery_Question_Id", cboResetRecovery.SelectedValue)
        command.Parameters.AddWithValue("@Recovery_Answer", txtRecoveryQuestionAnswer.Text.Trim)
        command.Parameters.AddWithValue("@email", txtEmail.Text.Trim)
        command.Parameters.AddWithValue("@first_name", txtFirst.Text.Trim)
        command.Parameters.AddWithValue("@last_name", txtRecoveryQuestionAnswer.Text.Trim)
        command.ExecuteNonQuery()
        sqlconnection.Close()

        Response.Redirect("Profile.aspx")
    End Sub

    Protected Sub resetValidationPnl()
        pnlCreateAccountValidation.Visible = False
        lblValUserNameAlreadyExists.Visible = False
        lblValPasswordsDoNotMatch.Visible = False
        lblValEmailNotCorrectFormt.Visible = False
        lblValPasswordNotCorrectFormat.Visible = False
        lblNoRecoveryQuestionOrAnswer.Visible = False
        lblvalrecovery.Visible = False
    End Sub

    Protected Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        Response.Redirect("login.aspx?change_password=1")
    End Sub

    Protected Sub cboResetRecovery_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboResetRecovery.SelectedIndexChanged
        lblNewRecovQuestionid.Text = cboResetRecovery.SelectedItem.Text.Trim
    End Sub

    Protected Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Response.Redirect("Homepage.aspx?")
    End Sub
End Class