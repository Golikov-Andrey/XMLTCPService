using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace XMLClientInformKazanWPF.Services
{
    internal class ClientNetService
    {
        public void StartClient()
        {
            //while (true)
            //{
            //    try
            //    {
            //        TcpClient tcpClient = new TcpClient();
            //        tcpClient.Connect("127.0.0.1", 8888);

            //        if (tcpClient.Connected)
            //        {
            //            listBox1.Items.Add("STATUS CONNECTED");
            //        }

            //        // слова для отправки для получения перевода
            //        //var words = new string[] { "GiveMeXML!" };
            //        // получаем NetworkStream для взаимодействия с сервером
            //        var stream = tcpClient.GetStream();

            //        // буфер для входящих данных
            //        var response = new List<byte>();
            //        int bytesRead = 10; // для считывания байтов из потока


            //        while (tcpClient.Connected)
            //        {

            //            if (stream.DataAvailable)
            //            {
            //                // считываем данные до конечного символа
            //                while (stream.DataAvailable)
            //                {
            //                    bytesRead = stream.ReadByte();
            //                    // добавляем в буфер
            //                    response.Add((byte)bytesRead);
            //                }

            //                var translation = Encoding.UTF8.GetString(response.ToArray());
            //                listBox1.Items.Add(translation);
            //                response.Clear();
            //            }

            //            if (getXML)
            //            {
            //                getXML = false;
            //                // считыванием строку в массив байт
            //                // при отправке добавляем маркер завершения сообщения - \n
            //                byte[] data = Encoding.UTF8.GetBytes("GiveMeXML!");
            //                // отправляем данные
            //                stream.Write(data, 0, data.Length);
            //            }

            //            //foreach (var word in words)
            //            //{
            //            //    // считыванием строку в массив байт
            //            //    // при отправке добавляем маркер завершения сообщения - \n
            //            //    byte[] data = Encoding.UTF8.GetBytes(word + '\n');
            //            //    // отправляем данные
            //            //    stream.Write(data, 0, data.Length);

            //            //    Thread.Sleep(1000);
            //            //    // считываем данные до конечного символа
            //            //    while (stream.DataAvailable)
            //            //    {
            //            //        bytesRead = stream.ReadByte();
            //            //        // добавляем в буфер
            //            //        response.Add((byte)bytesRead);
            //            //    }

            //            //    var translation = Encoding.UTF8.GetString(response.ToArray());
            //            //    listBox1.Items.Add($"Слово {word}: {translation}");
            //            //    response.Clear();
            //            //}



            //            //// отправляем маркер завершения подключения - END
            //            //stream.Write(Encoding.UTF8.GetBytes("END\n"), 0, 4);
            //            //listBox1.Items.Add("Все сообщения отправлены");



            //            Thread.Sleep(1000);
            //        }

            //    }
            //    catch
            //    {
            //        listBox1.Items.Add("При подключении произошла ошибка! Повторите позже!");
            //        listBox1.Items.Add("STATUS DISCONNECT");
            //    }
            //    Thread.Sleep(1000);
            //}

        }
    }
}
