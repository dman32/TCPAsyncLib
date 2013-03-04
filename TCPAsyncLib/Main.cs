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
    public partial class frmMain : Form
    {
        frmServer server = new frmServer();
        frmClient client = new frmClient();
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!server.Visible)
                server.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!client.Visible)
                client.Show();
        }
    }
}
