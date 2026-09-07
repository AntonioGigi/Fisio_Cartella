Imports System.Linq

Public Module PasswordPolicy
    Public Function Validate(password As String, username As String, ByRef message As String) As Boolean
        message = Nothing

        If String.IsNullOrEmpty(password) Then
            message = "La password è obbligatoria."
            Return False
        End If

        If password.Length < 12 Then
            message = "La password deve contenere almeno 12 caratteri."
            Return False
        End If

        If password.Length > 128 Then
            message = "La password non può superare 128 caratteri."
            Return False
        End If

        If password.Any(Function(ch) Char.IsWhiteSpace(ch) OrElse Char.IsControl(ch)) Then
            message = "La password non può contenere spazi o caratteri di controllo."
            Return False
        End If

        If Not password.Any(AddressOf Char.IsUpper) Then
            message = "La password deve contenere almeno una lettera maiuscola."
            Return False
        End If

        If Not password.Any(AddressOf Char.IsLower) Then
            message = "La password deve contenere almeno una lettera minuscola."
            Return False
        End If

        If Not password.Any(AddressOf Char.IsDigit) Then
            message = "La password deve contenere almeno un numero."
            Return False
        End If

        If Not password.Any(Function(ch) Not Char.IsLetterOrDigit(ch)) Then
            message = "La password deve contenere almeno un carattere speciale."
            Return False
        End If

        If Not String.IsNullOrWhiteSpace(username) AndAlso password.IndexOf(username.Trim(), StringComparison.OrdinalIgnoreCase) >= 0 Then
            message = "La password non può contenere lo username."
            Return False
        End If

        Return True
    End Function

    Public Function RequirementsText() As String
        Return "La password deve avere almeno 12 caratteri, una maiuscola, una minuscola, un numero e un carattere speciale, senza spazi e senza contenere lo username."
    End Function
End Module
