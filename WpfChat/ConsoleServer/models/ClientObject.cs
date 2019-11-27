using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer.models
{
    class ClientObject
    {
        public ClientObject(TcpClient client)
        {
            Client = client;
        }

        public TcpClient Client { get; set; }

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                // создаю буффер для получаемых данных
                byte[] buff = new byte[256];
                //получаю сообщение 
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                while (true)
                {

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
