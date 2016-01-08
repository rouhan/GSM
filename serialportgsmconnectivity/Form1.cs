using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace serialportgsmconnectivity
{
    public partial class Form1 : Form
    {
        SerialPort ser = new SerialPort();
        public Form1()
        {
           
            
           

            //serialPort1.PortName = "COM8";
            //serialPort1.BaudRate = 9600;
            //serialPort1.DataBits = 8;
            //serialPort1.Parity = Parity.None;
            //serialPort1.StopBits = StopBits.None;
           // ser.DataReceived += new
           //SerialDataReceivedEventHandler(serialPort1_DataReceived); 
            InitializeComponent();
        }
        

   
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ser.PortName = "COM8";
            ser.Open();
            string phno;
            phno = char.ConvertFromUtf32(34)+textBox1.Text+ char.ConvertFromUtf32(34);
            ser.Write("AT+CMGF=2"+ char.ConvertFromUtf32(13));
            ser.Write("AT+CMGS=" + phno+ char.ConvertFromUtf32(13));
            ser.Write("Hello sir"+ char.ConvertFromUtf32(26)+ char.ConvertFromUtf32(13));
            ser.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ser.IsOpen)
            {
                ser.Close();
                richTextBox1.AppendText("Port Closed!\n");
            }
            else
            {
                ser.Open();
                richTextBox1.AppendText("Port Open!\n");
            }


        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = ser.ReadExisting();
            richTextBox1.AppendText(data);
        }
    }
}
