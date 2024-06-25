using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLServerInformKazan.ServerElements
{
    /// <summary>
    /// Класс сервис работы с сокетами
    /// </summary>
    public class NetService
    {
        /// <summary>
        /// Слушатель TCP сокетов
        /// </summary>
        private TcpListener tcpListener;
        /// <summary>
        /// Поток TCP сервера
        /// </summary>
        private Thread listenThread;
        /// <summary>
        /// Ссылка на основную форму
        /// </summary>
        private MainWindow mainWindow;
        /// <summary>
        /// Флаг работы сервера
        /// </summary>
        private bool enableServer = true;

        /// <summary>
        /// Остановки работы сервера
        /// </summary>
        public void StopServer()
        {
            try
            {
                //опускаем флаг работы сервера
                enableServer = false;

                //останавливам TCP сокет
                tcpListener.Stop();

                //Логирование
                Action showMethod4 = () => mainWindow.lstBxWorkLog.Items.Add("Сервер остановлен!");
                mainWindow.lstBxWorkLog.Invoke(showMethod4);
            }
            catch { }
        }

        /// <summary>
        /// Запуск работы сервера 
        /// </summary>
        /// <param name="window">Ссылка на основную форму</param>
        /// <param name="ip">ip адресс</param>
        /// <param name="port">Прослушиваемый порт</param>
        public void StartServer(MainWindow window, string ip, int port)
        {
            //Поднимаем флаг работы сервера
            enableServer = true;
            //Ссылка на основную форму
            mainWindow = window;
            //Инициализируем TCP прослушиватель
            tcpListener = new TcpListener(IPAddress.Parse(ip), port);
            //Запускаем поток работы сервера
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
        }

        /// <summary>
        /// Тело основного потока TCP сервера
        /// </summary>
        private void ListenForClients()
        {
            //вспомогательный флаг отправки данных клиенту
            bool sendFlag = false;

            try
            {
                // запускаем слушателя TCP сокетов
                tcpListener.Start();
                //Логирование
                Action showMethod1 = () => mainWindow.lstBxWorkLog.Items.Add("Сервер запущен. Ожидание подключений... ");
                mainWindow.lstBxWorkLog.Invoke(showMethod1);

                //Постоянный цикл
                while (enableServer)
                {
                    // получаем подключение в виде TcpClient
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();

                    //проверяем подключени клиента
                    if (tcpClient.Connected)
                    {
                        try
                        {
                            // получаем объект NetworkStream для взаимодействия с клиентом
                            NetworkStream stream = tcpClient.GetStream();
                            // буфер для входящих данных
                            var response = new List<byte>();
                            int bytesRead = 10;

                            //Общаемся с клиентом
                            while (enableServer)
                            {
                                //проверяем подключени клиента
                                if (tcpClient.Connected)
                                {
                                    //Если данные доступны считываем их
                                    if (stream.DataAvailable && !mainWindow.newXMLLoad)
                                    {
                                        // считываем данные до конечного символа
                                        while (stream.DataAvailable)
                                        {
                                            bytesRead = stream.ReadByte();
                                            // добавляем в буфер
                                            response.Add((byte)bytesRead);
                                        }

                                        //Конвертируем данные в строку
                                        string word = Encoding.UTF8.GetString(response.ToArray());

                                        //Логирование
                                        Action showMethod2 = () => mainWindow.lstBxWorkLog.Items.Add($"Запрошен XML команда {word}");
                                        mainWindow.lstBxWorkLog.Invoke(showMethod2);

                                        // если прислан маркер окончания взаимодействия,
                                        // выходим из цикла и завершаем взаимодействие с клиентом
                                        if (word.IndexOf("END")>=0) break;

                                        //поднимаем флаг наличия данных для доставки
                                        sendFlag = true;
                                    }

                                    //Если есть новый загруженный XML поднимаем файл доставки
                                    if (mainWindow.newXMLLoad)
                                    {
                                        //Логирование
                                        Action showMethod2 = () => mainWindow.lstBxWorkLog.Items.Add("Загружен XML отправляем его клиенту");
                                        mainWindow.lstBxWorkLog.Invoke(showMethod2);

                                        //поднимаем флаг наличия данных для доставки
                                        sendFlag = true;
                                    }

                                    //Если флаг поднят отправляем данные
                                    if (sendFlag)
                                    {

                                        byte[] data = new byte[4];
                                        if (mainWindow.msg != null)
                                        {
                                            //Конвертируем данные
                                            data = mainWindow.msg.ToBytes();
                                        }
                                        //Отправляем XML
                                        stream.Write(data, 0, data.Length);
                                        //Чистим буфер
                                        response.Clear();

                                        //Опускаем флаги
                                        sendFlag = false;
                                        mainWindow.newXMLLoad = false;

                                        //Логирование
                                        Action showMethod3 = () => mainWindow.lstBxWorkLog.Items.Add("XML отправлен клиенту");
                                        mainWindow.lstBxWorkLog.Invoke(showMethod3);
                                    }
                                }
                                else
                                {
                                    //Логирование
                                    Action showMethod6 = () => mainWindow.lstBxWorkLog.Items.Add("Server ERROR!");
                                    mainWindow.lstBxWorkLog.Invoke(showMethod6);
                                }
                                //Логирование
                                Action showMethod5 = () => mainWindow.lstBxWorkLog.Items.Add("Server Alive!");
                                mainWindow.lstBxWorkLog.Invoke(showMethod5);

                                Thread.Sleep(1000);
                            }

                            //Сообщаем о закрытии сокета клиенту
                            stream.Write(Encoding.UTF8.GetBytes("DISCONNECT"), 0, 10);

                            //Закрываем сокет
                            tcpClient.Close();
                            //Логирование
                            Action showMethod4 = () => mainWindow.lstBxWorkLog.Items.Add("Соединение с клиентом разорвано!");
                            mainWindow.lstBxWorkLog.Invoke(showMethod4);
                        }
                        catch
                        {
                            //Логирование
                            Action showMethod4 = () => mainWindow.lstBxWorkLog.Items.Add("Соединение с клиентом разорвано!");
                            mainWindow.lstBxWorkLog.Invoke(showMethod4);
                        }
                    }

                    Thread.Sleep(1000);
                }
            }
            catch { }
            finally
            {
                //Освобождаем ресурсы
                tcpListener.Stop();
            }
        }


    }
}
