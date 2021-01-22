Public Class WebCommonLib

    Public Function GetRank(strScore As String) As String
        Dim lbluserRank As String = "Noob"
        If IsNumeric(strScore) Then
            If strScore <> "0" AndAlso strScore <> Nothing Then

                If (Convert.ToInt32(strScore)) < 100 Then
                    lbluserRank = "noob"
                ElseIf (Convert.ToInt32(strScore)) >= 100 AndAlso (Convert.ToInt32(strScore)) < 250 Then
                    lbluserRank = "Intermediate User"
                ElseIf (Convert.ToInt32(strScore)) >= 250 AndAlso (Convert.ToInt32(strScore)) < 500 Then
                    lbluserRank = "Bronze User"
                ElseIf (Convert.ToInt32(strScore)) >= 500 AndAlso (Convert.ToInt32(strScore)) < 1500 Then
                    lbluserRank = "Experienced User"
                ElseIf (Convert.ToInt32(strScore)) >= 1500 AndAlso (Convert.ToInt32(strScore)) < 5000 Then
                    lbluserRank = "VIP User"
                ElseIf (Convert.ToInt32(strScore)) >= 5000 AndAlso (Convert.ToInt32(strScore)) < 50000 Then
                    lbluserRank = "Veteran User"
                ElseIf (Convert.ToInt32(strScore)) >= 50000 AndAlso (Convert.ToInt32(strScore)) < 10000000000 Then
                    lbluserRank = "Gold Member"
                End If

            Else
                lbluserRank = "Noob"

            End If
        End If
        Return lbluserRank

    End Function

    Public Function IsValidEmailFormat(ByVal s As String) As Boolean
        Return Regex.IsMatch(s, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
    End Function

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

    Function impScoreComment(ByVal strscore As Integer) As Integer
        Dim score As Integer
        Dim newscore As Integer

        If score < 100 Then
            newscore = score + 15
        End If
        If score > 100 And score < 200 Then
            newscore = score + 25
        End If
        If score > 200 And score < 500 Then
            newscore = score + 55
        End If
        If score > 500 And score < 1000 Then
            newscore = score + 75
        End If
        If score > 1000 Then
            newscore = score + 110
        End If
        If score > 5000 Then
            newscore = score + 240
        End If
        Return newscore
    End Function

    Function impScorePost(ByVal strscore As Integer) As Integer
        Dim score As Integer
        Dim newscore As Integer

        If score < 100 Then
            newscore = score + 30
        End If
        If score > 100 And score < 200 Then
            newscore = score + 50
        End If
        If score > 200 And score < 500 Then
            newscore = score + 110
        End If
        If score > 500 And score < 1000 Then
            newscore = score + 150
        End If
        If score > 1000 Then
            newscore = score + 220
        End If
        If score > 5000 Then
            newscore = score + 240
        End If
        Return newscore
    End Function

End Class