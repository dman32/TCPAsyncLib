using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TCPAsyncLib
{
    public partial class frmClient : Form
    {
        private static System.Timers.Timer tmrUpdate = new System.Timers.Timer(), tmrSend = new System.Timers.Timer();
        private static int cntUpdate = 0, cntRec = 0, cntSend = 0, heartbeatPort = 2056, heartbeatBytes = 1024;
        private const string heartbeatName = "heartbeatclient";
        private static SEALib.TCP.SOCKET client = new SEALib.TCP.SOCKET();

        public frmClient()
        {
            InitializeComponent();
            tmrUpdate.Interval = 100;
            tmrUpdate.Elapsed += new System.Timers.ElapsedEventHandler(tmrUpdate_Elapsed);
            tmrUpdate.Start();
            tmrSend.Interval = 30;
            tmrSend.Elapsed += new System.Timers.ElapsedEventHandler(tmrSend_Elapsed);
            tmrSend.Start();
            
            client.initClient("195.0.0.173", heartbeatPort, null, null, onReceive, heartbeatBytes);
            client.enableHeartbeat(200, null);
        }
        private void frmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (client.isConnected)
                client.disconnect();
            else
                client.startConnecting(0, null);
        }
        //DELEGATES
        public void updateControlText(Control c, string text, bool concatenate)
        {
            if (c.InvokeRequired)
                if (concatenate)
                    c.Invoke(new MethodInvoker(delegate { c.Text += text; }));
                else
                    c.Invoke(new MethodInvoker(delegate { c.Text = text; }));
            else
                if (concatenate)
                    c.Text += text;
                else
                    c.Text = text;
        }
        public void updateControlBackColor(Control c, Color color)
        {
            if (c.InvokeRequired)
                c.Invoke(new MethodInvoker(delegate { c.BackColor = color; }));
            else
                c.BackColor = color;
        }
        //TIMERS
        void tmrSend_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (client.isConnected)
            {
                client.startSend(onSend, Encoding.UTF8.GetBytes("heartbeat"));
            }
        }
        void tmrUpdate_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            cntUpdate++;
            updateControlText(lblUpdate, cntUpdate.ToString(), false);
            updateControlText(lblMissed, client.bufferedSends.ToString(), false);
            if (client.isConnected)
                updateControlBackColor(pnlHeartbeat, Color.Green);
            else
            {
                updateControlBackColor(pnlHeartbeat, Color.Gray);
                client.startConnecting(100, null);
            }
        }
        //CALLBACKS
        public void onReceive(byte[] bytes, int rec)
        {
            cntRec++;
            updateControlText(lblHeartbeatRec, cntRec.ToString(), false);
        }
        public void onSend()
        {
            cntSend++;
            updateControlText(lblHeartbeatSend, cntSend.ToString(), false);
        }
    }
}
