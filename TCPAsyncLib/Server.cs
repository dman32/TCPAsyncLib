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
        private static int cntUpdate = 0, cntRec = 0, cntSend = 0, heartbeatPort = 2055, heartbeatBytes = 1024;
        private const string heartbeatName = "heartbeatserver";

        public frmServer()
        {
            InitializeComponent();
            tmrUpdate.Interval = 10;
            tmrUpdate.Elapsed += new System.Timers.ElapsedEventHandler(tmrUpdate_Elapsed);
            tmrUpdate.Start();
            tmrSend.Interval = 10;
            tmrSend.Elapsed += new System.Timers.ElapsedEventHandler(tmrSend_Elapsed);
            tmrSend.Start();
            SEALib.TCP.addServer(heartbeatName, heartbeatPort, null, null, onReceive, heartbeatBytes);
        }
        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!SEALib.TCP.isListening(heartbeatName))
                if (!SEALib.TCP.isConnected(heartbeatName))
                    SEALib.TCP.startListening(heartbeatName);
                else
                    SEALib.TCP.disconnect(heartbeatName);
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
            if (SEALib.TCP.isConnected(heartbeatName))
                SEALib.TCP.startSend(heartbeatName, onSend, Encoding.UTF8.GetBytes("HI"));
        }
        void tmrUpdate_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            cntUpdate++;
            updateControlText(lblUpdate, cntUpdate.ToString(), false);
            if (SEALib.TCP.isListening(heartbeatName))
            {
                updateControlBackColor(pnlHeartbeat, Color.Blue);
                if (button1.Text != "Stop Listening")
                    updateControlText(button1, "Stop Listening", false);
            }
            else
                if (SEALib.TCP.isConnected(heartbeatName))
                {
                    updateControlBackColor(pnlHeartbeat, Color.Green);
                    if (button1.Text != "Disconnect")
                        updateControlText(button1, "Disconnect", false);
                }
                else
                {
                    updateControlBackColor(pnlHeartbeat, Color.Gray);
                    if (button1.Text != "Listen")
                        updateControlText(button1, "Listen", false);
                }

        }
        //CALLBACKS
        public void onReceive(String name, byte[] bytes, int rec)
        {
            cntRec++;
            updateControlText(lblHeartbeatRec, cntRec.ToString(), false);
        }
        public void onSend(String name)
        {
            cntSend++;
            updateControlText(lblHeartbeatSend, cntSend.ToString(), false);
        }
    }
}
