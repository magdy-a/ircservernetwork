namespace Chatting
{
    partial class MyClient
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyClient));
            this.rtxtChatBox = new System.Windows.Forms.RichTextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.btnProgramConnection = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnSendFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.txtServerIP = new System.Windows.Forms.ToolStripTextBox();
            this.btnProgramEdit = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnChangeDownloadLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearChatBox = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnMinimize = new System.Windows.Forms.ToolStripButton();
            this.btnRestart = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxtChatBox
            // 
            this.rtxtChatBox.BackColor = System.Drawing.Color.White;
            this.rtxtChatBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtChatBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rtxtChatBox.Location = new System.Drawing.Point(3, 28);
            this.rtxtChatBox.Name = "rtxtChatBox";
            this.rtxtChatBox.ReadOnly = true;
            this.rtxtChatBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtxtChatBox.Size = new System.Drawing.Size(392, 191);
            this.rtxtChatBox.TabIndex = 58;
            this.rtxtChatBox.Text = "";
            this.ttMain.SetToolTip(this.rtxtChatBox, "Chat Box");
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.Location = new System.Drawing.Point(3, 225);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(392, 20);
            this.txtMessage.TabIndex = 33;
            this.ttMain.SetToolTip(this.txtMessage, "Send a message to Server");
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            this.txtMessage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyClient_MouseDown);
            this.txtMessage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyClient_MouseMove);
            // 
            // tsMain
            // 
            this.tsMain.BackColor = System.Drawing.Color.Transparent;
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProgramConnection,
            this.btnProgramEdit,
            this.btnClose,
            this.btnMinimize,
            this.btnRestart});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMain.Size = new System.Drawing.Size(398, 25);
            this.tsMain.TabIndex = 59;
            this.tsMain.Text = "tsMain";
            this.tsMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyClient_MouseDown);
            this.tsMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyClient_MouseMove);
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.rtxtChatBox);
            this.pnlMain.Controls.Add(this.tsMain);
            this.pnlMain.Controls.Add(this.txtMessage);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(400, 250);
            this.pnlMain.TabIndex = 60;
            // 
            // btnProgramConnection
            // 
            this.btnProgramConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnProgramConnection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSendFile,
            this.btnConnect,
            this.btnDisconnect,
            this.txtServerIP});
            this.btnProgramConnection.Image = global::Chatting.Properties.Resources.wireless_connection_icon;
            this.btnProgramConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProgramConnection.Name = "btnProgramConnection";
            this.btnProgramConnection.Size = new System.Drawing.Size(29, 22);
            this.btnProgramConnection.Text = "Connection";
            this.btnProgramConnection.TextChanged += new System.EventHandler(this.txtServerIP_TextChanged);
            // 
            // btnSendFile
            // 
            this.btnSendFile.BackColor = System.Drawing.Color.Transparent;
            this.btnSendFile.Image = global::Chatting.Properties.Resources.send_file_icon;
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(160, 22);
            this.btnSendFile.Text = "Send File";
            this.btnSendFile.ToolTipText = "Send a File through network";
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Transparent;
            this.btnConnect.Image = global::Chatting.Properties.Resources._300px_Button_Icon_Green_svg;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(160, 22);
            this.btnConnect.Text = "Connect";
            this.btnConnect.ToolTipText = "Connect to Server";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.Transparent;
            this.btnDisconnect.Image = global::Chatting.Properties.Resources._12247848622041168088roystonlodge_Simple_Glossy_Circle_Button_Red;
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(160, 22);
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.ToolTipText = "Disconnect from Server";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtServerIP
            // 
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(100, 23);
            this.txtServerIP.ToolTipText = "Server IP";
            // 
            // btnProgramEdit
            // 
            this.btnProgramEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnProgramEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnChangeDownloadLocation,
            this.btnClearChatBox});
            this.btnProgramEdit.Image = global::Chatting.Properties.Resources.Xcode;
            this.btnProgramEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProgramEdit.Name = "btnProgramEdit";
            this.btnProgramEdit.Size = new System.Drawing.Size(29, 22);
            this.btnProgramEdit.Text = "Edit";
            // 
            // btnChangeDownloadLocation
            // 
            this.btnChangeDownloadLocation.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeDownloadLocation.Image = global::Chatting.Properties.Resources.images;
            this.btnChangeDownloadLocation.Name = "btnChangeDownloadLocation";
            this.btnChangeDownloadLocation.Size = new System.Drawing.Size(221, 22);
            this.btnChangeDownloadLocation.Text = "Change Download Location";
            this.btnChangeDownloadLocation.ToolTipText = "Change Download Location";
            this.btnChangeDownloadLocation.Click += new System.EventHandler(this.btnChangeDownloadLocation_Click);
            // 
            // btnClearChatBox
            // 
            this.btnClearChatBox.BackColor = System.Drawing.Color.Transparent;
            this.btnClearChatBox.Image = global::Chatting.Properties.Resources.edit_clear;
            this.btnClearChatBox.Name = "btnClearChatBox";
            this.btnClearChatBox.Size = new System.Drawing.Size(221, 22);
            this.btnClearChatBox.Text = "Clear ChatBox";
            this.btnClearChatBox.ToolTipText = "Clear Chat Box";
            this.btnClearChatBox.Click += new System.EventHandler(this.btnClearChatBox_Click);
            // 
            // btnClose
            // 
            this.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = global::Chatting.Properties.Resources.close;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 22);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnMinimize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMinimize.Image = global::Chatting.Properties.Resources.thumbs_126001_matte_white_square_icon_symbols_shapes_minimize;
            this.btnMinimize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(23, 22);
            this.btnMinimize.Text = "Minimize";
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRestart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRestart.Image = global::Chatting.Properties.Resources.Restart_Button_11;
            this.btnRestart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(23, 22);
            this.btnRestart.Text = "Restart";
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // MyClient
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MyClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "My Client";
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WIFI_PWM_Controller_FormClosing);
            this.Load += new System.EventHandler(this.WIFI_PWM_Controller_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MyClient_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MyClient_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyClient_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyClient_MouseMove);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.RichTextBox rtxtChatBox;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripDropDownButton btnProgramEdit;
        private System.Windows.Forms.ToolStripMenuItem btnChangeDownloadLocation;
        private System.Windows.Forms.ToolStripDropDownButton btnProgramConnection;
        private System.Windows.Forms.ToolStripMenuItem btnSendFile;
        private System.Windows.Forms.ToolStripMenuItem btnConnect;
        private System.Windows.Forms.ToolStripMenuItem btnDisconnect;
        private System.Windows.Forms.ToolStripMenuItem btnClearChatBox;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripButton btnRestart;
        private System.Windows.Forms.ToolStripButton btnMinimize;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripTextBox txtServerIP;
        private System.Windows.Forms.ToolTip ttMain;
    }
}

