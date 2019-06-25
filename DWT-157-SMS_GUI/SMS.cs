using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DWT_157_SMS_GUI
{
    public class SMS
    {
        public static String sendSMS(String phoneno, String message, String portno)
        {
            String responseOfAction = "";
            try
            {
                // for more info visit https://stackoverflow.com/a/15450868/8140312
                SerialPort sp = new SerialPort();
                sp.PortName = portno;
                sp.Open();
                SendCommand("AT", sp);
                SendCommand("AT+CMGF=1", sp);
                SendCommand("AT+CSCS=\"GSM\"", sp);
                SendCommand("AT+CMGS=\"" + phoneno + "\"", sp);

                var response = SendCommand(message + "\x1A", sp);

                if (response.Contains("ERROR"))
                {
                    responseOfAction = $"Unable to send SMS{Environment.NewLine}RESPONSE: “{response}”";
                }
                else
                {
                    responseOfAction = $"SMS sent successfully.{Environment.NewLine}RESPONSE: “{response}”";
                }
                sp.Close();

                return responseOfAction;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public static String SendCommand(string command, SerialPort sp)
        {
            sp.Write(command + "\r");
            Thread.Sleep(45);
            String res = sp.ReadExisting();
            Debug.WriteLine("COMMAND: " + res);
            // Do not put here an arbitrary wait, check modem's response
            // Reading from serial port (use timeout).
            return res;
        }

    }
}
