using System;
using System.Windows.Forms;
using EasyModbus;


namespace ModbusTCP
{
    public partial class Form1 : Form
    {
        private ModbusClient client;
        private bool isConnected = false;
        public Form1()
        {
            InitializeComponent();
            labelValue.Visible = false;
            textBoxValue.Visible = false;
            buttonDisconnect.Enabled = false;
            comboBoxFunction.Items.AddRange(new object[]
            {"01 (Read Coils)", "02 (Read Discrete Inputs)",
            "03 (Read Holding Registers)", "04 (Read Input Registers)",
            "05 (Write Single Coil)", "06 (Write Single Register)",
            "15 (Write Multiple Coils)", "16 (Write Multiple Registers)",
            });
            groupBoxCommunication.Enabled = false;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            ProcessSend();
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (isConnected)
                {
                    client.Disconnect();
                    isConnected = false;
                    buttonConnect.Enabled = true;
                    buttonDisconnect.Enabled = false;
                    textBoxIPAdd.ReadOnly = false;
                    textBoxPort.ReadOnly = false;
                    groupBoxCommunication.Enabled = false;
                    MessageBox.Show("Disconnected from Modbus server.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Disconnect error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxIPAdd.Text) || string.IsNullOrEmpty(textBoxPort.Text))
                {
                    MessageBox.Show("Please Enter IP Address or Port number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!isConnected)
                {
                    string ipAddress = textBoxIPAdd.Text;
                    if (!int.TryParse(textBoxPort.Text, out int port))
                    {
                        MessageBox.Show("Invalid port number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    client = new ModbusClient(ipAddress, port);
                    client.Connect();
                    isConnected = true;
                    buttonConnect.Enabled = false;
                    buttonDisconnect.Enabled = true;
                    textBoxIPAdd.ReadOnly = true;
                    textBoxPort.ReadOnly = true;
                    groupBoxCommunication.Enabled = true;
                    comboBoxFunction.SelectedIndex = 0;
                    MessageBox.Show("Connected to Modbus server.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string FormatNumber(int num, char prefix = '0')
        {
            // Kiểm tra số đầu vào trong khoảng 0-9999
            if (num < 0 || num > 9999)
            {
                throw new ArgumentException("Số đầu vào phải là số nguyên từ 0 đến 9999");
            }

            // Định dạng số thành chuỗi 4 ký tự với padding '0'
            string paddedNum = num.ToString().PadLeft(4, '0');

            // Ghép prefix với số đã padding
            return $"{prefix}{paddedNum}";
        }

        private void ProcessSend()
        {
            //if (comboBoxFunction.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Please select function mode!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            int Address = 0;
            int Quantity = 0;
            int Value = 0;
            try
            {
                Address = int.Parse(textBoxAdd.Text);
                Quantity = int.Parse(textBoxQuantity.Text);
                Value = int.Parse(textBoxValue.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid number! Please recheck Address, Quantity and Value textBox!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch (comboBoxFunction.SelectedItem.ToString().Substring(0, 2))
            {
                case "01":
                    bool[] result1 = client.ReadCoils(Address, Quantity);
                    textBoxData.Clear();
                    textBoxData.Text += $"Register   Value\r\n";
                    for (int i = 0; i < result1.Length; i++)
                    {
                        textBoxData.Text += $"{FormatNumber(Address + i)}          {(result1[i] == true ? 1 : 0)}\r\n";
                    }
                    break;
                case "02":
                    bool[] result2 = client.ReadDiscreteInputs(Address, Quantity);
                    textBoxData.Clear();
                    textBoxData.Text += $"Register   Value\r\n";
                    for (int i = 0; i < result2.Length; i++)
                    {
                        textBoxData.Text += $"{FormatNumber(Address + i, '1')}          {(result2[i] == true ? 1 : 0)}\r\n";
                    }
                    break;
                case "03":
                    int[] result3 = client.ReadHoldingRegisters(Address, Quantity);
                    textBoxData.Clear();
                    textBoxData.Text += $"Register   Value\r\n";
                    for (int i = 0; i < result3.Length; i++)
                    {
                        textBoxData.Text += $"{FormatNumber(Address + i, '4')}          {result3[i]}\r\n";
                    }
                    break;
                case "04":
                    int[] result4 = client.ReadHoldingRegisters(Address, Quantity);
                    textBoxData.Clear();
                    textBoxData.Text += $"Register   Value\r\n";
                    for (int i = 0; i < result4.Length; i++)
                    {
                        textBoxData.Text += $"{FormatNumber(Address + i, '3')}          {result4[i]}\r\n";
                    }
                    break;
                case "05":
                    client.WriteSingleCoil(Address, (Value == 0 ? false : true));
                    MessageBox.Show("WriteSingleCoil Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "06":
                    client.WriteSingleRegister(Address, Value);
                    MessageBox.Show("WriteSingleRegister Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "15":
                    bool[] data15 = new bool[Quantity];
                    for (int i = 0; i < Quantity; i++)
                    {
                        data15[i] = (Value == 0 ? false : true);
                    }
                    client.WriteMultipleCoils(Address, data15);
                    MessageBox.Show("WriteMultipleCoils Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "16":
                    int[] data16 = new int[Quantity];
                    for (int i = 0; i < Quantity; i++)
                    {
                        data16[i] = Value;
                    }
                    client.WriteMultipleRegisters(Address, data16);
                    MessageBox.Show("WriteMultipleRegisters Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void comboBoxFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFunction.SelectedIndex == -1)
                return;
            switch (comboBoxFunction.SelectedItem.ToString().Substring(0, 2))
            {
                case "01":
                case "02":
                case "03":
                case "04":
                    textBoxQuantity.ReadOnly = false;
                    labelValue.Visible = false;
                    textBoxValue.Visible = false;
                    textBoxValue.Text = "0";
                    break;
                case "05":
                case "06":
                    labelValue.Visible = true;
                    textBoxValue.Visible = true;
                    textBoxQuantity.ReadOnly = true;
                    textBoxQuantity.Text = "1";
                    break;
                case "15":
                case "16":
                    textBoxQuantity.ReadOnly = false;
                    labelValue.Visible = true;
                    textBoxValue.Visible = true;
                    break;
            }
            switch (comboBoxFunction.SelectedItem.ToString().Substring(0, 2))
            {
                case "01":
                case "05":
                case "15":
                    labelNote.Text = "(Address base is 00000)";
                    break;
                case "02":
                    labelNote.Text = "(Address base is 10000)";
                    break;
                case "04":
                    labelNote.Text = "(Address base is 30000)";
                    break;
                case "03":
                case "06":
                case "16":
                    labelNote.Text = "(Address base is 40000)";
                    break;
            }
        }
    }
}
