using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using XMLClientInformKazanWPF.Domain;

namespace XMLClientInformKazanWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Thread listenThread;
        private bool getXML;
        private bool stopSocket = false;
        private string ipAdress;
        private string port;
        private MessageClass msg = new MessageClass();
        BitmapImage bi = new BitmapImage();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getXML = true;


        }


        public void StartClient()
        {
            bool sendLastCommand = true;

            while (sendLastCommand)
            {
                try
                {
                    TcpClient tcpClient = new TcpClient();
                   // tcpClient.Connect("127.0.0.1", 8888);
                    tcpClient.Connect(ipAdress, Convert.ToInt32(port));

                    if (tcpClient.Connected)
                    {
                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => txtBStatusConnect.Text = "CONNECTED"));//MainClass.RadioStations            
                    }

                    // слова для отправки для получения перевода
                    //var words = new string[] { "GiveMeXML!" };
                    // получаем NetworkStream для взаимодействия с сервером
                    NetworkStream stream = tcpClient.GetStream();

                    // буфер для входящих данных
                    var response = new List<byte>();
                    int bytesRead = 10; // для считывания байтов из потока


                    while (tcpClient.Connected)
                    {

                        if (stream.DataAvailable)
                        {
                            // считываем данные до конечного символа
                            while (stream.DataAvailable)
                            {
                                bytesRead = stream.ReadByte();
                                // добавляем в буфер
                                response.Add((byte)bytesRead);
                            }

                            if (response.Count < 20)
                            {
                                if (Encoding.UTF8.GetString(response.ToArray()).IndexOf("DISCONNECT") >= 0)
                                {
                                    stopSocket = true;
                                }
                            }
                            else
                            {
                                msg.FromBytes(response.ToArray());
                                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => txtFrom.Text = msg.From));//MainClass.RadioStations
                                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => { txtMsgText.Text = msg.Text;
                                    txtMsgText.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(msg.Color.A, msg.Color.R, msg.Color.G, msg.Color.B));
                                }));//MainClass.RadioStations
                                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => txtReciveData.Text = "Received at: "+DateTime.Now.ToString("T")));//MainClass.RadioStations


                                byte[] binaryData = Convert.FromBase64String(msg.Image);
                               
                                //Image img = new Image();
                                //img.Source = bi;

                               
                                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => {
                                    bi = new BitmapImage();
                                    bi.BeginInit();
                                    bi.StreamSource = new MemoryStream(binaryData);
                                    bi.EndInit();
                                    imgFromMsg.Source = bi; }));//MainClass.RadioStations

                                // var translation = Encoding.UTF8.GetString(response.ToArray());
                            }

                            response.Clear();
                        }

                        if (getXML)
                        {
                            getXML = false;
                            // считыванием строку в массив байт
                            // при отправке добавляем маркер завершения сообщения - \n
                            byte[] data = Encoding.UTF8.GetBytes("GiveMeXML!");
                            // отправляем данные
                            stream.Write(data, 0, data.Length);
                        }

                        if(stopSocket)
                        {
                            stopSocket = false;
                            // отправляем маркер завершения подключения - END
                            stream.Write(Encoding.UTF8.GetBytes("END"), 0, 3);
                            tcpClient.Close();
                            sendLastCommand = false;
                        }

                        Thread.Sleep(1000);
                    }

                }
                catch
                {
                    // listBox1.Items.Add("При подключении произошла ошибка! Повторите позже!");
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => txtBStatusConnect.Text = "DISCONNECT"));//MainClass.RadioStations
                    
                }
                Thread.Sleep(1000);
                

            }



            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => txtBStatusConnect.Text = "DISCONNECT"));//MainClass.RadioStations
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => btmDisconnect.IsEnabled = false));//MainClass.RadioStations
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => btmConnect.IsEnabled = true));//MainClass.RadioStations

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            stopSocket = true;

            try
            {
                //while (listenThread.IsAlive)
                {
                    Thread.Sleep(500); 
                }
            }
            catch { }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            port = txtBPort.Text;
            ipAdress = txtBIpAdress.Text;
            listenThread = new Thread(new ThreadStart(StartClient));
            listenThread.Start();
            btmDisconnect.IsEnabled = true;
            btmConnect.IsEnabled = false;
        }

        private void btmDisconnect_Click(object sender, RoutedEventArgs e)
        {
            stopSocket = true;
            //try
            //{
            //    listenThread.Abort();
            //}
            //catch { }

            btmDisconnect.IsEnabled = false;
            btmConnect.IsEnabled = true;
        }
    }
}
