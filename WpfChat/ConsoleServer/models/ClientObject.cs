using System;
using System.Collections.Generic;
using System.IO;
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
        public string Conntent { get; set; }

        public void Process()
        {

            try
            {
                // создаю буффер для получаемых данных
                byte[] data = new byte[256];

                //получаю сообщение 
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                while (true)
                {
                    //получаю сетевой поток для чтения 
                    NetworkStream stream = Client.GetStream();
                    //читаю сообщение 
                    bytes = stream.Read(data, 0, data.Length);
                    //в конс
                    // Console.WriteLine(Encoding.Default.GetString(data,0,bytes));
                    Console.WriteLine("Сообщение от клиента {0}", Client.Client.RemoteEndPoint);

                    #region проверка на файл (хочу вырезать первое слово и если file принимать как  text )
                    //
                    byte[] firstWord = new byte[5];
                    for (int i = 0; i < firstWord.Length; i++)
                    {
                        firstWord[i] = data[i];
                    }

                    #endregion

                    Conntent = Encoding.UTF8.GetString(data);

                    //запись в файл 
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(Data.FileName))
                        {
                            sw.WriteLine(Conntent);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
