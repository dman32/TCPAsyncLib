namespace TCPAsyncLib
{
    partial class frmClient2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMissed = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlHeartbeat = new System.Windows.Forms.Panel();
            this.lblHeartbeatRec = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHeartbeatSend = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMissed);
            this.groupBox1.Controls.Add(this.lblUpdate);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.pnlHeartbeat);
            this.groupBox1.Controls.Add(this.lblHeartbeatRec);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblHeartbeatSend);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Heartbeat";
            // 
            // lblMissed
            // 
            this.lblMissed.AutoSize = true;
            this.lblMissed.Location = new System.Drawing.Point(171, 46);
            this.lblMissed.Name = "lblMissed";
            this.lblMissed.Size = new System.Drawing.Size(40, 13);
            this.lblMissed.TabIndex = 5;
            this.lblMissed.Text = "update";
            this.lblMissed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(171, 16);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(40, 13);
            this.lblUpdate.TabIndex = 5;
            this.lblUpdate.Text = "update";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlHeartbeat
            // 
            this.pnlHeartbeat.Location = new System.Drawing.Point(6, 19);
            this.pnlHeartbeat.Name = "pnlHeartbeat";
            this.pnlHeartbeat.Size = new System.Drawing.Size(40, 40);
            this.pnlHeartbeat.TabIndex = 1;
            // 
            // lblHeartbeatRec
            // 
            this.lblHeartbeatRec.AutoSize = true;
            this.lblHeartbeatRec.Location = new System.Drawing.Point(93, 46);
            this.lblHeartbeatRec.Name = "lblHeartbeatRec";
            this.lblHeartbeatRec.Size = new System.Drawing.Size(27, 13);
            this.lblHeartbeatRec.TabIndex = 0;
            this.lblHeartbeatRec.Text = "Rec";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rec:";
            // 
            // lblHeartbeatSend
            // 
            this.lblHeartbeatSend.AutoSize = true;
            this.lblHeartbeatSend.Location = new System.Drawing.Point(93, 19);
            this.lblHeartbeatSend.Name = "lblHeartbeatSend";
            this.lblHeartbeatSend.Size = new System.Drawing.Size(32, 13);
            this.lblHeartbeatSend.TabIndex = 0;
            this.lblHeartbeatSend.Text = "Send";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Send:";
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 145);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClient";
            this.Text = "Client2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClient_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlHeartbeat;
        private System.Windows.Forms.Label lblHeartbeatRec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHeartbeatSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblMissed;
    }
}