using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Klijent
{
    public class Connection
    {
        private Socket clientSocket;
        private NetworkStream stream;
        private BinaryFormatter formatter = new BinaryFormatter();

        public Connection()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private static Connection instance;

        public static Connection Instance
        {
            get
            {
                if (instance == null)
                    instance = new Connection();
                return instance;

            }
        }

        public bool Connect()
        {
            try
            {
                clientSocket.Connect("127.0.0.1", 8080);
                stream = new NetworkStream(clientSocket);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        

        internal Laborant Login(string username, string password)
        {
            Request req = new Request
            {
                Operacija = Operacija.UlogujSe,
                KorisnickoIme = username,
                Lozinka = password
            };
            formatter.Serialize(stream, req);

            Answer ans = (Answer)formatter.Deserialize(stream);
            if(ans.Uspesno)
                return (Laborant)ans.Objekat;
            return null;
        }

        internal List<Zahtev> GetZahtevi()
        {
            Request req = new Request
            {
                Operacija = Operacija.VratiSveZahteve,
            };
            formatter.Serialize(stream, req);

            Answer ans = (Answer)formatter.Deserialize(stream);
            if (ans.Uspesno)
                return (List<Zahtev>)ans.Objekat;
            return null;
        }

        internal List<Laboratorija> GetLaboratorije()
        {
            Request req = new Request
            {
                Operacija = Operacija.VratiLaboratorije,
            };
            formatter.Serialize(stream, req);

            Answer ans = (Answer)formatter.Deserialize(stream);
            if (ans.Uspesno)
                return (List<Laboratorija>)ans.Objekat;
            return null;
        }

        internal List<OsiguranoLice> GetOsiguranaLica()
        {
            Request req = new Request
            {
                Operacija = Operacija.VratiOsiguranaLica,
            };
            formatter.Serialize(stream, req);

            Answer ans = (Answer)formatter.Deserialize(stream);
            if (ans.Uspesno)
                return (List<OsiguranoLice>)ans.Objekat;
            return null;
        }

        internal bool UpdateZahteve(List<Zahtev> zahteviZaBazu)
        {
            Request req = new Request
            {
                Operacija = Operacija.UpdateZahteve,
            };
            formatter.Serialize(stream, req);

            Answer ans = (Answer)formatter.Deserialize(stream);
            if (ans.Uspesno)
                return true;
            return false;
        }
    }
}
