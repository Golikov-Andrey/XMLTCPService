using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace XMLServerInformKazan.Domain
{
    //==================================================================================================================================================
    // Класс сообщение для клиента
    // После успешного парсинга файла необходимо передать следующие данные клиенту: 
    //1.	От кого сообщение(from)
    //2.	Текст сообщения с указанным цветом(text и color)
    //3.	Картинка(image)
    //==================================================================================================================================================
    /// <summary>
    /// Класс сообщение для клиента
    /// </summary>
    public class MessageClass
    {
        /// <summary>
        /// DOS кодировка
        /// </summary>
        private System.Text.Encoding enc = System.Text.Encoding.GetEncoding(866);//Кодовая страница Дос

        //Данные из XML файла
        public int FormatVersion { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Id { get; set; }
        public Color Color { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }


        //=========================== Формат пакета ================================
        //
        //|------0------|------1------|------2------|------3------|
        //|-------------------------------------------------------|
        //|                длина поля from                        |
        //|-------------------------------------------------------|
        //|                     from                              |
        //|-------------------------------------------------------|
        //|------4------|------5------|------6------|------7------|
        //|-------------------------------------------------------|
        //|                длина поля text                        |
        //|-------------------------------------------------------|
        //|                     text                              |
        //|-------------------------------------------------------|
        //|------8------|------9------|-----10------|-----11------|
        //|-------------------------------------------------------|
        //|                длина поля color                       |
        //|-------------------------------------------------------|
        //|                     color                             |
        //|-------------------------------------------------------|
        //|------12-----|------13-----|-----14------|-----15------|
        //|-------------------------------------------------------|
        //|                длина поля image                       |
        //|-------------------------------------------------------|
        //|                     image                             |
        //|-------------------------------------------------------|
        // 
        //======================//======================//======================
        /// <summary>
        /// Конвертирует сообщение из внутреннего формата в формат пакета
        /// </summary>
        /// <returns>массив byte[] сконвертированных данных</returns>
        public byte[] ToBytes()
        {
            //Длины полей
            int lenFrom = enc.GetBytes(From).Length;
            int lenText = enc.GetBytes(Text).Length;
            int lenColor = 4;
            int lenImage = enc.GetBytes(Image).Length;

            //Выделяем массив для сборки пакета
            byte[] pocket = new byte[lenFrom + lenText + lenColor + lenImage+32];

            //Записываем данные в пакет
            BitConverter.GetBytes(lenFrom).CopyTo( pocket, 0 );
            enc.GetBytes(From).CopyTo(pocket, 4);

            BitConverter.GetBytes(lenText).CopyTo(pocket, lenFrom + 4);
            enc.GetBytes(Text).CopyTo(pocket, lenFrom + 8);

            BitConverter.GetBytes(lenColor).CopyTo(pocket, lenFrom + lenText + 8);
            BitConverter.GetBytes(Color.ToArgb()).CopyTo(pocket, lenFrom + lenText + 12);

            BitConverter.GetBytes(lenImage).CopyTo(pocket, lenFrom + lenText + 8 + 8);
            enc.GetBytes(Image).CopyTo(pocket, lenFrom + lenText + 8 + 8+4);

            //Возвращаем пакет
            return pocket;
        }

        /// <summary>
        /// Конвертирует сообщение из формат пакета в сообщения внутреннего формата 
        /// </summary>
        /// <param name="bytes">Данные полученные по TCP сокету</param>
        public void FromBytes(byte[] bytes)
        {
            //Смещение в пакете
            int offset = 0;
            //Длина данных
            int len = BitConverter.ToInt32(bytes, offset);
            //Записываем данные в поле
            From = enc.GetString(bytes, offset, len);
            
            offset += len;
            len = BitConverter.ToInt32(bytes, offset);
            Text = enc.GetString(bytes, offset, len);

            offset += len;
            len = BitConverter.ToInt32(bytes, offset);
            Color = Color.FromArgb(BitConverter.ToInt32(bytes, offset+4));

            offset += len;
            len = BitConverter.ToInt32(bytes, offset);
            Image = enc.GetString(bytes, offset, len);
         
        }
    }

}
