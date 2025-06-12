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
            groupBoxResult.Enabled = false;
            groupBoxCommunication.Enabled = false;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            Task.Run(() => ProcessSend());
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
                    MessageBox.Show("Connected to Modbus server.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessSend()
        {
            if (comboBoxFunction.SelectedIndex == -1)
            {
                MessageBox.Show("Please select function mode!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int Address = 0;
            int Quantity = 0;
            int Value = 0;
            try
            {
                Address = int.Parse(textBoxAdd.Text);
                Quantity = int.Parse(textBoxQuantity.Text);
                Value = int.Parse(textBoxValue.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid number! Please recheck Address, Quantity and Value textBox!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch (comboBoxFunction.SelectedItem.ToString().Substring(0, 2))
            {
                case "01":
                    bool[] result1 = client.ReadCoils(Address, Quantity);
                    textBoxData.Clear();
                    for (int i = 0; i <result1.Length; i++)
                    {
                        textBoxData.Text += $" Register     Value\r\n";
                        textBoxData.Text += $"0x{int.Parse(textBoxAdd.Text) + i}   {(result1[i] == true ? 1 : 0)}\r\n";
                    }
                    break;
                case "02":
                    bool[] result2 = client.ReadDiscreteInputs(Address, Quantity);
                    textBoxData.Clear();
                    for (int i = 0; i < result2.Length; i++)
                    {
                        textBoxData.Text += $" Register     Value\r\n";
                        textBoxData.Text += $"1x{int.Parse(textBoxAdd.Text) + i}   {(result2[i] == true ? 1 : 0)}\r\n";
                    }
                    break;
                case "03":
                    int[] result3 = client.ReadHoldingRegisters(Address, Quantity);
                    textBoxData.Clear();
                    for (int i = 0; i < result3.Length; i++)
                    {
                        textBoxData.Text += $" Register     Value\r\n";
                        textBoxData.Text += $"4x{int.Parse(textBoxAdd.Text) + i}   {result3[i]}\r\n";
                    }
                    break;
                case "04":
                    int[] result4 = client.ReadHoldingRegisters(Address, Quantity);
                    textBoxData.Clear();
                    for (int i = 0; i < result4.Length; i++)
                    {
                        textBoxData.Text += $" Register     Value\r\n";
                        textBoxData.Text += $"3x{int.Parse(textBoxAdd.Text) + i}   {result4[i]}\r\n";
                    }
                    break;
                case "05":
                    client.WriteSingleCoil(Address, (Value == 0? false : true));
                    MessageBox.Show("Connected to Modbus server.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "06":
                    client.WriteSingleRegister(Address, Value);
                    MessageBox.Show("Connected to Modbus server.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "15":
                    bool[] data15 = new bool[Quantity];
                    for(int i = 0; i < Quantity; i++)
                    {
                        data15[i] = (Value == 0 ? false : true);
                    }
                    client.WriteMultipleCoils(Address, data15);
                    MessageBox.Show("Connected to Modbus server.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "16":
                    int[] data16 = new int[Quantity];
                    for (int i = 0; i < Quantity; i++)
                    {
                        data16[i] = Value;
                    }
                    client.WriteMultipleRegisters(Address, data16);
                    MessageBox.Show("Connected to Modbus server.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void comboBoxFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxFunction.SelectedIndex == -1)
                return;
            switch(comboBoxFunction.SelectedItem.ToString().Substring(0, 2))
            {
                case "01":
                case "02":
                case "03":
                case "04":
                    textBoxQuantity.ReadOnly = false;
                    labelValue.Visible = false;
                    textBoxValue.Visible = false;
                    break;
                case "05":  
                case "06":
                    labelValue.Visible = true;
                    textBoxValue.Visible = true;
                    textBoxQuantity.ReadOnly = true;
                    break;
                case "15":
                case "16":
                    textBoxQuantity.ReadOnly = false;
                    labelValue.Visible = true;
                    textBoxValue.Visible = true;
                    break;
            }
        }
    }
}
