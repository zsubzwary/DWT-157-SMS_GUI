using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DWT_157_SMS_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            String msg = txtMessage.Text.Replace("\r\n", "\n");
            String res = SMS.sendSMS(txtPhoneNo.Text, msg, txtCOMPort.Text);
            MessageBox.Show(res);
        }

        private void btnBroadcast_Click(object sender, EventArgs e)
        {

        }
    }
}
