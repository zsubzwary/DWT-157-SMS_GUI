using System;
using System.Collections.Generic;
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
                SerialPort sp = new SerialPort();
                sp.PortName = portno;
                sp.Open();
                sp.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(44);
                sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(44);
                sp.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                Thread.Sleep(44);
                sp.WriteLine("AT+CMGS=\"" + phoneno + "\"" + Environment.NewLine);
                Thread.Sleep(44);
                sp.WriteLine(message + Environment.NewLine);
                Thread.Sleep(44);
                sp.Write(new Byte[] { 26 }, 0, 1);
                Thread.Sleep(44);
                var response = sp.ReadExisting();

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

    }
}
