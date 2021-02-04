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
                        case Operacija.SacuvajZahteve:
                            SacuvajZahteve(ref ans, ref req);
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

        private void SacuvajZahteve(ref Answer ans, ref Request req)
        {
            try
            {
                broker.OpenConnection();
                ans.Objekat = broker.SacuvajZahteve(req.ZahteviZaBazu);
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

        

        
    }

        
}
