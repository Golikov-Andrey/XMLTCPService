namespace XMLServerInformKazan
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbSocketOptions = new System.Windows.Forms.GroupBox();
            this.nmudSocketPort = new System.Windows.Forms.NumericUpDown();
            this.txtbIpAdress = new System.Windows.Forms.TextBox();
            this.lblSocketPort = new System.Windows.Forms.Label();
            this.lblIPAdress = new System.Windows.Forms.Label();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.gbWorkLog = new System.Windows.Forms.GroupBox();
            this.lstBxWorkLog = new System.Windows.Forms.ListBox();
            this.gbXMLViewer = new System.Windows.Forms.GroupBox();
            this.btnColorCoise = new System.Windows.Forms.Button();
            this.cmboxTo = new System.Windows.Forms.ComboBox();
            this.cmboxFrom = new System.Windows.Forms.ComboBox();
            this.pctboxImageMessage = new System.Windows.Forms.PictureBox();
            this.nmudId = new System.Windows.Forms.NumericUpDown();
            this.nmudFormatVersion = new System.Windows.Forms.NumericUpDown();
            this.txtbTextMessage = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblFormatVersion = new System.Windows.Forms.Label();
            this.lblXMLPath = new System.Windows.Forms.Label();
            this.btnLoadXML = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbSocketOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudSocketPort)).BeginInit();
            this.gbWorkLog.SuspendLayout();
            this.gbXMLViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctboxImageMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudFormatVersion)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSocketOptions
            // 
            this.gbSocketOptions.Controls.Add(this.nmudSocketPort);
            this.gbSocketOptions.Controls.Add(this.txtbIpAdress);
            this.gbSocketOptions.Controls.Add(this.lblSocketPort);
            this.gbSocketOptions.Controls.Add(this.lblIPAdress);
            this.gbSocketOptions.Location = new System.Drawing.Point(12, 12);
            this.gbSocketOptions.Name = "gbSocketOptions";
            this.gbSocketOptions.Size = new System.Drawing.Size(242, 100);
            this.gbSocketOptions.TabIndex = 0;
            this.gbSocketOptions.TabStop = false;
            this.gbSocketOptions.Text = "Настройки сокета";
            // 
            // nmudSocketPort
            // 
            this.nmudSocketPort.Location = new System.Drawing.Point(105, 66);
            this.nmudSocketPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nmudSocketPort.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nmudSocketPort.Name = "nmudSocketPort";
            this.nmudSocketPort.Size = new System.Drawing.Size(120, 20);
            this.nmudSocketPort.TabIndex = 3;
            this.nmudSocketPort.Value = new decimal(new int[] {
            8888,
            0,
            0,
            0});
            // 
            // txtbIpAdress
            // 
            this.txtbIpAdress.Location = new System.Drawing.Point(105, 26);
            this.txtbIpAdress.Name = "txtbIpAdress";
            this.txtbIpAdress.Size = new System.Drawing.Size(120, 20);
            this.txtbIpAdress.TabIndex = 2;
            this.txtbIpAdress.Text = "127.0.0.1";
            // 
            // lblSocketPort
            // 
            this.lblSocketPort.AutoSize = true;
            this.lblSocketPort.Location = new System.Drawing.Point(19, 66);
            this.lblSocketPort.Name = "lblSocketPort";
            this.lblSocketPort.Size = new System.Drawing.Size(35, 13);
            this.lblSocketPort.TabIndex = 1;
            this.lblSocketPort.Text = "Порт:";
            // 
            // lblIPAdress
            // 
            this.lblIPAdress.AutoSize = true;
            this.lblIPAdress.Location = new System.Drawing.Point(18, 29);
            this.lblIPAdress.Name = "lblIPAdress";
            this.lblIPAdress.Size = new System.Drawing.Size(53, 13);
            this.lblIPAdress.TabIndex = 0;
            this.lblIPAdress.Text = "IP адрес:";
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(791, 559);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(123, 23);
            this.btnStartServer.TabIndex = 1;
            this.btnStartServer.Text = "Запустить сервер";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Enabled = false;
            this.btnStopServer.Location = new System.Drawing.Point(12, 559);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(123, 23);
            this.btnStopServer.TabIndex = 2;
            this.btnStopServer.Text = "Остановить сервер";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // gbWorkLog
            // 
            this.gbWorkLog.Controls.Add(this.lstBxWorkLog);
            this.gbWorkLog.Location = new System.Drawing.Point(12, 118);
            this.gbWorkLog.Name = "gbWorkLog";
            this.gbWorkLog.Size = new System.Drawing.Size(242, 435);
            this.gbWorkLog.TabIndex = 3;
            this.gbWorkLog.TabStop = false;
            this.gbWorkLog.Text = "Лог работы программы";
            // 
            // lstBxWorkLog
            // 
            this.lstBxWorkLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBxWorkLog.FormattingEnabled = true;
            this.lstBxWorkLog.Location = new System.Drawing.Point(3, 16);
            this.lstBxWorkLog.Name = "lstBxWorkLog";
            this.lstBxWorkLog.Size = new System.Drawing.Size(236, 416);
            this.lstBxWorkLog.TabIndex = 0;
            // 
            // gbXMLViewer
            // 
            this.gbXMLViewer.Controls.Add(this.btnColorCoise);
            this.gbXMLViewer.Controls.Add(this.cmboxTo);
            this.gbXMLViewer.Controls.Add(this.cmboxFrom);
            this.gbXMLViewer.Controls.Add(this.pctboxImageMessage);
            this.gbXMLViewer.Controls.Add(this.nmudId);
            this.gbXMLViewer.Controls.Add(this.nmudFormatVersion);
            this.gbXMLViewer.Controls.Add(this.txtbTextMessage);
            this.gbXMLViewer.Controls.Add(this.lblColor);
            this.gbXMLViewer.Controls.Add(this.lblImage);
            this.gbXMLViewer.Controls.Add(this.lblText);
            this.gbXMLViewer.Controls.Add(this.lblTo);
            this.gbXMLViewer.Controls.Add(this.lblFrom);
            this.gbXMLViewer.Controls.Add(this.lblId);
            this.gbXMLViewer.Controls.Add(this.lblFormatVersion);
            this.gbXMLViewer.Controls.Add(this.lblXMLPath);
            this.gbXMLViewer.Controls.Add(this.btnLoadXML);
            this.gbXMLViewer.Location = new System.Drawing.Point(260, 12);
            this.gbXMLViewer.Name = "gbXMLViewer";
            this.gbXMLViewer.Size = new System.Drawing.Size(654, 541);
            this.gbXMLViewer.TabIndex = 4;
            this.gbXMLViewer.TabStop = false;
            this.gbXMLViewer.Text = "Загрузка XML";
            // 
            // btnColorCoise
            // 
            this.btnColorCoise.Location = new System.Drawing.Point(528, 214);
            this.btnColorCoise.Name = "btnColorCoise";
            this.btnColorCoise.Size = new System.Drawing.Size(120, 23);
            this.btnColorCoise.TabIndex = 6;
            this.btnColorCoise.Text = "выбор цвета";
            this.btnColorCoise.UseVisualStyleBackColor = true;
            // 
            // cmboxTo
            // 
            this.cmboxTo.FormattingEnabled = true;
            this.cmboxTo.Location = new System.Drawing.Point(433, 86);
            this.cmboxTo.Name = "cmboxTo";
            this.cmboxTo.Size = new System.Drawing.Size(216, 21);
            this.cmboxTo.TabIndex = 5;
            // 
            // cmboxFrom
            // 
            this.cmboxFrom.FormattingEnabled = true;
            this.cmboxFrom.Location = new System.Drawing.Point(79, 83);
            this.cmboxFrom.Name = "cmboxFrom";
            this.cmboxFrom.Size = new System.Drawing.Size(210, 21);
            this.cmboxFrom.TabIndex = 5;
            // 
            // pctboxImageMessage
            // 
            this.pctboxImageMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctboxImageMessage.Location = new System.Drawing.Point(6, 243);
            this.pctboxImageMessage.Name = "pctboxImageMessage";
            this.pctboxImageMessage.Size = new System.Drawing.Size(642, 292);
            this.pctboxImageMessage.TabIndex = 4;
            this.pctboxImageMessage.TabStop = false;
            // 
            // nmudId
            // 
            this.nmudId.Location = new System.Drawing.Point(528, 54);
            this.nmudId.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmudId.Name = "nmudId";
            this.nmudId.Size = new System.Drawing.Size(120, 20);
            this.nmudId.TabIndex = 3;
            this.nmudId.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // nmudFormatVersion
            // 
            this.nmudFormatVersion.Location = new System.Drawing.Point(178, 54);
            this.nmudFormatVersion.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmudFormatVersion.Name = "nmudFormatVersion";
            this.nmudFormatVersion.Size = new System.Drawing.Size(120, 20);
            this.nmudFormatVersion.TabIndex = 3;
            this.nmudFormatVersion.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // txtbTextMessage
            // 
            this.txtbTextMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtbTextMessage.Location = new System.Drawing.Point(6, 140);
            this.txtbTextMessage.Multiline = true;
            this.txtbTextMessage.Name = "txtbTextMessage";
            this.txtbTextMessage.Size = new System.Drawing.Size(642, 68);
            this.txtbTextMessage.TabIndex = 3;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(475, 219);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(33, 13);
            this.lblColor.TabIndex = 2;
            this.lblColor.Text = "color:";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(10, 219);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(38, 13);
            this.lblImage.TabIndex = 2;
            this.lblImage.Text = "image:";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(21, 115);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(27, 13);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "text:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(304, 89);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(19, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "to:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(21, 86);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "from:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(314, 56);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "id:";
            // 
            // lblFormatVersion
            // 
            this.lblFormatVersion.AutoSize = true;
            this.lblFormatVersion.Location = new System.Drawing.Point(17, 56);
            this.lblFormatVersion.Name = "lblFormatVersion";
            this.lblFormatVersion.Size = new System.Drawing.Size(77, 13);
            this.lblFormatVersion.TabIndex = 2;
            this.lblFormatVersion.Text = "FormatVersion:";
            // 
            // lblXMLPath
            // 
            this.lblXMLPath.AutoSize = true;
            this.lblXMLPath.Location = new System.Drawing.Point(17, 24);
            this.lblXMLPath.Name = "lblXMLPath";
            this.lblXMLPath.Size = new System.Drawing.Size(77, 13);
            this.lblXMLPath.TabIndex = 1;
            this.lblXMLPath.Text = "Путь к файлу:";
            // 
            // btnLoadXML
            // 
            this.btnLoadXML.Location = new System.Drawing.Point(531, 19);
            this.btnLoadXML.Name = "btnLoadXML";
            this.btnLoadXML.Size = new System.Drawing.Size(117, 23);
            this.btnLoadXML.TabIndex = 0;
            this.btnLoadXML.Text = "Загрузить XML";
            this.btnLoadXML.UseVisualStyleBackColor = true;
            this.btnLoadXML.Click += new System.EventHandler(this.btnLoadXML_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 594);
            this.Controls.Add(this.gbXMLViewer);
            this.Controls.Add(this.gbWorkLog);
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.gbSocketOptions);
            this.Name = "MainWindow";
            this.Text = "XML сервер. Решение тестового задания от компании \"ИНФОРМАТИКА\"";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.gbSocketOptions.ResumeLayout(false);
            this.gbSocketOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudSocketPort)).EndInit();
            this.gbWorkLog.ResumeLayout(false);
            this.gbXMLViewer.ResumeLayout(false);
            this.gbXMLViewer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctboxImageMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudFormatVersion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSocketOptions;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.GroupBox gbWorkLog;
        public System.Windows.Forms.ListBox lstBxWorkLog;
        private System.Windows.Forms.NumericUpDown nmudSocketPort;
        private System.Windows.Forms.TextBox txtbIpAdress;
        private System.Windows.Forms.Label lblSocketPort;
        private System.Windows.Forms.Label lblIPAdress;
        private System.Windows.Forms.GroupBox gbXMLViewer;
        private System.Windows.Forms.Label lblXMLPath;
        private System.Windows.Forms.Button btnLoadXML;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblFormatVersion;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtbTextMessage;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.NumericUpDown nmudFormatVersion;
        private System.Windows.Forms.PictureBox pctboxImageMessage;
        private System.Windows.Forms.NumericUpDown nmudId;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Button btnColorCoise;
        private System.Windows.Forms.ComboBox cmboxTo;
        private System.Windows.Forms.ComboBox cmboxFrom;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

