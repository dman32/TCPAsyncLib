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
    public partial class frmServer : Form
    {
        private static System.Timers.Timer tmrUpdate = new System.Timers.Timer(), tmrSend = new System.Timers.Timer();
        private static int cntUpdate = 0, cntRec = 0, cntSend = 0, cntMissed = 0, heartbeatPort = 2056, heartbeatBytes = 1024;
        private const string heartbeatName = "heartbeatserver";
        private static SEALib.TCP.SOCKET server = new SEALib.TCP.SOCKET();

        public frmServer()
        {
            InitializeComponent();
            tmrUpdate.Interval = 100;
            tmrUpdate.Elapsed += new System.Timers.ElapsedEventHandler(tmrUpdate_Elapsed);
            tmrUpdate.Start();
            tmrSend.Interval = 100;
            tmrSend.Elapsed += new System.Timers.ElapsedEventHandler(tmrSend_Elapsed);
            tmrSend.Start();

            server.initServer(heartbeatPort, null, null, onReceive, heartbeatBytes);
           // server.enableHeartbeat(3, 200);
        }

        
        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!server.isListening)
                if (!server.isConnected)
                    server.startListening(0, null);
                else
                    server.disconnect();
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
                c.Invoke(new MethodInvoker(delegate {c.BackColor = color;}));
            else
                c.BackColor = color;
        }
        //TIMERS
        void tmrSend_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (server.isConnected)
                server.startSend(onSend, Encoding.UTF8.GetBytes("HI"));
        }
        void tmrUpdate_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            cntUpdate++;
            updateControlText(lblUpdate, cntUpdate.ToString(), false);
            updateControlText(lblMissed, server.bufferedSends.ToString(), false);
            if (server.isListening)
            {
                updateControlBackColor(pnlHeartbeat, Color.Blue);
                if (button1.Text != "Stop Listening")
                    updateControlText(button1, "Stop Listening", false);
            }
            else
                if (server.isConnected)
                {
                    updateControlBackColor(pnlHeartbeat, Color.Green);
                    if (button1.Text != "Disconnect")
                        updateControlText(button1, "Disconnect", false);
                }
                else
                {
                    updateControlBackColor(pnlHeartbeat, Color.Gray);
                    server.startListening(0, null);
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
