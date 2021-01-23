using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace BrokerBP
{
    public class Broker
    {
        private SqlConnection connection;

        public Broker()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProSoft-Septembar2020;Integrated Security=True;");
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public Laborant UlogujKorisnika(string korisnickoIme, string lozinka)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Laborant where KorisnickoIme = '{korisnickoIme}' and Lozinka = '{lozinka}'";

            SqlDataReader reader = command.ExecuteReader();
            Laborant l = null;
            while(reader.Read())
            {
                l = new Laborant
                {
                    LaborantID = (int)reader["LaborantID"],
                    Ime = (string)reader["Ime"],
                    KorisnickoIme = (string)reader["KorisnickoIme"],
                    LaboratorijaID = (int)reader["LaboratorijaID"],
                    Lozinka = (string)reader["Lozinka"],
                    Prezime = (string)reader["Prezime"],
                };
            }
            reader.Close();

            return l;
        }

        public object VratiZahteve()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from zahtev where Status='neobradjen'";

            SqlDataReader reader = command.ExecuteReader();
            List<Zahtev> zahtevi = new List<Zahtev>();
            while (reader.Read())
            {
                Zahtev z = new Zahtev
                {
                    Status = (string)reader["Status"],
                    //DatumVremeRezultata = (DateTime)reader["DatumVremeRezultata"],
                    DatumVremeTestiranja = (DateTime)reader["DatumVremeTestiranja"],
                    Hitno = (bool)reader["Hitno"],
                    //LaborantID = (int)reader["LaborantID"],
                    LaboratorijaID = (int)reader["LaboratorijaID"],
                    //Napomena = (string)reader["Napomena"],
                    OsiguranoLiceID = (int)reader["OsiguranoLiceID"],
                    //Rezultat = (string)reader["Rezultat"],
                    //Tip = (string)reader["Tip"],
                    ZahtevID = (int)reader["ZahtevID"]
                };
                zahtevi.Add(z);
            }
            reader.Close();

            return zahtevi;
        }

        public object VratiOsiguranaLica()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from OsiguranoLice";

            SqlDataReader reader = command.ExecuteReader();
            List<OsiguranoLice> osiguranaLica = new List<OsiguranoLice>();
            while (reader.Read())
            {
                OsiguranoLice o = new OsiguranoLice
                {
                    Ime = (string)reader["Ime"],
                    Prezime = (string)reader["Prezime"],
                    KrvnaGrupa = (string)reader["KrvnaGrupa"],
                    LBO = (string)reader["LBO"],
                    OsiguranoLiceID = (int)reader["OsiguranoLiceID"]
                };
                osiguranaLica.Add(o);
            }
            reader.Close();

            return osiguranaLica;
        }

        public object VratiLaboratorije()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Laboratorija";

            SqlDataReader reader = command.ExecuteReader();
            List<Laboratorija> laboratorije = new List<Laboratorija>();
            while (reader.Read())
            {
                Laboratorija l = new Laboratorija
                {
                    Naziv = (string)reader["Naziv"],
                    LaboratorijaID = (int)reader["LaboratorijaID"],
                    DnevniKapacitetTestova = (int)reader["DnevniKapacitetTestova"],
                    Grad = (string)reader["Grad"],
                };
                laboratorije.Add(l);
            }
            reader.Close();

            return laboratorije;
        }

        /*public object VratiSveBanke()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Banka";

            SqlDataReader reader = command.ExecuteReader();
            List<Banka> banke = new List<Banka>();
            while (reader.Read())
            {
                Banka b = new Banka
                {
                    Adresa = (string)reader["Adresa"],
                    BankaID = (int)reader["BankaID"],
                    JedinstveniBrojPlatnogPrometa = (int)reader["JedinstveniBrojPlatnogPrometa"],
                    Naziv = (string)reader["Naziv"]
                };
                banke.Add(b);
            }
            reader.Close();

            return banke;
        }*/

        /*public void DodajKompaniju(Kompanija kompanija, int kompanijaID)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"insert into Kompanija values (@id, @naz, @tipkomp, @pdvo, @maticni, @datum, @brojZap, @korisID)";

            command.Parameters.AddWithValue("@naz", kompanija.Naziv);
            command.Parameters.AddWithValue("@id", kompanijaID);
            command.Parameters.AddWithValue("@tipkomp", kompanija.TipKompanije);
            command.Parameters.AddWithValue("@pdvo", kompanija.PDVObveznik);
            command.Parameters.AddWithValue("@maticni", kompanija.MaticniBroj);
            command.Parameters.AddWithValue("@datum", kompanija.DatumVremeEvidentiranja);
            command.Parameters.AddWithValue("@brojZap", kompanija.BrojZaposlenih);
            command.Parameters.AddWithValue("@korisID", kompanija.KorisnikID);

            command.ExecuteNonQuery();
            
        }*/

        /*public int VratiMaxIDKompanije()
        {
            object maxID;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select max(KompanijaID) from Kompanija";

            maxID = command.ExecuteScalar();
            if (maxID is DBNull)
            {
                return 1;
            }   
            return (int)maxID + 1;
        }*/

        /*public void DodajZaposlene(List<Zaposleni> zaposleni, int kompanijaId)
        {
            foreach(Zaposleni z in zaposleni)
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"insert into Zaposleni values (@ime, @prez, @jmbg, @ziro, @iznos, @kompID, @bankaID)";
                command.Parameters.AddWithValue("@ime", z.Ime);
                command.Parameters.AddWithValue("@prez", z.Prezime);
                command.Parameters.AddWithValue("@jmbg", z.JMBG);
                command.Parameters.AddWithValue("@ziro", z.ZiroRacun);
                command.Parameters.AddWithValue("@iznos", z.Iznos);
                command.Parameters.AddWithValue("@kompID", kompanijaId);
                command.Parameters.AddWithValue("@bankaID", z.BankaID);

                command.ExecuteNonQuery();
            }
        }

        public List<int> VratiIdZaDatiTip(string tipKompanije)
        {
            List<int> intovi = new List<int>();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select KompanijaID from Kompanija where TipKompanije = '{tipKompanije}'";

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int broj = (int)reader[0];
                if (!intovi.Contains(broj))
                {
                    intovi.Add(broj);
                }
            }
            return intovi;
        }

        public List<Zaposleni> VratiZaposleneZaDGV()
        {
            List<Zaposleni> zaposleni = new List<Zaposleni>();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Zaposleni";

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                Zaposleni z = new Zaposleni
                {
                    Ime = (string)reader["Ime"],
                    BankaID = (int)reader["BankaID"],
                    Iznos = (double)reader["Iznos"],
                    JMBG = (string)reader["JMBG"],
                    KompanijaID = (int)reader["KompanijaID"],
                    Prezime = (string)reader["Prezime"],
                    ZaposleniID = (int)reader["ZaposleniID"],
                    ZiroRacun = (string)reader["ZiroRacun"]
                };
                zaposleni.Add(z);
            }
            return zaposleni;
        }*/
    }
}
