using GsmComm.GsmCommunication;
using GsmComm.PduConverter;
using GsmComm.PduConverter.SmartMessaging;
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
        public static String sendSMS(String phoneno, String message, String portno, bool usePDU = true)
        {
            String responseOfAction = "";
            if (usePDU == false)
            {
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
            else
            {
                // GsmComm is installed from nuget Package Manager
                GsmCommMain GsmCom = null;
                try
                {
                    GsmCom = new GsmCommMain(portno, 9600, 5000);
                    GsmCom.Open();
                    GsmCom.PortName.ToString();
                    OutgoingSmsPdu[] pdus = null;
                    bool isValidGSMCharaters = isValidGSMCharateres(message);
                    if (isValidGSMCharaters)
                    {
                        pdus = SmartMessageFactory.CreateConcatTextMessage(message, false, phoneno);
                    }
                    else
                    {
                        pdus = SmartMessageFactory.CreateConcatTextMessage(message, true, phoneno);
                    }
                    Debug.WriteLine($" ===>> {isValidGSMCharaters}");
                    //var st = new Stopwatch();
                    //st.Start();
                    long smsSent = 0;
                    if (pdus != null)
                    {
                        foreach (OutgoingSmsPdu pdu in pdus)
                        {
                            GsmCom.SendMessage(pdu);
                        }
                        //smsSent = st.ElapsedMilliseconds;
                    }
                    GsmCom.Close();
                    //var gsmClsed = st.ElapsedMilliseconds;
                    //st.Stop();
                    //Debug.WriteLine($"smsSentIN: {smsSent} == gsmClosed in {gsmClsed - smsSent }");
                    String formate = isValidGSMCharaters == true ? "GSM" : "Unicode";
                    return $"Message Sent with {portno.ToString()} in “{formate}” format in {pdus.Count()} part(s)";
                }
                catch (Exception exp)
                {
                    if (GsmCom.IsOpen())
                    {
                        GsmCom.Close();
                    }
                    return "Not send: " + exp.Message;
                    // goto lebe;
                }
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

        private static bool isValidGSMCharateres(String message)
        {
            // Remove all the ENTERS and check it against the characters
            message = message.Replace("\n", " ");
                
            var isValidGSM = true;
            var gsm = "@£$¥èéùìòÇØøÅåΔ_ΦΓΛΩΠΨΣΘΞ^{}\\[~]|€ÆæßÉ!\"#¤%&'()*+,-./0123456789:;<=>?¡ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÑÜ§¿abcdefghijklmnopqrstuvwxyzäöñüà ";

            for (int i = 0; i < message.Length; i++)
            {
                bool letterInAlfabet = gsm.Contains(message[i]);
                if (letterInAlfabet == false)
                {
                    // this means that the character is out of GSM space.
                    isValidGSM = false;
                    break;
                }
            }
            return isValidGSM;
        }
    }
}
