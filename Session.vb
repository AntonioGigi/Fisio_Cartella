Public Module Session
    Public Property CurrentUser As String = Nothing
    Public Property CurrentUserRole As String = Nothing

    Public Function IsAuthenticated() As Boolean
        Return Not String.IsNullOrEmpty(CurrentUser)
    End Function

    Public Event DataChanged()

    Public Sub NotifyDataChanged()
        Try
            RaiseEvent DataChanged()
        Catch ex As Exception
        End Try
    End Sub
End Module

