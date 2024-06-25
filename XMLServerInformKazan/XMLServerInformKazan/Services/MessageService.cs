using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using XMLServerInformKazan.Domain;


namespace XMLServerInformKazan.ServerElements
{
    /// <summary>
    /// Класс сервис работы с сообщениями
    /// </summary>
    internal class MessageService
    {
        /// <summary>
        /// Загружает данные из XML файла и сохраняет во внутрений формат 
        /// </summary>
        /// <param name="filePath">Путь к XML файлу</param>
        /// <returns>пару (MessageClass,bool): MessageClass(данные), bool(результат загрузки) </returns>
        public static (MessageClass,bool) XMLToMSG(string filePath)
        {
            //Создаем объект сообщение
            MessageClass newMsg = new MessageClass();

            //XML документ
            XmlDocument conf_supp = new XmlDocument();
            try
            {
                //Читаем файл в память
                conf_supp.Load(filePath);

                //=======================================================================================================
                XmlNodeList nodeList;//Вспомогательнаяпеременная
                XmlNode root = conf_supp.DocumentElement;//Получаем доступ к XML файлу

                //Считываем текст сообщения
                nodeList = root.SelectNodes("/root/Message/msg/text");
                //Выставляем текст
                newMsg.Text = nodeList[0].InnerText;
                //Вставляем цвет
                newMsg.Color = System.Drawing.ColorTranslator.FromHtml("#" + nodeList[0].Attributes[0].Value);

                //Считываем картинку
                nodeList = root.SelectNodes("/root/Message/msg/image");
                newMsg.Image = nodeList[0].InnerText;

                //Считываем сообщение
                nodeList = root.SelectNodes("Message");
                //Характеристики сообщения
                newMsg.FormatVersion = Convert.ToInt32(nodeList[0].Attributes[0].Value);
                newMsg.From = nodeList[0].Attributes[1].Value;
                newMsg.To = nodeList[0].Attributes[2].Value;
                //ID сообщения
                nodeList = root.SelectNodes("/root/Message/msg");
                newMsg.Id = Convert.ToInt32(nodeList[0].Attributes[0].Value);
                //=======================================================================================================
            }
            catch//Если при загрузке файла случился конфуз, сообщаем пользователю
            {
                MessageBox.Show("При загрузке XML файла произошла ошибка!");
                return (newMsg, false);
            }
            //Возвращаем данные
            return (newMsg, true);
        }


    }
}
