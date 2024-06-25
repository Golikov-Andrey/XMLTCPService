using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing;

namespace XMLClientInformKazanWPF.Domain
{
    internal class MessageClass
    {
        /// <summary>
        /// DOS кодировка
        /// </summary>
        private System.Text.Encoding enc = System.Text.Encoding.GetEncoding(866);//Кодовая страница Дос

        public int FormatVersion { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Id { get; set; }
        public System.Drawing.Color Color { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }


        //=========================== Формат пакета ================================
        //
        //|------0------|------1------|------2------|------3------|
        //|-------------------------------------------------------|
        //|                    Счетчик пакетов                    |
        //|-------------------------------------------------------|
        //|------4------|------5------|------6------|------7------|
        //|-------------------------------------------------------|
        //|               Номет контейнера/IP отправителя         |
        //|-------------------------------------------------------|
        //|------8------|------9------|-----10------|-----11------|
        //|-------------------------------------------------------|
        //|   Номер     |    Номер    | Флаг окончания контейнера/|
        //|вертуального |    КОП-а    |     Порт отправителя      |  
        //|   канала    |             |                           |
        //|-------------------------------------------------------|
        // 
        //======================//======================//======================
        public byte[] ToBytes()
        {
            int lenFrom = enc.GetBytes(From).Length;
            int lenText = enc.GetBytes(Text).Length;
            int lenColor = 4;
            int lenImage = enc.GetBytes(Image).Length;

            byte[] pocket = new byte[lenFrom + lenText + lenColor + lenImage + 32];

            BitConverter.GetBytes(lenFrom).CopyTo(pocket, 0);
            enc.GetBytes(From).CopyTo(pocket, 4);

            BitConverter.GetBytes(lenText).CopyTo(pocket, lenFrom + 4);
            enc.GetBytes(Text).CopyTo(pocket, lenFrom + 8);

            BitConverter.GetBytes(lenColor).CopyTo(pocket, lenFrom + lenText + 8);
            BitConverter.GetBytes(Color.ToArgb()).CopyTo(pocket, lenFrom + lenText + 12);

            BitConverter.GetBytes(lenImage).CopyTo(pocket, lenFrom + lenText + 8 + 8);
            enc.GetBytes(Image).CopyTo(pocket, lenFrom + lenText + 8 + 8 + 4);

            return pocket;
        }

        public void FromBytes(byte[] bytes)
        {
            int offset = 0;
            int len = BitConverter.ToInt32(bytes, offset);

            From = enc.GetString(bytes, offset+4, len);

            offset += len+4;

            len = BitConverter.ToInt32(bytes, offset);

            Text = enc.GetString(bytes, offset+4, len);

            offset += len+4;

            len = BitConverter.ToInt32(bytes, offset);

            Color = System.Drawing.Color.FromArgb(BitConverter.ToInt32(bytes, offset + 4));

            offset += len+4;

            len = BitConverter.ToInt32(bytes, offset);

            Image = enc.GetString(bytes, offset+4, len);

            offset += len+4;


        }

    }
}
