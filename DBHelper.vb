Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data.SQLite

Public Class DBHelper
    Public Shared LastError As String = Nothing
    Public Shared ReadOnly Property DbPath As String
        Get
            Return Path.Combine(Application.StartupPath, "clinic.db")
        End Get
    End Property

    Public Shared ReadOnly Property ConnectionString As String
        Get
            Return $"Data Source={DbPath};Version=3;"
        End Get
    End Property

    Public Shared Sub InitializeDatabase()
        Try
            If Not File.Exists(DbPath) Then
                SQLiteConnection.CreateFile(DbPath)
            End If

            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    ' Users
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY AUTOINCREMENT, Username TEXT UNIQUE NOT NULL, PasswordHash TEXT NOT NULL, Role TEXT);"
                    cmd.ExecuteNonQuery()
                    ' Patients
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Patients (Id INTEGER PRIMARY KEY AUTOINCREMENT, FirstName TEXT, LastName TEXT, CodiceFiscale TEXT, Contacts TEXT, Anamnesis TEXT);"
                    cmd.ExecuteNonQuery()
                    ' ClinicalRecords
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS ClinicalRecords (Id INTEGER PRIMARY KEY AUTOINCREMENT, PatientId INTEGER, DateRecorded TEXT, Diagnosis TEXT, Objectives TEXT, Notes TEXT, FOREIGN KEY(PatientId) REFERENCES Patients(Id));"
                    cmd.ExecuteNonQuery()
                    ' Treatments
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Treatments (Id INTEGER PRIMARY KEY AUTOINCREMENT, PatientId INTEGER, TreatmentDate TEXT, Notes TEXT, Progress TEXT, FOREIGN KEY(PatientId) REFERENCES Patients(Id));"
                    cmd.ExecuteNonQuery()
                    ' Appointments
                    ' Appointments (aggiunto campo Price)
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Appointments (Id INTEGER PRIMARY KEY AUTOINCREMENT, PatientId INTEGER, StartDate TEXT, EndDate TEXT, Price REAL DEFAULT 0, Notes TEXT, FOREIGN KEY(PatientId) REFERENCES Patients(Id));"
                    cmd.ExecuteNonQuery()
                    ' Ensure new columns for payment mode, service type, price and paid exist (safe ALTER)
                    Try
                        cmd.CommandText = "ALTER TABLE Appointments ADD COLUMN PaymentMode TEXT DEFAULT ''"
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                    Try
                        cmd.CommandText = "ALTER TABLE Appointments ADD COLUMN ServiceType TEXT DEFAULT ''"
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                    Try
                        cmd.CommandText = "ALTER TABLE Appointments ADD COLUMN Price REAL DEFAULT 0"
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                    Try
                        cmd.CommandText = "ALTER TABLE Appointments ADD COLUMN Paid INTEGER DEFAULT 0"
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                    ' Sessions (sedute)
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Sessions (Id INTEGER PRIMARY KEY AUTOINCREMENT, PatientId INTEGER NOT NULL, SessionDate TEXT NOT NULL, DurationMinutes INTEGER, Therapist TEXT, Price REAL DEFAULT 0, Notes TEXT, FOREIGN KEY(PatientId) REFERENCES Patients(Id));"
                    cmd.ExecuteNonQuery()
                    ' Invoices
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Invoices (Id INTEGER PRIMARY KEY AUTOINCREMENT, PatientId INTEGER, IssueDate TEXT, Amount REAL, Paid INTEGER DEFAULT 0, Notes TEXT, FOREIGN KEY(PatientId) REFERENCES Patients(Id));"
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            ' Do not create default admin automatically. Allow first registration to create admin if desired.
        Catch ex As Exception
            ' Non interrompere l'applicazione per errori di creazione DB
        End Try
    End Sub

    Public Shared Sub UpdatePatientAnamnesis(id As Integer, anamnesis As String)
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "UPDATE Patients SET Anamnesis = @a WHERE Id = @id"
                    cmd.Parameters.AddWithValue("@a", anamnesis)
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
        End Try
    End Sub

    ' --- Sessions (dettaglio sedute cliniche) ---
    Public Shared Sub InsertSession(patientId As Integer, sessionDate As DateTime, durationMinutes As Integer, therapist As String, price As Decimal, notes As String)
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "INSERT INTO Sessions (PatientId, SessionDate, DurationMinutes, Therapist, Price, Notes) VALUES (@pid, @dt, @dur, @ther, @price, @notes)"
                    cmd.Parameters.AddWithValue("@pid", patientId)
                    cmd.Parameters.AddWithValue("@dt", sessionDate.ToString("s"))
                    cmd.Parameters.AddWithValue("@dur", durationMinutes)
                    cmd.Parameters.AddWithValue("@ther", therapist)
                    cmd.Parameters.AddWithValue("@price", Convert.ToDouble(price))
                    cmd.Parameters.AddWithValue("@notes", notes)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
        ' Notify listeners about data change
        Try
            Session.NotifyDataChanged()
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function GetEarningsByMonth() As DataTable
        Dim dt As New DataTable()
        LastError = Nothing
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    ' Aggregate only paid appointments; sessions are included separately below.
                    cmd.CommandText = "SELECT substr(StartDate,1,7) AS Month, SUM(CAST(COALESCE(Price,0) AS REAL)) AS Total FROM Appointments WHERE COALESCE(Paid,0)=1 GROUP BY substr(StartDate,1,7) ORDER BY Month DESC"
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "SELECT substr(SessionDate,1,7) AS Month, SUM(CAST(COALESCE(Price,0) AS REAL)) AS Total FROM Sessions GROUP BY substr(SessionDate,1,7)"
                    Dim sessionTotals As New DataTable()
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(sessionTotals)
                    End Using
                    For Each sessionRow As DataRow In sessionTotals.Rows
                        Dim existing = dt.Select($"Month = '{sessionRow("Month").ToString().Replace("'", "''")}'")
                        If existing.Length > 0 Then
                            existing(0)("Total") = Convert.ToDecimal(existing(0)("Total")) + Convert.ToDecimal(sessionRow("Total"))
                        Else
                            Dim newRow = dt.NewRow()
                            newRow("Month") = sessionRow("Month")
                            newRow("Total") = sessionRow("Total")
                            dt.Rows.Add(newRow)
                        End If
                    Next
                End Using
            End Using
            Dim currentMonth = DateTime.Now.ToString("yyyy-MM")
            Dim currentMonthRows = dt.Select($"Month = '{currentMonth}'")
            If currentMonthRows.Length = 0 Then
                Dim currentRow = dt.NewRow()
                currentRow("Month") = currentMonth
                currentRow("Total") = 0.0R
                dt.Rows.Add(currentRow)
            End If
        Catch ex As Exception
            LastError = ex.ToString()
        End Try
        Return dt
    End Function

    Public Shared Function GetEventDatesBetween(startDate As DateTime, endDate As DateTime) As List(Of DateTime)
        Dim results As New List(Of DateTime)()
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "SELECT DISTINCT substr(StartDate,1,10) AS d FROM Appointments WHERE StartDate >= @s AND StartDate < @e UNION SELECT DISTINCT substr(TreatmentDate,1,10) AS d FROM Treatments WHERE TreatmentDate >= @s AND TreatmentDate < @e"
                    cmd.Parameters.AddWithValue("@s", startDate.ToString("s"))
                    cmd.Parameters.AddWithValue("@e", endDate.ToString("s"))
                    Using rdr = cmd.ExecuteReader()
                        While rdr.Read()
                            Dim s = rdr.GetString(0)
                            Dim dt As DateTime
                            If DateTime.TryParse(s, dt) Then
                                results.Add(dt.Date)
                            Else
                                ' try parse yyyy-MM-dd
                                Try
                                    dt = DateTime.ParseExact(s, "yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture)
                                    results.Add(dt.Date)
                                Catch ex As Exception
                                End Try
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return results
    End Function

    Public Shared Function GetAllServices() As DataTable
        Dim dt As New DataTable()
        LastError = Nothing
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "SELECT a.Id, 'Appointment' AS Type, substr(a.StartDate,1,19) AS Date, COALESCE(p.FirstName,'') || ' ' || COALESCE(p.LastName,'') AS PatientName, CAST(COALESCE(a.Price,0) AS REAL) AS Price, COALESCE(a.Paid,0) AS Paid, COALESCE(a.ServiceType,'') AS ServiceType FROM Appointments a LEFT JOIN Patients p ON a.PatientId = p.Id UNION ALL SELECT s.Id, 'Session' AS Type, substr(s.SessionDate,1,19) AS Date, COALESCE(p.FirstName,'') || ' ' || COALESCE(p.LastName,'') AS PatientName, CAST(COALESCE(s.Price,0) AS REAL) AS Price, 1 AS Paid, '' AS ServiceType FROM Sessions s LEFT JOIN Patients p ON s.PatientId = p.Id ORDER BY Date DESC"
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            LastError = ex.ToString()
        End Try
        Return dt
    End Function

    Public Shared Function GetSessionsByPatient(patientId As Integer) As DataTable
        Dim dt As New DataTable()
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "SELECT Id, SessionDate, DurationMinutes, Therapist, Price, Notes FROM Sessions WHERE PatientId = @pid ORDER BY SessionDate DESC"
                    cmd.Parameters.AddWithValue("@pid", patientId)
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    Public Shared Function GetClinicalRecordsByPatient(patientId As Integer) As DataTable
        Dim dt As New DataTable()
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "SELECT Id, DateRecorded, Diagnosis, Objectives, Notes FROM ClinicalRecords WHERE PatientId = @pid ORDER BY DateRecorded DESC"
                    cmd.Parameters.AddWithValue("@pid", patientId)
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    Public Shared Sub DeleteTreatment(id As Integer)
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "DELETE FROM Treatments WHERE Id = @id"
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
        Try
            Session.NotifyDataChanged()
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function GetUserCount() As Integer
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "SELECT COUNT(1) FROM Users"
                    Dim obj = cmd.ExecuteScalar()
                    If obj IsNot Nothing Then
                        Return Convert.ToInt32(obj)
                    End If
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return 0
    End Function

    Public Shared Function GetUserHash(username As String) As String
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "SELECT PasswordHash FROM Users WHERE Username = @u LIMIT 1"
                    cmd.Parameters.AddWithValue("@u", username)
                    Dim obj = cmd.ExecuteScalar()
                    If obj IsNot Nothing Then Return obj.ToString()
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

    Public Shared Function CreateUser(username As String, password As String, role As String) As Boolean
        Dim validationMessage As String = Nothing
        If Not PasswordPolicy.Validate(password, username, validationMessage) Then
            LastError = validationMessage
            Return False
        End If
        Dim hash = HashPassword(password)
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "INSERT OR IGNORE INTO Users (Username, PasswordHash, Role) VALUES (@u, @p, @r)"
                    cmd.Parameters.AddWithValue("@u", username)
                    cmd.Parameters.AddWithValue("@p", hash)
                    cmd.Parameters.AddWithValue("@r", role)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            LastError = Nothing
            Return True
        Catch ex As Exception
            LastError = ex.Message
            Return False
        End Try
    End Function

    Public Shared Function ListUsers() As DataTable
        Dim dt As New DataTable()
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "SELECT Id, Username, Role FROM Users ORDER BY Username"
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    Public Shared Function GetUserRole(username As String) As String
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "SELECT Role FROM Users WHERE Username = @u LIMIT 1"
                    cmd.Parameters.AddWithValue("@u", username)
                    Dim obj = cmd.ExecuteScalar()
                    If obj IsNot Nothing Then Return obj.ToString()
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

    ' --- Treatments (sedute) ---
    Public Shared Sub InsertTreatment(patientId As Integer, treatmentDate As DateTime, notes As String, progress As String)
        LastError = Nothing
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "INSERT INTO Treatments (PatientId, TreatmentDate, Notes, Progress) VALUES (@pid, @tdate, @notes, @prog)"
                    cmd.Parameters.AddWithValue("@pid", patientId)
                    cmd.Parameters.AddWithValue("@tdate", treatmentDate.ToString("s"))
                    cmd.Parameters.AddWithValue("@notes", notes)
                    cmd.Parameters.AddWithValue("@prog", progress)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            LastError = ex.ToString()
        End Try
        ' Notify listeners about data change only if no error
        If String.IsNullOrEmpty(LastError) Then
            Try
                Session.NotifyDataChanged()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Shared Function GetTreatmentsByPatient(patientId As Integer) As DataTable
        Dim dt As New DataTable()
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "SELECT Id, TreatmentDate, Notes, Progress FROM Treatments WHERE PatientId = @pid ORDER BY TreatmentDate DESC"
                    cmd.Parameters.AddWithValue("@pid", patientId)
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    ' --- Appointments ---
    Public Shared Sub InsertAppointment(patientId As Integer, startDate As DateTime, endDate As DateTime, price As Decimal, notes As String, Optional paymentMode As String = "", Optional serviceType As String = "")
        LastError = Nothing
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "INSERT INTO Appointments (PatientId, StartDate, EndDate, Price, Notes, PaymentMode, ServiceType) VALUES (@pid, @s, @e, @price, @notes, @pmode, @stype)"
                    cmd.Parameters.AddWithValue("@pid", patientId)
                    cmd.Parameters.AddWithValue("@s", startDate.ToString("s"))
                    cmd.Parameters.AddWithValue("@e", endDate.ToString("s"))
                    cmd.Parameters.AddWithValue("@price", Convert.ToDouble(price))
                    cmd.Parameters.AddWithValue("@notes", notes)
                    cmd.Parameters.AddWithValue("@pmode", paymentMode)
                    cmd.Parameters.AddWithValue("@stype", serviceType)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            LastError = ex.ToString()
        End Try
        If String.IsNullOrEmpty(LastError) Then
            Try
                Session.NotifyDataChanged()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Shared Function GetAppointmentsByDate(dateOnly As DateTime) As DataTable
        Dim dt As New DataTable()
        Try
            Dim startDay = New DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day, 0, 0, 0)
            Dim endDay = startDay.AddDays(1)
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "SELECT a.Id, a.PatientId, COALESCE(p.FirstName, '') || ' ' || COALESCE(p.LastName, '') AS PatientName, a.StartDate, a.EndDate, COALESCE(a.Price,0) AS Price, a.Notes, COALESCE(a.PaymentMode, '') AS PaymentMode, COALESCE(a.ServiceType, '') AS ServiceType, COALESCE(a.Paid,0) AS Paid, 'Appointment' AS Type FROM Appointments a LEFT JOIN Patients p ON a.PatientId = p.Id WHERE StartDate >= @s AND StartDate < @e ORDER BY StartDate"
                    cmd.Parameters.AddWithValue("@s", startDay.ToString("s"))
                    cmd.Parameters.AddWithValue("@e", endDay.ToString("s"))
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    Public Shared Function GetTreatmentsByDate(dateOnly As DateTime) As DataTable
        Dim dt As New DataTable()
        Try
            Dim startDay = New DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day, 0, 0, 0)
            Dim endDay = startDay.AddDays(1)
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    ' Return treatments with similar schema to appointments so they can be merged in calendar
                    cmd.CommandText = "SELECT t.Id, t.PatientId, COALESCE(p.FirstName, '') || ' ' || COALESCE(p.LastName, '') AS PatientName, t.TreatmentDate AS StartDate, t.TreatmentDate AS EndDate, 0 AS Price, t.Notes, 'Treatment' AS Type FROM Treatments t LEFT JOIN Patients p ON t.PatientId = p.Id WHERE TreatmentDate >= @s AND TreatmentDate < @e ORDER BY TreatmentDate"
                    cmd.Parameters.AddWithValue("@s", startDay.ToString("s"))
                    cmd.Parameters.AddWithValue("@e", endDay.ToString("s"))
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    Public Shared Sub DeleteAppointment(id As Integer)
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "DELETE FROM Appointments WHERE Id = @id"
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
        Try
            Session.NotifyDataChanged()
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub UpdateAppointmentPaid(id As Integer, paid As Boolean)
        LastError = Nothing
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "UPDATE Appointments SET Paid = @p WHERE Id = @id"
                    cmd.Parameters.AddWithValue("@p", If(paid, 1, 0))
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            LastError = ex.ToString()
        End Try
        Try
            Session.NotifyDataChanged()
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function ChangePassword(username As String, newPassword As String) As Boolean
        Dim validationMessage As String = Nothing
        If Not PasswordPolicy.Validate(newPassword, username, validationMessage) Then
            LastError = validationMessage
            Return False
        End If
        Dim hash = HashPassword(newPassword)
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "UPDATE Users SET PasswordHash = @p WHERE Username = @u"
                    cmd.Parameters.AddWithValue("@p", hash)
                    cmd.Parameters.AddWithValue("@u", username)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            LastError = Nothing
            Return True
        Catch ex As Exception
            LastError = ex.Message
            Return False
        End Try
    End Function

    Public Shared Sub UpdateUserRole(username As String, role As String)
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "UPDATE Users SET Role = @r WHERE Username = @u"
                    cmd.Parameters.AddWithValue("@r", role)
                    cmd.Parameters.AddWithValue("@u", username)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub DeleteUser(username As String)
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "DELETE FROM Users WHERE Username = @u"
                    cmd.Parameters.AddWithValue("@u", username)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function VerifyUser(username As String, password As String) As Boolean
        Dim stored = GetUserHash(username)
        If String.IsNullOrEmpty(stored) Then Return False
        Return VerifyPassword(stored, password)
    End Function

    ' --- Password helper (PBKDF2 SHA256) ---
    Private Shared Function HashPassword(password As String) As String
        Dim iterations As Integer = 100000
        Dim salt(15) As Byte
        Using rng = RandomNumberGenerator.Create()
            rng.GetBytes(salt)
        End Using
        Dim hash As Byte()
        Using derive = New Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256)
            hash = derive.GetBytes(32)
        End Using
        Return String.Format("{0}:{1}:{2}", iterations, Convert.ToBase64String(salt), Convert.ToBase64String(hash))
    End Function

    Private Shared Function VerifyPassword(stored As String, password As String) As Boolean
        Try
            Dim parts = stored.Split(CChar(":"c))
            If parts.Length <> 3 Then Return False
            Dim iterations = Integer.Parse(parts(0))
            Dim salt = Convert.FromBase64String(parts(1))
            Dim storedHash = Convert.FromBase64String(parts(2))
            Dim derived As Byte()
            Using derive = New Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256)
                derived = derive.GetBytes(storedHash.Length)
            End Using
            If derived.Length <> storedHash.Length Then Return False
            Dim equal As Boolean = True
            For i As Integer = 0 To derived.Length - 1
                If derived(i) <> storedHash(i) Then equal = False
            Next
            Return equal
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' --- Patients basic operations ---
    Public Shared Function GetAllPatients() As DataTable
        Dim dt As New DataTable()
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "SELECT Id, FirstName, LastName, CodiceFiscale, Contacts, Anamnesis FROM Patients"
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    Public Shared Sub InsertPatient(firstName As String, lastName As String, codiceFiscale As String, contacts As String, anamnesis As String)
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "INSERT INTO Patients (FirstName, LastName, CodiceFiscale, Contacts, Anamnesis) VALUES (@f,@l,@c,@t,@a)"
                    cmd.Parameters.AddWithValue("@f", firstName)
                    cmd.Parameters.AddWithValue("@l", lastName)
                    cmd.Parameters.AddWithValue("@c", codiceFiscale)
                    cmd.Parameters.AddWithValue("@t", contacts)
                    cmd.Parameters.AddWithValue("@a", anamnesis)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub DeletePatient(id As Integer)
        Try
            Using con As New SQLiteConnection(ConnectionString)
                con.Open()
                Using cmd As SQLiteCommand = con.CreateCommand()
                    cmd.CommandText = "DELETE FROM Patients WHERE Id = @id"
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub
End Class
