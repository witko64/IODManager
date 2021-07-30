using Microsoft.Data.SqlClient;
using System.Windows;


namespace IODManager
{
    public class ADO
    {
        public string Nazwa { get; set; }
        public string KodPocztowy { get; set; }
        public string Miejscowosc { get; set; }
        public string Adres { get; set; }
        public string Numer { get; set; }
        public string PESEL { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        public string Opis { get; set; }
        private bool IsNew { get; set; }

        public ADO(string nazwa, string kod, string miejsc, string adres, string nr, string pesel, string nip, string reg, string ops)
        {
            Nazwa = nazwa;
            KodPocztowy = kod;
            Miejscowosc = miejsc;
            Adres = adres;
            Numer = nr;
            PESEL = pesel;
            NIP = nip;
            REGON = reg;
            Opis = ops;
            IsNew = false;
        }
        // Odczyt z bazy danych informacji o adminsitratorze

        public bool ValidateData()
        {
            return true;
        }

        public void GetADOData(long idADO)
        {
            DBComunication dBComunication = new DBComunication();
            SqlConnection polaczenie = new SqlConnection(DBComunication.connetionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = polaczenie;
            sqlCommand.CommandText = "SELECT  Nazwa, KodPocztowy, Miejscowosc, Adres, Numer, PESEL, NIP, REGON, Opis FROM tADO WHERE IdADO= " + idADO as string;

            try
            {
                polaczenie.Open();

                try
                {
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows) {
                        sqlDataReader.Read();
                        Nazwa = sqlDataReader.GetString(0);
                        KodPocztowy = sqlDataReader.GetString(1);
                        Miejscowosc = sqlDataReader.GetString(2);
                        Adres = sqlDataReader.GetString(3);
                        Numer = sqlDataReader.GetString(4);
                        PESEL = sqlDataReader.GetString(5);
                        NIP = sqlDataReader.GetString(6);
                        REGON = sqlDataReader.GetString(7);
                        Opis = sqlDataReader.GetString(8);
                        IsNew = false;
                        sqlDataReader.Close();
                    }
                    else
                    {
                        KodPocztowy = "";
                        Miejscowosc = "";
                        Adres = "";
                        Numer = "";
                        PESEL = "";
                        NIP = "";
                        REGON = "";
                        Opis = "";
                        IsNew = true;
                    }
                }
                catch (SqlException se)
                {
                    MessageBox.Show("Błąd stack trace: " + se.StackTrace);
                    MessageBox.Show("Błąd: Message" + se.Message);
                    MessageBox.Show("Błąd: " + se.Errors);
                }
                finally 
                {
                    
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show("Błąd stack trace: " + se.StackTrace);
                MessageBox.Show("Błąd: Message" + se.Message);
                MessageBox.Show("Błąd: " + se.Errors);
            }
            finally
            {
                if (polaczenie.State == System.Data.ConnectionState.Open)
                {
                    polaczenie.Close();
                }
            }
        }

// Dodatnie administratora do bazy danych
        public void AddADOData()
        {
            DBComunication dBComunication = new DBComunication();
            SqlConnection polaczenie = new SqlConnection(DBComunication.connetionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = polaczenie;

            sqlCommand.Parameters.AddWithValue("@Nazwa", Nazwa);
            sqlCommand.Parameters.AddWithValue("@KodPocztowy", KodPocztowy);
            sqlCommand.Parameters.AddWithValue("@Miejscowosc", Miejscowosc);
            sqlCommand.Parameters.AddWithValue("Adres", Adres);
            sqlCommand.Parameters.AddWithValue("@Numer", Numer);
            sqlCommand.Parameters.AddWithValue("@PESEL", PESEL);
            sqlCommand.Parameters.AddWithValue("@NIP", NIP);
            sqlCommand.Parameters.AddWithValue("REGON", REGON);
            sqlCommand.Parameters.AddWithValue("@Opis", Opis);
            sqlCommand.CommandText = "INSERT INTO tADO (Nazwa, KodPocztowy, Miejscowosc, Adres, Numer, PESEL, NIP, REGON, Opis) " +
                "VALUES (@Nazwa, @KodPocztowy, @Miejscowosc, @Adres, @Numer, @PESEL, @NIP, @REGON, @Opis)";

            try
            {
                polaczenie.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Administrator dodany do bazy");
            }
            catch (SqlException se)
            {
                MessageBox.Show("Błąd stack trace: " + se.StackTrace);
                MessageBox.Show("Błąd: Message" + se.Message);
                MessageBox.Show("Błąd: " + se.Errors);
            }
            finally
            {
                if (polaczenie.State == System.Data.ConnectionState.Open)
                {
                    polaczenie.Close();
                }
            }
        }

// Aktualizacja danych administraotrra
        public void UpdateADOData(long idADO)
        {
            DBComunication dBComunication = new DBComunication();
            SqlConnection polaczenie = new SqlConnection(DBComunication.connetionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = polaczenie;

            sqlCommand.Parameters.AddWithValue("@Nazwa", Nazwa);
            sqlCommand.Parameters.AddWithValue("@KodPocztowy", KodPocztowy);
            sqlCommand.Parameters.AddWithValue("@Miejscowosc", Miejscowosc);
            sqlCommand.Parameters.AddWithValue("Adres", Adres);
            sqlCommand.Parameters.AddWithValue("@Numer", Numer);
            sqlCommand.Parameters.AddWithValue("@PESEL", PESEL);
            sqlCommand.Parameters.AddWithValue("@NIP", NIP);
            sqlCommand.Parameters.AddWithValue("REGON", REGON);
            sqlCommand.Parameters.AddWithValue("@Opis", Opis);

            sqlCommand.CommandText = "UPDATE tADO SET Nazwa = @Nazwa, KodPocztowy = @KodPocztowy, Miejscowosc = @Miejscowosc, Adres = @Adres," +
                " Numer = @Numer, PESEL = @PESEL, NIP = @NIP, REGON = @REGON, Opis = @Opis" +
                " WHERE IdADO= " + idADO as string;
            try
            {
                polaczenie.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Zmodyfikowano dane  administratora ");
            }
            catch (SqlException se)
            {
                MessageBox.Show("Błąd stack trace: " + se.Data);
                MessageBox.Show("Błąd: Message" + se.Message);
                MessageBox.Show("Błąd: " + se.Errors);
            }
            finally
            {
                if (polaczenie.State == System.Data.ConnectionState.Open)
                {
                    polaczenie.Close();
                }
            }
        }

    }
}