using ConsoleServer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    class Program
    {
        static List<TcpClient> clients = new List<TcpClient>();
        static TcpListener server = null;
        static int countF = 0;
        static void Main(string[] args)
        {
            try
            {
                server = new TcpListener(IPAddress.Parse(Data.IP), Data.PORT);
                //запускаю слушателя 
                server.Start();
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    clients.Add(client);

                    ClientObject clientObject = new ClientObject(client);

                    Listener(clientObject);
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                if (server != null)
                    server.Stop();
            }

        }

        private static async void Listener(ClientObject cl)
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    cl.Process();

                    foreach (var client in clients)
                    {
                        if (!client.Equals(cl))
                        {
                            //отправлю файл кроме себя
                            string fileName = Data.FileName + countF + ".txt";
                            client.Client.SendFile(Data.FileName);
                        }

                    }

                }
            });
        }
    }
}
