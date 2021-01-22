Imports System.Data.SqlClient
Public Class WebForm3

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            resetValidationPnl()
            If Not Request.QueryString("change_password") = Nothing Then
                pnlCreateAccount.Visible = False
                PnlLogin.Visible = False
                pnlforgotpassword.Visible = False
                pnlresetPassword.Visible = True
            End If
            If ((Session("User_id") = 3) Or (Session("User_id") = Nothing)) Then

                tblUsernameAndPassword.Visible = True
                btnLogin.Text = "Login"
                btnForgotPassword.Visible = True
                btnCreateAccountLoginpage.Visible = True

                If Not Request.QueryString("anonacc_flag") = Nothing Then

                    If IsNumeric(Request.QueryString("anonacc_flag")) Then
                        If Request.QueryString("anonacc_flag") = 1 Then
                            pnlmakeacc.Visible = True
                            lblvalmakeacc.Visible = True
                        End If

                    End If


                End If
            Else
                lblLogin.Text = "Login Out Or Edit Account"
                btneditAccount.Visible = True
                btnLogin.Text = "Logout"
                btnForgotPassword.Visible = False
                btnCreateAccountLoginpage.Visible = False
                tblUsernameAndPassword.Visible = False
            End If


            Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            Dim sqlconnection As New SqlConnection(connectionString)

            sqlconnection.Open()
            Dim command As New SqlCommand("SELECT [Recovery_Questions_Desc], [Recovery_Question_id] FROM [Recovery_Questions]", sqlconnection)
            Dim reader As SqlDataReader = command.ExecuteReader()

            Dim dt As New DataTable()
            dt.Load(reader)

            'Close the connection
            sqlconnection.Close()

            If dt.Rows.Count > 0 Then
                cboResetRecovery.DataSource = dt
                cboResetRecovery.DataTextField = "Recovery_Questions_Desc"
                cboResetRecovery.DataValueField = "Recovery_Question_id"
                cboResetRecovery.DataBind()
            End If
        End If
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If btnLogin.Text = "Logout" Then
            Session("User_id") = Nothing
            Response.Redirect("homepage.aspx")
        End If


        resetValidationPnl()
        Dim boolerror = False

        If txtUsername.Text.Trim = "" Or txtPassword.Text.Trim = "" Then
            lblValidationUsernameLogin.Visible = True
            pnlvalidation.Visible = True
            lblValidationUsernameLogin.Text = "Please enter in both a username and password."
            boolerror = True
        End If

        If boolerror = True Then
            Exit Sub
        End If

        Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim sqlconnection As New SqlConnection(connectionString)

        sqlconnection.Open()
        Dim command As New SqlCommand("select Users.User_id from Users WHERE users.Username = @Username", sqlconnection)
        command.Parameters.AddWithValue("@Username", txtUsername.Text.Trim)
        Dim reader As SqlDataReader = command.ExecuteReader()

        Dim dt As New DataTable()
        dt.Load(reader)

        'Close the connection
        sqlconnection.Close()

        Dim rows() As DataRow = dt.Select("user_id = user_id")
        If rows.Count > 0 Then
            lblUserID.Text = rows(0).Item("user_id")
        Else
            lblValidationUsernameLogin.Visible = True
            pnlvalidation.Visible = True
            lblValidationUsernameLogin.Text = "Invalid login credentials."
            Exit Sub
        End If


        Dim connectionString2 As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim sqlconnection2 As New SqlConnection(connectionString2)

        sqlconnection2.Open()
        Dim command2 As New SqlCommand("Select Users.Password from Users Where users.username = @username", sqlconnection2)
        command2.Parameters.AddWithValue("@Username", txtUsername.Text.Trim)
        Dim reader2 As SqlDataReader = command2.ExecuteReader()

        Dim dt2 As New DataTable()
        dt2.Load(reader2)

        'Close the connection
        sqlconnection2.Close()

        Dim roww() As DataRow = dt2.Select("Password = Password")
        If roww.Count >= 0 Then
            Dim strPAssword As String = Convert.ToString(roww(0).Item("Password"))
            If strPAssword = txtPassword.Text.Trim Then
                Session("User_ID") = lblUserID.Text.Trim
                Response.Redirect("HomePage.aspx")
            Else
                lblValidationUsernameLogin.Visible = True
                pnlvalidation.Visible = True
                lblValidationUsernameLogin.Text = "Invalid login credentials."

            End If

        Else
            lblValidationUsernameLogin.Visible = True
            pnlvalidation.Visible = True
            lblValidationUsernameLogin.Text = "Invalid login credentials."
        End If

    End Sub

    Protected Sub btnForgotPassword_Click(sender As Object, e As EventArgs) Handles btnForgotPassword.Click
        resetValidationPnl()
        pnlforgotpassword.Visible = True
        PnlLogin.Visible = False
    End Sub

    Protected Sub btnRecoverPassword_Click(sender As Object, e As EventArgs) Handles btnRecoverPassword.Click


        Dim boolerror = False
        Dim strRecoveryAnswer As String

        resetValidationPnl()

        If trRecovery.Visible = False AndAlso (Request.QueryString("change_password") = Nothing) Then
            If txtEmail.Text.Trim = "" Or txtForgotUsername.Text.Trim = "" Then
                lblValidationNoRecoveryQuestion.Visible = True
                pnlvalidation.Visible = True
                lblValidationNoRecoveryQuestion.Text = "Must enter in both an email and a username to recover your account."
                boolerror = True
            End If
        End If

        If trRecovery.Visible = True Then
            If txtEmail.Text.Trim = "" Or txtForgotUsername.Text.Trim = "" Or txtRecoverAnswer.Text.Trim = "" Then
                lblValidationNoRecoveryQuestion.Visible = True
                pnlvalidation.Visible = True
                lblValidationNoRecoveryQuestion.Text = "Must enter in your email, username and the answer to your recovery question to recover your account."
                boolerror = True
            End If
        End If

        If boolerror = True Then
            Exit Sub
        End If

        If trRecovery.Visible = False Then

            Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            Dim sqlconnection As New SqlConnection(connectionString)

            sqlconnection.Open()
            Dim command As New SqlCommand("select Users.User_id from Users WHERE users.Username = @Username and users.email = @email", sqlconnection)
            command.Parameters.AddWithValue("@Username", txtForgotUsername.Text.Trim)
            command.Parameters.AddWithValue("@email", txtEmail.Text.Trim)
            Dim reader As SqlDataReader = command.ExecuteReader()

            Dim dt As New DataTable()
            dt.Load(reader)

            'Close the connection
            sqlconnection.Close()

            If dt.Rows.Count > 0 Then
                'Dim connectionString2 As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                'Dim sqlconnection2 As New SqlConnection(connectionString2)

                sqlconnection.Open()
                Dim command2 As New SqlCommand("select Recovery_Questions.Recovery_Questions_desc, Users.Recovery_Answer from Recovery_Questions inner join Users on Users.Recovery_Question_ID = Recovery_Questions.Recovery_Question_ID WHERE users.Username = @Username and users.email = @email", sqlconnection)
                command2.Parameters.AddWithValue("@Username", txtForgotUsername.Text.Trim)
                command2.Parameters.AddWithValue("@email", txtEmail.Text.Trim)
                Dim reader2 As SqlDataReader = command2.ExecuteReader()

                Dim dt2 As New DataTable()
                dt2.Load(reader2)

                'Close the connection
                sqlconnection.Close()

                lblRecoveryQuestion.Text = dt2.Rows(0).Item("Recovery_Questions_desc")
                strRecoveryAnswer = dt2.Rows(0).Item("Recovery_Answer")
            Else
                lblValidationNoRecoveryQuestion.Visible = True
                pnlvalidation.Visible = True
                lblValidationNoRecoveryQuestion.Text = "No Recovery Question was able to be retrieved with the given Username and Email. Please try again."
                Exit Sub
            End If

            If lblRecoveryQuestion.Text.Trim = "" Or lblRecoveryQuestion.Text.Trim = Nothing Then
                trRecovery.Visible = False
                lblValidationNoRecoveryQuestion.Visible = True
                pnlvalidation.Visible = True
                lblValidationNoRecoveryQuestion.Text = "No Recovery Question was able to be retrieved with the given Username and Email. Please try again."
                Exit Sub
            Else
                trRecovery.Visible = True
            End If
        Else

            Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            Dim sqlconnection As New SqlConnection(connectionString)

            sqlconnection.Open()
            Dim command As New SqlCommand("select Users.User_id from Users WHERE users.Username = @Username and users.email = @email", sqlconnection)
            command.Parameters.AddWithValue("@Username", txtForgotUsername.Text.Trim)
            command.Parameters.AddWithValue("@email", txtEmail.Text.Trim)
            Dim reader As SqlDataReader = command.ExecuteReader()

            Dim dt As New DataTable()
            dt.Load(reader)

            'Close the connection
            sqlconnection.Close()

            If dt.Rows.Count > 0 Then
                lblUserID.Text = dt.Rows(0).Item("User_id")
                Dim connectionString2 As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                Dim sqlconnection2 As New SqlConnection(connectionString2)

                sqlconnection2.Open()
                Dim command2 As New SqlCommand("select Recovery_Questions.Recovery_Questions_Desc, Users.Recovery_Answer from Recovery_Questions join Users on Users.Recovery_Question_ID = Recovery_Questions.Recovery_Question_id WHERE Users.Username = @Username and Users.email = @email", sqlconnection2)
                command2.Parameters.AddWithValue("@Username", txtForgotUsername.Text.Trim)
                command2.Parameters.AddWithValue("@email", txtEmail.Text.Trim)
                Dim reader2 As SqlDataReader = command2.ExecuteReader()

                Dim dt2 As New DataTable()
                dt2.Load(reader2)

                'Close the connection
                sqlconnection2.Close()

                Dim rows() As DataRow = dt2.Select("Recovery_Questions_Desc = Recovery_Questions_Desc")
                Dim rowss() As DataRow = dt2.Select("Recovery_Answer = Recovery_Answer")
                If rows.Count > 0 Then
                    lblRecoveryQuestion.Text = rows(0).Item(0)
                    strRecoveryAnswer = rowss(0).Item("Recovery_Answer")
                Else
                    lblValidationNoRecoveryQuestion.Visible = True
                    pnlvalidation.Visible = True
                    lblValidationNoRecoveryQuestion.Text = "No Recovery Question was able to be retrieved with the given Username and Email. Please try again."
                    Exit Sub
                End If

                If strRecoveryAnswer = txtRecoverAnswer.Text.Trim Then
                    pnlresetPassword.Visible = True
                    pnlforgotpassword.Visible = False
                    PnlLogin.Visible = False
                End If
            End If
        End If

    End Sub

    Protected Sub btnSubmitPasswordReset_Click(sender As Object, e As EventArgs) Handles btnSubmitPasswordReset.Click
        resetValidationPnl()
        Dim boolerror = False

        If txtResetPassword1.Text = "" Or txtResetPassword2.Text = "" Then
            lblValidationResetPassword.Visible = True
            lblValidationResetPassword.Text = "Must enter values for both fields to reset your password."
            boolerror = True
            pnlvalidation.Visible = True
        Else
            If txtResetPassword1.Text <> txtResetPassword2.Text Then
                lblValidationResetPassword.Visible = True
                lblValidationResetPassword.Text = "The passwords you have enetered do not match."
                boolerror = True
                pnlvalidation.Visible = True
                Exit Sub
            End If
            If ValidatePassword(txtResetPassword1.Text.Trim) = False Then
                lblValidationResetPasswordLength.Visible = True
                lblValidationResetPasswordLength.Text = "New password must be atleast 8 characters in length and contain a special character and atleast one capitalized letter, as well as one lower case letter."
                boolerror = True
                pnlvalidation.Visible = True
                Exit Sub
            End If
        End If

        If boolerror = True Then
            Exit Sub
        End If

        'Update Users SET Password = @Password WHERE users.user_id = @User_id
        Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim sqlconnection As New SqlConnection(connectionString)

        sqlconnection.Open()
        Dim command As New SqlCommand("Update Users SET Password = @Password WHERE users.user_id = @User_id", sqlconnection)
        If Not Request.QueryString("change_password") = Nothing Then
            command.Parameters.AddWithValue("@User_id", Session("User_id"))

        Else
            command.Parameters.AddWithValue("@User_id", lblUserID.Text.Trim)
        End If
        command.Parameters.AddWithValue("@Password", txtResetPassword1.Text.Trim)
        command.ExecuteNonQuery()
        sqlconnection.Close()

        If Request.QueryString("change_password") = Nothing Then
            Session("user_id") = lblUserID.Text.Trim
        End If

        Response.Redirect("homepage.aspx")

    End Sub

    Protected Sub resetValidationPnl()
        pnlvalidation.Visible = False
        pnlmakeacc.Visible = False
        lblvalmakeacc.Visible = False
        pnlCreateAccountValidation.Visible = False
        [lblValidationUsernameLogin].Visible = False
        [lblValidationPasswordLogin].Visible = False
        [lblValidationLoginFail].Visible = False
        [lblValidationNoRecoveryQuestion].Visible = False
        [lblValidationRecoveryAnswerWrong].Visible = False
        lblValidationResetPassword.Visible = False
        lblValidationResetPasswordLength.Visible = False

        lblValUserNameAlreadyExists.Visible = False
        lblValPasswordsDoNotMatch.Visible = False
        lblValEmailNotCorrectFormt.Visible = False
        lblValPasswordNotCorrectFormat.Visible = False
        lblnoRecoveryQuestionOrAnswer.Visible = False

    End Sub

    Function ValidatePassword(ByVal pwd As String,
    Optional ByVal minLength As Integer = 8,
    Optional ByVal numUpper As Integer = 1,
    Optional ByVal numLower As Integer = 1,
    Optional ByVal numNumbers As Integer = 1,
    Optional ByVal numSpecial As Integer = 1) As Boolean

        Dim upper As New System.Text.RegularExpressions.Regex("[A-Z]")
        Dim lower As New System.Text.RegularExpressions.Regex("[a-z]")
        Dim number As New System.Text.RegularExpressions.Regex("[0-9]")
        Dim special As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")

        If Len(pwd) < minLength Then Return False
        If upper.Matches(pwd).Count < numUpper Then Return False
        If lower.Matches(pwd).Count < numLower Then Return False
        If number.Matches(pwd).Count < numNumbers Then Return False
        If special.Matches(pwd).Count < numSpecial Then Return False

        ' Passed all checks.
        Return True
    End Function

    Protected Sub BtnCreateAccount_Click(sender As Object, e As EventArgs) Handles BtnCreateAccount.Click
        resetValidationPnl()
        Dim boolerror As Boolean = False

        If txtBoxCreateUername.Text.Trim = "" Then
            lblUsernameBlank.Visible = True
            lblUsernameBlank.Text = "Must enter a username to create the account."
            pnlCreateAccountValidation.Visible = True
            boolerror = True
        End If

        If txtboXCreatePassword.Text.Trim = "" Then
            pnlCreateAccountValidation.Visible = True
            boolerror = True
            lblValPasswordNotCorrectFormat.Visible = True
            lblValPasswordNotCorrectFormat.Text = "Must enter values for both password fields."
        End If

        If txtboXCreatePassword2.Text.Trim = "" Then
            pnlCreateAccountValidation.Visible = True
            boolerror = True
            lblValPasswordNotCorrectFormat.Visible = True
            lblValPasswordNotCorrectFormat.Text = "Must enter values for both password fields."
        End If

        If txtCreateEmail.Text.Trim = "" Then
            pnlCreateAccountValidation.Visible = True
            boolerror = True
            lblValEmailNotCorrectFormt.Visible = True
            lblValEmailNotCorrectFormt.Text = "Must enter an email address."
        End If

        If txtboXCreatePassword.Text.Trim <> "" AndAlso txtboXCreatePassword2.Text <> "" Then
            If ValidatePassword(txtboXCreatePassword.Text.Trim) = False Or ValidatePassword(txtboXCreatePassword2.Text.Trim) = False Then
                pnlCreateAccountValidation.Visible = True
                boolerror = True
                lblValPasswordNotCorrectFormat.Visible = True
                lblValPasswordNotCorrectFormat.Text = "New password must be atleast 8 characters in length and contain a special character and atleast one capitalized letter, as well as one lower case letter."
            End If
            If txtboXCreatePassword.Text.Trim <> txtboXCreatePassword2.Text Then
                pnlCreateAccountValidation.Visible = True
                boolerror = True
                lblValPasswordsDoNotMatch.Visible = True
                lblValPasswordsDoNotMatch.Text = "The passwords you have enetered do not match."
            End If
        End If

        If cboResetRecovery.SelectedItem.Text.Trim = "" Or txtRecoveryQuestionAnswer.Text = "" Then
            pnlCreateAccountValidation.Visible = True
            lblnoRecoveryQuestionOrAnswer.Visible = True
            lblnoRecoveryQuestionOrAnswer.Text = "Must enter both a recovery question and an answer to create an account."
            boolerror = True
        End If


        If txtCreateEmail.Text.Trim <> "" Then
            If IsValidEmailFormat(txtCreateEmail.Text.Trim) = False Then
                pnlCreateAccountValidation.Visible = True
                boolerror = True
                lblValEmailNotCorrectFormt.Visible = True
                lblValEmailNotCorrectFormt.Text = "Email address does not seem to be valid."
            End If
        End If

        If boolerror = True Then
            Exit Sub
        End If

        'Insert into [Users] (Username, Recovery_question_id, recovery_answer, email, password, first_name, last_name) Values (@Username, @Recovery_question_id, @recovery_answer, @email, @password,  @first_name,  @last_name)

        Dim connectionString As String = "Server=tcp:oldschoolcool.database.windows.net,1433;Initial Catalog=OldSchoolCool;Persist Security Info=False;User ID=teeray22;Password=Teeray32!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        Dim sqlconnection As New SqlConnection(connectionString)

        sqlconnection.Open()
        Dim command As New SqlCommand("Insert into [Users] (Username, Recovery_question_id, recovery_answer, email, password, first_name, last_name, score) Values (@Username, @Recovery_question_id, @recovery_answer, @email, @password,  @first_name,  @last_name, @score)", sqlconnection)
        command.Parameters.AddWithValue("@Username", txtBoxCreateUername.Text.Trim)
        command.Parameters.AddWithValue("@Recovery_question_id", cboResetRecovery.SelectedValue)
        command.Parameters.AddWithValue("@recovery_answer", txtRecoveryQuestionAnswer.Text.Trim)
        command.Parameters.AddWithValue("@email", txtCreateEmail.Text.Trim)
        command.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim)
        command.Parameters.AddWithValue("@last_name", txtLastName.Text.Trim)
        command.Parameters.AddWithValue("@password", txtboXCreatePassword.Text.Trim)
        command.Parameters.AddWithValue("@score", 0)
        command.ExecuteNonQuery()
        sqlconnection.Close()

        sqlconnection.Open()
        Dim command_new_user_id As New SqlCommand("select Users.User_id from Users WHERE users.Username = @Username", sqlconnection)
        command_new_user_id.Parameters.AddWithValue("@Username", txtboXCreatePassword.Text.Trim)
        Dim reader As SqlDataReader = command_new_user_id.ExecuteReader()

        Dim dt As New DataTable()
        dt.Load(reader)

        'Close the connection
        sqlconnection.Close()

        Dim rows() As DataRow = dt.Select("user_id = user_id")
        If rows.Count > 0 Then
            lblUserID.Text = rows(0).Item("user_id")
            Session("User_id") = lblUserID.Text.Trim
        Else
            Response.Redirect("login.aspx")
        End If

        Response.Redirect("homepage.aspx")


    End Sub

    Function IsValidEmailFormat(ByVal s As String) As Boolean
        Return Regex.IsMatch(s, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
    End Function

    Private Sub btnCreateAccountLoginpage_Click(sender As Object, e As EventArgs) Handles btnCreateAccountLoginpage.Click

        resetValidationPnl()
        PnlLogin.Visible = False
        pnlCreateAccount.Visible = True
    End Sub

    Protected Sub btnCancelcreateaccount_Click(sender As Object, e As EventArgs) Handles btnCancelcreateaccount.Click
        resetValidationPnl()
        PnlLogin.Visible = True
        pnlCreateAccount.Visible = False
    End Sub

    Protected Sub btnCancelAccountRecover_Click(sender As Object, e As EventArgs) Handles btnCancelAccountRecover.Click
        resetValidationPnl()
        pnlforgotpassword.Visible = False
        PnlLogin.Visible = True
    End Sub

    Protected Sub btnCancelPasswordReset_Click(sender As Object, e As EventArgs) Handles btnCancelPasswordReset.Click
        resetValidationPnl()
        pnlresetPassword.Visible = False
        PnlLogin.Visible = True
    End Sub

    Protected Sub btneditAccount_Click(sender As Object, e As EventArgs) Handles btneditAccount.Click
        Response.Redirect("EditAccount.aspx?")
    End Sub


End Class