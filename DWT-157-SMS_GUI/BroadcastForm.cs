using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWT_157_SMS_GUI
{
    public partial class BroadcastForm : Form
    {
        public BroadcastForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var line in txtBrodcastInfo.Lines)
            {
                String phoneNo = line.Split(':')[0];
                String name = line.Split(':')[1];
                string msg = txtMessageInfo.Text.Replace("\r\n", "\n");
                msg = msg.Replace("{name}", name);
                msg = msg.Replace("{time}", DateTime.Now.ToString());
                var res = SMS.sendSMS(phoneNo, msg, "COM9");
                Debug.WriteLine(res+ "\n\n\n");
                Thread.Sleep(3000);

            }
        }
    }
}
