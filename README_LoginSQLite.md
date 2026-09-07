Guida rapida: Modulo autenticazione e database SQLite

1) Eseguire l'app
- Compila ed esegui la soluzione in Visual Studio.
- Al primo avvio viene creato il file clinic.db nella cartella dell'app (Application.StartupPath).

2) Credenziali iniziali
- Utente di default: username = admin, password = admin123

3) Dove si trova il DB
- clinic.db si trova nella cartella dell'eseguibile del progetto (es. bin\Debug\).

4) Funzionalità implementate
- Login che verifica le credenziali nella tabella Users (hash PBKDF2).
- Dashboard protetta accessibile solo dopo login.
- Form Pazienti: lista, inserimento rapido, cancellazione e refresh.
- DB schema iniziale: Users, Patients, ClinicalRecords, Treatments, Appointments, Invoices.

5) Aggiungere un nuovo utente
- Puoi eseguire una semplice routine nel codice per creare un utente: DBHelper.CreateUser("nuovoUser","password","role").
- Oppure apri clinic.db con un tool SQLite e inserisci manualmente nella tabella Users; la password deve essere l'hash generato da HashPassword (consigliato usare CreateUser).

6) Pacchetti NuGet
- Il progetto richiede un provider SQLite. Se non presente, installa System.Data.SQLite.Core o Microsoft.Data.Sqlite tramite NuGet.
- Esempio (Package Manager Console): Install-Package System.Data.SQLite.Core

7) Prossimi miglioramenti consigliati
- Interfaccia per gestione utenti (cambio password, ruoli) con log accessi.
- Moduli CRUD completi per Cartelle Cliniche, Trattamenti, Appuntamenti e Fatturazione.
- Validazioni dei campi, logging degli errori e backup del DB.

Se vuoi, procedo a implementare la gestione utenti (registrazione/cambio password) o a convertire il codice per usare Microsoft.Data.Sqlite.
