using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfChat.models;

namespace WpfChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //client
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbIp.Text) || !String.IsNullOrEmpty(tbPort.Text) || !String.IsNullOrEmpty(tbName.Text))
            {

                User user = new User(tbName.Text);                
              
                try
                {
                    Data.Address = tbIp.Text;
                    Data.Port = int.Parse(tbPort.Text);

                    //подключение к серверу 
                    TcpClient client = new TcpClient();
                    NetworkStream stream = client.GetStream();


                    IPAddress iPAddress = IPAddress.Parse(tbIp.Text);

                    // для передачи файлов
                    FtpWebRequest webRequest = WebRequest.Create();

                    client.Connect(iPAddress, Int32.Parse(tbPort.Text));
                    //прослушка сообщений сервера
                    Listen(client);
                   
                    while (true)
                    {
                        byte[] buf = new byte[1024];

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    if (client.Connected)
                    {                    
                        client.Close();
                    }


                }
            }
            MessageBox.Show("Пустое поле IP,Port");
        }

        //прослу
        #region listen server
        static async private void Listen(TcpClient client)
        {
            await Task.Run(()=> {
               
                FtpWebResponse webResponse=(FtpWebResponse)
                    byte[] buff = new byte[64];
                    int size = 0;


                
                


            });
        }

        #endregion

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
