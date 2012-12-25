namespace Chatting
{
    partial class MyServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyServer));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.btnFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnConnections = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSendFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChangeDownloadLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearChatBox = new System.Windows.Forms.ToolStripMenuItem();
            this.rtxtChatBox = new System.Windows.Forms.RichTextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMain.Controls.Add(this.btnRestart);
            this.pnlMain.Controls.Add(this.btnMinimize);
            this.pnlMain.Controls.Add(this.btnClose);
            this.pnlMain.Controls.Add(this.ssMain);
            this.pnlMain.Controls.Add(this.rtxtChatBox);
            this.pnlMain.Controls.Add(this.txtMessage);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(151, 214);
            this.pnlMain.TabIndex = 59;
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyServer_MouseDown);
            this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyServer_MouseMove);
            // 
            // btnRestart
            // 
            this.btnRestart.BackgroundImage = global::Chatting.Properties.Resources.restart_md;
            this.btnRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRestart.Location = new System.Drawing.Point(53, 4);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(20, 20);
            this.btnRestart.TabIndex = 61;
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackgroundImage = global::Chatting.Properties.Resources.thumbs_126001_matte_white_square_icon_symbols_shapes_minimize;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimize.Location = new System.Drawing.Point(79, 5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(21, 19);
            this.btnMinimize.TabIndex = 61;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Chatting.Properties.Resources.popup_window_close_button;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(106, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 21);
            this.btnClose.TabIndex = 60;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // ssMain
            // 
            this.ssMain.AutoSize = false;
            this.ssMain.BackColor = System.Drawing.Color.Transparent;
            this.ssMain.Dock = System.Windows.Forms.DockStyle.None;
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFile});
            this.ssMain.Location = new System.Drawing.Point(0, 3);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(21, 22);
            this.ssMain.SizingGrip = false;
            this.ssMain.TabIndex = 59;
            // 
            // btnFile
            // 
            this.btnFile.BackColor = System.Drawing.Color.Transparent;
            this.btnFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnections,
            this.btnEdit});
            this.btnFile.Image = ((System.Drawing.Image)(resources.GetObject("btnFile.Image")));
            this.btnFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFile.Name = "btnFile";
            this.btnFile.ShowDropDownArrow = false;
            this.btnFile.Size = new System.Drawing.Size(20, 20);
            // 
            // btnConnections
            // 
            this.btnConnections.AutoSize = false;
            this.btnConnections.BackColor = System.Drawing.Color.Transparent;
            this.btnConnections.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDisconnect,
            this.btnSendFile});
            this.btnConnections.Image = global::Chatting.Properties.Resources.green_icon;
            this.btnConnections.Name = "btnConnections";
            this.btnConnections.Size = new System.Drawing.Size(152, 22);
            this.btnConnections.Text = "Connections";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.Transparent;
            this.btnDisconnect.Image = global::Chatting.Properties.Resources._12247848622041168088roystonlodge_Simple_Glossy_Circle_Button_Red;
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(152, 22);
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.BackColor = System.Drawing.Color.Transparent;
            this.btnSendFile.Image = global::Chatting.Properties.Resources.send_file_icon;
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(152, 22);
            this.btnSendFile.Text = "Send File";
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = false;
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnChangeDownloadLocation,
            this.btnClearChatBox});
            this.btnEdit.Image = global::Chatting.Properties.Resources.red_tools_icon;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(152, 22);
            this.btnEdit.Text = "Edit";
            // 
            // btnChangeDownloadLocation
            // 
            this.btnChangeDownloadLocation.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeDownloadLocation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChangeDownloadLocation.Image = global::Chatting.Properties.Resources.arrow_down_1;
            this.btnChangeDownloadLocation.Name = "btnChangeDownloadLocation";
            this.btnChangeDownloadLocation.Size = new System.Drawing.Size(221, 22);
            this.btnChangeDownloadLocation.Text = "Change Download Location";
            this.btnChangeDownloadLocation.Click += new System.EventHandler(this.DownloadLocation_Click);
            // 
            // btnClearChatBox
            // 
            this.btnClearChatBox.BackColor = System.Drawing.Color.Transparent;
            this.btnClearChatBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearChatBox.Image = global::Chatting.Properties.Resources.edit_clear;
            this.btnClearChatBox.Name = "btnClearChatBox";
            this.btnClearChatBox.Size = new System.Drawing.Size(221, 22);
            this.btnClearChatBox.Text = "Clear ChatBox";
            this.btnClearChatBox.Click += new System.EventHandler(this.btnClearChatBox_Click);
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
            this.rtxtChatBox.Size = new System.Drawing.Size(141, 153);
            this.rtxtChatBox.TabIndex = 58;
            this.rtxtChatBox.Text = "";
            this.ttMain.SetToolTip(this.rtxtChatBox, "Chat Box");
            this.rtxtChatBox.WordWrap = false;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.Location = new System.Drawing.Point(3, 187);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(141, 20);
            this.txtMessage.TabIndex = 33;
            this.ttMain.SetToolTip(this.txtMessage, "Send a Message to client");
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // MyServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(152, 215);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MyServer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "My Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WIFI_PWM_Controller_FormClosing);
            this.Load += new System.EventHandler(this.WIFI_PWM_Controller_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MyServer_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MyServer_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyServer_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyServer_MouseMove);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.RichTextBox rtxtChatBox;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripDropDownButton btnFile;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private System.Windows.Forms.ToolStripMenuItem btnChangeDownloadLocation;
        private System.Windows.Forms.ToolStripMenuItem btnClearChatBox;
        private System.Windows.Forms.ToolStripMenuItem btnConnections;
        private System.Windows.Forms.ToolStripMenuItem btnDisconnect;
        private System.Windows.Forms.ToolStripMenuItem btnSendFile;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnMinimize;
    }
}

