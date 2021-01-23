using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BrokerBP;

namespace Server
{
    public class Server
    {
        private Socket serverSocket;
        private NetworkStream stream;
        private BinaryFormatter formatter = new BinaryFormatter();
        private Broker broker;

        public Server()
        {
            broker = new Broker();
            try
            {

            }
            finally
            {

            }
        }

        public void StartServer()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080));
            serverSocket.Listen(5);

            try
            {
                while(true)
                {
                    Socket clientSocket = serverSocket.Accept();
                    stream = new NetworkStream(clientSocket);

                    Thread thread = new Thread(ProcessRequest);
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Serverska greska:\n" + ex.Message);
            }
        }

        private void ProcessRequest()
        {
            try
            {
                while(true)
                {
                    Request req = (Request)formatter.Deserialize(stream);
                    Answer ans = new Answer { Uspesno = false };
                    switch (req.Operacija)
                    {
                        case Operacija.UlogujSe:
                            UlogujKorisnika(ref req, ref ans);
                            formatter.Serialize(stream, ans);
                            break;
                        case Operacija.VratiSveZahteve:
                            VratiSveZahteve(ref ans);
                            formatter.Serialize(stream, ans);
                            break;
                        case Operacija.VratiLaboratorije:
                            VratiLaboratorije(ref ans);
                            formatter.Serialize(stream, ans);
                            break;
                        case Operacija.VratiOsiguranaLica:
                            VratiOsiguranaLica(ref ans);
                            formatter.Serialize(stream, ans);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Greska pri obradi zahteva:\n" + ex.Message);
            }
        }

        

        private void VratiSveZahteve(ref Answer ans)
        {
            try
            {
                broker.OpenConnection();
                ans.Objekat = broker.VratiZahteve();
                if (ans.Objekat != null)
                {
                    ans.Uspesno = true;
                }
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        private void VratiOsiguranaLica(ref Answer ans)
        {
            try
            {
                broker.OpenConnection();
                ans.Objekat = broker.VratiOsiguranaLica();
                if (ans.Objekat != null)
                {
                    ans.Uspesno = true;
                }
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        private void VratiLaboratorije(ref Answer ans)
        {
            try
            {
                broker.OpenConnection();
                ans.Objekat = broker.VratiLaboratorije();
                if (ans.Objekat != null)
                {
                    ans.Uspesno = true;
                }
            }
            finally
            {
                broker.CloseConnection();
            }
        }



        /*internal List<int> VratiIdZaDatiTip(string tipKompanije)
        {
            List<int> idjevi;
            try
            {
                broker.OpenConnection();
                idjevi = broker.VratiIdZaDatiTip(tipKompanije);
            }
            finally
            {
                broker.CloseConnection();
            }
            return idjevi;
        }*/

        /*private void DodajKompaniju(ref Request req, ref Answer ans, int kompanijaID)
        {
            try
            {
                broker.OpenConnection();
                broker.DodajKompaniju(req.Kompanija, kompanijaID);
            }
            finally
            {
                broker.CloseConnection();
            }
        }*/

        /*private void VratiSveBanke(ref Answer ans)  //u odgovoru je objekat koji je lista banaka
        {
            try
            {
                broker.OpenConnection();
                ans.Objekat = broker.VratiSveBanke();
                if (ans.Objekat != null)
                {
                    ans.Uspesno = true;
                }
            }
            finally
            {
                broker.CloseConnection();
            }
        }*/
        private void UlogujKorisnika(ref Request req, ref Answer ans)
        {
            Laborant laborant;
            try
            {
                broker.OpenConnection();
                laborant = broker.UlogujKorisnika(req.KorisnickoIme, req.Lozinka);
                ans.Objekat = laborant;
                if (laborant != null) 
                {
                    ans.Uspesno = true; 
                }
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        /*public List<Zaposleni> VratiZaposleneZaDGV()
        {
            List<Zaposleni> zaposleni = new List<Zaposleni>();
            try
            {
                broker.OpenConnection();
                zaposleni = broker.VratiZaposleneZaDGV();
            }
            finally
            {
                broker.CloseConnection();
            }
            return zaposleni;
        }*/
        /*private int VratiKompID(ref Request req, ref Answer ans)
        {
            int kompID;
            try
            {
                broker.OpenConnection();
                kompID = broker.VratiMaxIDKompanije();
            }
            finally
            {
                broker.CloseConnection();
            }
            return kompID;
        }*/

        /*private void DodajZaposlene(ref Request req, ref Answer ans, int kompanijaId)
        {
            try
            {
                broker.OpenConnection();
                broker.DodajZaposlene(req.Zaposleni, kompanijaId);
            }
            finally
            {
                broker.CloseConnection();
            }
        }*/

        
    }

        
}
