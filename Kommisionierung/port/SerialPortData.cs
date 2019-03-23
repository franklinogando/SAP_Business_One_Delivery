using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace Kommisionierung
{
    class SerialPortData
    {
        SAPConnector sapConnector;
        public void port()
        {
            SerialPort serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
             if (!serialPort.IsOpen)
             { serialPort.Open(); }
             
             int length = serialPort.BytesToRead;
             char[] buf = new char[length];

             serialPort.Read(buf, 0, length);
          if (buf.Length!=0)
          {
              Consignment_Form f = new Consignment_Form(sapConnector);
              //f.tbScannedCode.Text = "";
              
          }
          serialPort.Close();
            
           //MessageBox.Show();
           //return buf.ToString();
        }
    }
}
