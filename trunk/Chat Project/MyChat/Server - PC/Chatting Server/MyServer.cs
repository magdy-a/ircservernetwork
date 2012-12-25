using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace Chatting
{
    public partial class MyServer : Form,IChatSever
    {
        byte[] data;
        int msSizeRcvd;

        Socket Server, Client;
        IPEndPoint ClientIP;

        MyData receiveHandler, sendHandler;

        string MessageToRepresent;

        AsyncCallback AsyncOnAccept, AsyncOnReceive, AsyncOnSend;

        Point lastLocation;

        #region Form

        public MyServer()
        {
            // Form Position
            this.StartPosition = FormStartPosition.Manual;
            this.SetBounds((Screen.AllScreens[0].Bounds.Width / 3) - (this.Width), Screen.AllScreens[0].Bounds.Height / 4, this.Width, this.Height);
            InitializeComponent();

            // Form Controls
            this.btnDisconnect.Enabled = false;
            this.btnSendFile.Enabled = false;
            this.txtMessage.Enabled = false;
        }

        private void WIFI_PWM_Controller_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            AsyncOnAccept = new AsyncCallback(OnAccept);
            AsyncOnReceive = new AsyncCallback(OnReceive);
            AsyncOnSend = new AsyncCallback(OnSend);

            receiveHandler = new MyData();
            msSizeRcvd = 0;
            data = new byte[ChatMaster.ReceiveBufferLength];

            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ClientIP = new IPEndPoint(IPAddress.Any, ChatMaster.Port);
            Server.Bind(ClientIP);
            Server.Listen(100);

            try
            {
                Server.BeginAccept(AsyncOnAccept, null);
            }
            catch
            {
                //MessageBox.Show("Failed to BeginAccept");
            }

            ChatMaster.SetStartUpData();
        }

        private void WIFI_PWM_Controller_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Wireless
                if (Server != null)
                    Server.Close();
                if (Client != null)
                    Client.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        #endregion

        public void OnReceive(IAsyncResult ar)
        {
            try
            {
                msSizeRcvd = Client.EndReceive(ar);

                if (msSizeRcvd == 0)
                {
                    btnDisconnect_Click(null, null);
                }
                else
                {
                    receiveHandler.AddRange(data.Take(msSizeRcvd).ToList());

                    txtMessage.Invoke(new GoToThread(handleReceivedData));
                }
            }
            catch
            {
                if (txtMessage.InvokeRequired)
                    txtMessage.Invoke(new GoToThread(DisconnectEvents));
                else
                    DisconnectEvents();

                try
                {
                    Client.Shutdown(SocketShutdown.Both);
                    Client.Close();
                }
                catch
                {
                }

                return;//Neglect the BeginLoogReceive, cause it will crash too
            }

            try
            {
                Client.BeginReceive(data, 0, data.Length, SocketFlags.None, AsyncOnReceive, null);
            }
            catch
            {
            }
        }

        private void handleReceivedData()
        {
            MessageToRepresent = "";

            if (receiveHandler.CompletedMessages.Count > 0)
            {
                foreach (MyData Comp in receiveHandler.CompletedMessages)
                {
                    if (Comp.Type == MessageType.StrMessage)
                    {
                        MessageToRepresent = ((MyStrMessage)Comp).StrMessage;
                    }
                    else if (Comp.Type == MessageType.File)
                    {
                        MessageToRepresent = "IncomingFile: " + ((MyFile)Comp).Name;
                        ((MyFile)Comp).SaveFile();

                        if (((MyFile)Comp).Status == FileStatus.CompleteAndSaved)
                            MessageToRepresent += " Saved";
                        else
                            MessageToRepresent += " NotSaved";
                    }

                    ChatMaster.AddSomeText(rtxtChatBox, "\r\nHim(" + DateTime.Now.ToLongTimeString() + "): " + MessageToRepresent);
                }

                receiveHandler.CompletedMessages.Clear();

                TopMost = true;
                TopMost = false;
            }

            //data = new byte[ReceiveBufferLength];

            ChatMaster.CollectGarbage();
        }

        #region Wireless :: Connection

        public void OnAccept(IAsyncResult ar)
        {
            try
            {
                Client = Server.EndAccept(ar);

                txtMessage.Invoke(new GoToThread(ConnectEvents));
            }
            catch
            {
            }

            try
            {
                Server.BeginAccept(AsyncOnAccept, null); // Multiple Accepts have't yet activated
            }
            catch
            {
            }

            try
            {
                Client.BeginReceive(data, 0, data.Length, SocketFlags.None, AsyncOnReceive, null);
            }
            catch
            {
            }
        }

        public void OnSend(IAsyncResult ar)
        {
            try
            {
                Client.EndSend(ar);
            }
            catch
            {
            }
        }

        #endregion

        #region Wireless :: Controls

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string StrMessage = txtMessage.Text;

                if (StrMessage == "")
                    return;

                sendHandler = new MyStrMessage(StrMessage);

                ChatMaster.AddSomeText(rtxtChatBox, "\r\nMe(" + DateTime.Now.ToLongTimeString() + "): " + txtMessage.Text);

                txtMessage.Text = "";

                if (Client != null && Client.Connected)
                    try
                    {
                        Client.BeginSend(((MyStrMessage)sendHandler).Message.ToArray(), 0, ((MyStrMessage)sendHandler).Message.Count, SocketFlags.None, AsyncOnSend, null);
                    }
                    catch
                    {
                        //MessageBox.Show("Failed to Send the Message");
                    }

                sendHandler = null;

                ChatMaster.CollectGarbage();
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (Client == null || Client.Connected == false)
                return;

            OpenFileDialog FileOpen = new OpenFileDialog();

            if (FileOpen.ShowDialog() == DialogResult.OK)
            {
                SendMyFile(FileOpen.FileName);
            }
        }

        private void SendMyFile(string filePath)
        {
            //Start the Handler
            sendHandler = new MyFile(filePath);

            if (Client != null && Client.Connected)
                try
                {
                    Client.BeginSend(((MyFile)sendHandler).Message.ToArray(), 0, ((MyFile)sendHandler).Message.Count, SocketFlags.None, AsyncOnSend, null);
                }
                catch
                {
                    //MessageBox.Show("Failed to send the File");
                }

            //ChatMaster.AddSomeText(rtxtChatBox, "\r\nMe(" + DateTime.Now.ToLongTimeString() + ") Sending File: " + ((MyFile)sendHandler).Name + " ...");

            //((MyFile)sendHandler).SendFile(Client, AsyncOnSend);

            ChatMaster.AddSomeText(rtxtChatBox, "\r\nMe(" + DateTime.Now.ToLongTimeString() + ") File Sent: " + ((MyFile)sendHandler).Name);

            //sendHandler = null;

            //ChatMaster.CollectGarbage();
        }


        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                //Client.Disconnect(true);

                if (Client != null)
                    Client.Close();

                //The rest of Disconnect actions will happen in OnReceive Function, cause it will enter it after Closing the Socket and will Crash in the EndReceive() Function, Then will do the action stated in the Catch
            }
            catch
            {
                //MessageBox.Show("Failed to close the Server");
            }
        }

        private void btnClearChatBox_Click(object sender, EventArgs e)
        {
            rtxtChatBox.Clear();
        }

        private void DownloadLocation_Click(object sender, EventArgs e)
        {
            ChatMaster.ChangeDownloadLocation();
        }


        private void ConnectEvents()
        {
            txtMessage.Enabled = true;
            btnDisconnect.Enabled = true;
            btnSendFile.Enabled = true;

            ChatMaster.AddSomeText(rtxtChatBox, "\r\nConnected ... " + DateTime.Now.ToString());
        }

        private void DisconnectEvents()
        {
            txtMessage.Enabled = false;
            btnSendFile.Enabled = false;

            sendHandler = null;

            ChatMaster.AddSomeText(rtxtChatBox, "\r\nDisconnected ... " + DateTime.Now.ToString());
        }

        #endregion

        delegate void GoToThread();

        private void MyServer_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void MyServer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            Location = new Point(Location.X + e.X - lastLocation.X, Location.Y + e.Y - lastLocation.Y);
        }

        private void MyServer_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void MyServer_DragDrop(object sender, DragEventArgs e)
        {
            if (Client == null || Client.Connected == false)
            {
                return;
            }

            foreach (string s in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                SendMyFile(s);

                Thread.Sleep(sendHandler.Length / 100000);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}