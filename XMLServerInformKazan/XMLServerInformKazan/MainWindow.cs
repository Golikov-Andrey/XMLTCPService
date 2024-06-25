using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLServerInformKazan.Domain;
using XMLServerInformKazan.ServerElements;

namespace XMLServerInformKazan
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Слушатель TCP сокетов
        /// </summary>
        public TcpListener server;
        /// <summary>
        /// TCP клиент
        /// </summary>
        public TcpClient client;
        /// <summary>
        /// Поток TCP сервера
        /// </summary>
        private Thread clientScaner;
        /// <summary>
        /// Путь к XML файлу
        /// </summary>
        public String fileXML = String.Empty;
        /// <summary>
        /// Объект сообщение
        /// </summary>
        public MessageClass msg;
        /// <summary>
        /// Флаг загрузки нового XML файла
        /// </summary>
        public bool newXMLLoad = false;
        /// <summary>
        /// Объект с сетевыми сервисами
        /// </summary>
        public NetService netServic = new NetService();


        /// <summary>
        /// Кнопка запуск TCP сервера
        /// </summary>
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            //Переключаем активность кнопки
            btnStopServer.Enabled = true;
            btnStartServer.Enabled = false;
            //Запусукаем сервер
            netServic.StartServer(this,txtbIpAdress.Text, (int)nmudSocketPort.Value);
        }

        /// <summary>
        /// Кнопка загрузка XML файла
        /// </summary>
        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            //Фильтр диалогового окна
            openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.DefaultExt = "xml";
            openFileDialog1.FileName = "";
            //Создаем диалоговое окно выбора директории
            DialogResult result = openFileDialog1.ShowDialog();

            //Если нажат ОК
            if (result == DialogResult.OK)
            {
                //Передаем путь XML файла лейблу и сохраняем его  
                fileXML = openFileDialog1.FileName;
                lblXMLPath.Text = fileXML;

                //Конвертируем XML во внутренний формат сообщения
                (MessageClass value,bool loaded) loadedXML =MessageService.XMLToMSG(fileXML);
                //Если файл загружен успешно
                if(loadedXML.loaded)
                {
                    //загруженное сообщение
                    msg = loadedXML.value;
                    //Логирование
                    lstBxWorkLog.Items.Add("Успешно загружен XML");

                    //Отображаем загруженные данные на форму
                    try
                    {
                        nmudFormatVersion.Value = msg.FormatVersion;
                        nmudId.Value = msg.Id;
                    }
                    catch
                    {
                        MessageBox.Show("При загрузке FormatVersion или id произошла ошибка");
                    }

                    cmboxFrom.Text = msg.From;
                    cmboxFrom.Items.Add(msg.From);
                    cmboxTo.Text = msg.To;
                    cmboxTo.Items.Add(msg.To);

                    txtbTextMessage.ForeColor = msg.Color;
                    txtbTextMessage.Text = msg.Text;

                    btnColorCoise.BackColor = msg.Color;

                    // Преобразование строки Base64 в массив байтов
                    byte[] imageBytes = Convert.FromBase64String(msg.Image);

                    // Создание потока из массива байтов
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        // Создание изображения из потока
                        Image image = Image.FromStream(ms);

                        // Установка изображения для PictureBox
                        pctboxImageMessage.BackgroundImage = image;
                    }
                    //Изменяем флаг для отправки XML клиенту
                    newXMLLoad = true;

                }
                else
                {
                    //Логирование
                    lstBxWorkLog.Items.Add("При загрузке XML произошла ошибка");
                }
            }
        }

        /// <summary>
        /// Завершение работы программы
        /// </summary>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Останавливаем сервер
            netServic.StopServer();
        }

        /// <summary>
        /// Кнопка остановки TCP сервера
        /// </summary>
        private void btnStopServer_Click(object sender, EventArgs e)
        {
            //Переключаем активность кнопки
            btnStopServer.Enabled = false;
            btnStartServer.Enabled = true;
            //Останавливаем сервер
            netServic.StopServer();
        }
    }
}
