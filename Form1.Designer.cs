namespace ModbusTCP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBoxConnect = new GroupBox();
            buttonDisconnect = new Button();
            buttonConnect = new Button();
            textBoxPort = new TextBox();
            label2 = new Label();
            textBoxIPAdd = new TextBox();
            label1 = new Label();
            groupBoxCommunication = new GroupBox();
            labelNote = new Label();
            comboBoxFunction = new ComboBox();
            label7 = new Label();
            textBoxQuantity = new TextBox();
            labelQuantity = new Label();
            textBoxValue = new TextBox();
            labelValue = new Label();
            buttonSend = new Button();
            textBoxAdd = new TextBox();
            label3 = new Label();
            groupBoxResult = new GroupBox();
            textBoxData = new TextBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            groupBoxConnect.SuspendLayout();
            groupBoxCommunication.SuspendLayout();
            groupBoxResult.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBoxConnect
            // 
            groupBoxConnect.Controls.Add(buttonDisconnect);
            groupBoxConnect.Controls.Add(buttonConnect);
            groupBoxConnect.Controls.Add(textBoxPort);
            groupBoxConnect.Controls.Add(label2);
            groupBoxConnect.Controls.Add(textBoxIPAdd);
            groupBoxConnect.Controls.Add(label1);
            groupBoxConnect.Dock = DockStyle.Top;
            groupBoxConnect.Location = new Point(0, 59);
            groupBoxConnect.Name = "groupBoxConnect";
            groupBoxConnect.Size = new Size(417, 90);
            groupBoxConnect.TabIndex = 0;
            groupBoxConnect.TabStop = false;
            groupBoxConnect.Text = "Connection";
            // 
            // buttonDisconnect
            // 
            buttonDisconnect.Location = new Point(304, 27);
            buttonDisconnect.Name = "buttonDisconnect";
            buttonDisconnect.Size = new Size(107, 36);
            buttonDisconnect.TabIndex = 5;
            buttonDisconnect.Text = "Disconnect";
            buttonDisconnect.UseVisualStyleBackColor = true;
            buttonDisconnect.Click += buttonDisconnect_Click;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(188, 27);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(107, 36);
            buttonConnect.TabIndex = 4;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(82, 47);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(100, 23);
            textBoxPort.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 48);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 2;
            label2.Text = "Port:";
            // 
            // textBoxIPAdd
            // 
            textBoxIPAdd.Location = new Point(82, 20);
            textBoxIPAdd.Name = "textBoxIPAdd";
            textBoxIPAdd.Size = new Size(100, 23);
            textBoxIPAdd.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 23);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "IP Address:";
            // 
            // groupBoxCommunication
            // 
            groupBoxCommunication.Controls.Add(labelNote);
            groupBoxCommunication.Controls.Add(comboBoxFunction);
            groupBoxCommunication.Controls.Add(label7);
            groupBoxCommunication.Controls.Add(textBoxQuantity);
            groupBoxCommunication.Controls.Add(labelQuantity);
            groupBoxCommunication.Controls.Add(textBoxValue);
            groupBoxCommunication.Controls.Add(labelValue);
            groupBoxCommunication.Controls.Add(buttonSend);
            groupBoxCommunication.Controls.Add(textBoxAdd);
            groupBoxCommunication.Controls.Add(label3);
            groupBoxCommunication.Dock = DockStyle.Top;
            groupBoxCommunication.Location = new Point(0, 149);
            groupBoxCommunication.Name = "groupBoxCommunication";
            groupBoxCommunication.Size = new Size(417, 150);
            groupBoxCommunication.TabIndex = 6;
            groupBoxCommunication.TabStop = false;
            groupBoxCommunication.Text = "Read/Write Operations";
            // 
            // labelNote
            // 
            labelNote.AutoSize = true;
            labelNote.Location = new Point(187, 65);
            labelNote.Name = "labelNote";
            labelNote.Size = new Size(128, 15);
            labelNote.TabIndex = 13;
            labelNote.Text = "(Address base is 00000)";
            // 
            // comboBoxFunction
            // 
            comboBoxFunction.FormattingEnabled = true;
            comboBoxFunction.Location = new Point(81, 27);
            comboBoxFunction.Name = "comboBoxFunction";
            comboBoxFunction.Size = new Size(190, 23);
            comboBoxFunction.TabIndex = 12;
            comboBoxFunction.SelectedIndexChanged += comboBoxFunction_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 30);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 10;
            label7.Text = "Function:";
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(81, 86);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(100, 23);
            textBoxQuantity.TabIndex = 9;
            textBoxQuantity.Text = "1";
            // 
            // labelQuantity
            // 
            labelQuantity.AutoSize = true;
            labelQuantity.Location = new Point(20, 89);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(56, 15);
            labelQuantity.TabIndex = 8;
            labelQuantity.Text = "Quantity:";
            // 
            // textBoxValue
            // 
            textBoxValue.Location = new Point(82, 115);
            textBoxValue.Name = "textBoxValue";
            textBoxValue.Size = new Size(100, 23);
            textBoxValue.TabIndex = 7;
            textBoxValue.Text = "0";
            // 
            // labelValue
            // 
            labelValue.AutoSize = true;
            labelValue.Location = new Point(38, 118);
            labelValue.Name = "labelValue";
            labelValue.Size = new Size(38, 15);
            labelValue.TabIndex = 6;
            labelValue.Text = "Value:";
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(304, 19);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(107, 36);
            buttonSend.TabIndex = 4;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // textBoxAdd
            // 
            textBoxAdd.Location = new Point(81, 57);
            textBoxAdd.Name = "textBoxAdd";
            textBoxAdd.Size = new Size(100, 23);
            textBoxAdd.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 60);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Offset:";
            // 
            // groupBoxResult
            // 
            groupBoxResult.Controls.Add(textBoxData);
            groupBoxResult.Dock = DockStyle.Fill;
            groupBoxResult.Location = new Point(0, 299);
            groupBoxResult.Name = "groupBoxResult";
            groupBoxResult.Size = new Size(417, 270);
            groupBoxResult.TabIndex = 7;
            groupBoxResult.TabStop = false;
            groupBoxResult.Text = "Data";
            // 
            // textBoxData
            // 
            textBoxData.BackColor = SystemColors.Control;
            textBoxData.Dock = DockStyle.Fill;
            textBoxData.Location = new Point(3, 19);
            textBoxData.Multiline = true;
            textBoxData.Name = "textBoxData";
            textBoxData.ScrollBars = ScrollBars.Vertical;
            textBoxData.Size = new Size(411, 248);
            textBoxData.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(417, 59);
            panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(110, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 47);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 569);
            Controls.Add(groupBoxResult);
            Controls.Add(groupBoxCommunication);
            Controls.Add(groupBoxConnect);
            Controls.Add(panel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modbus TCP/IP";
            groupBoxConnect.ResumeLayout(false);
            groupBoxConnect.PerformLayout();
            groupBoxCommunication.ResumeLayout(false);
            groupBoxCommunication.PerformLayout();
            groupBoxResult.ResumeLayout(false);
            groupBoxResult.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxConnect;
        private TextBox textBoxPort;
        private Label label2;
        private TextBox textBoxIPAdd;
        private Label label1;
        private Button buttonDisconnect;
        private Button buttonConnect;
        private GroupBox groupBoxCommunication;
        private Button buttonSend;
        private TextBox textBoxAdd;
        private Label label3;
        private TextBox textBoxValue;
        private Label labelValue;
        private Label label7;
        private TextBox textBoxQuantity;
        private Label labelQuantity;
        private ComboBox comboBoxFunction;
        private GroupBox groupBoxResult;
        private TextBox textBoxData;
        private Label labelNote;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}
