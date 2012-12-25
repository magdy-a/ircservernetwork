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
using System.Threading;
using System.IO;

namespace Chatting
{
    public partial class MyClient : Form,IChatClient
    {
        byte[] data;
        int msSizeRcvd;

        Socket Client;
        IPEndPoint ServerIP;

        MyData receiveHandler, sendHandler;

        string MessageToRepresent;

        AsyncCallback AsyncOnConnect, AsyncOnReceive, AsyncOnSend;

        Point lastLocation;
        
        private void WIFI_PWM_Controller_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            AsyncOnConnect = new AsyncCallback(OnConnect);
            AsyncOnReceive = new AsyncCallback(OnReceive);
            AsyncOnSend = new AsyncCallback(OnSend);

            receiveHandler = new MyData();
            msSizeRcvd = 0;
            data = new byte[ChatMaster.ReceiveBufferLength];

            btnConnect_Click(null, null);

            ChatMaster.SetStartUpData();
        }

        #region Form

        public MyClient()
        {
            // Form Position
            this.StartPosition = FormStartPosition.Manual;
            this.SetBounds(Screen.AllScreens[0].Bounds.Width / 2, Screen.AllScreens[0].Bounds.Height / 4, this.Width, this.Height);

            InitializeComponent();

            // Form Controls
            this.btnDisconnect.Enabled = false;
            this.btnSendFile.Enabled = false;
            this.txtMessage.Enabled = false;

            this.txtServerIP.Text = IPAddress.Loopback.ToString();
        }


        private void WIFI_PWM_Controller_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Wireless
                if (Client != null)
                    Client.Close();

                //Client.BeginDisconnect(false, new AsyncCallback(OnDisconnect), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void OnReceive(IAsyncResult ar)
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

                    txtMessage.Invoke(new GoToThread(HandleReceivedData));
                }
            }
            catch
            {
                //Disconnect

                try
                {
                    if (txtMessage.InvokeRequired)
                        txtMessage.Invoke(new GoToThread(DisconnectEvents));
                    else
                        DisconnectEvents();
                }
                catch { }

                //if ((ex.SocketErrorCode != SocketError.TimedOut) &&(ex.SocketErrorCode != SocketError.WouldBlock) &&(ex.SocketErrorCode != SocketError.IOPending) &&(ex.SocketErrorCode != SocketError.NoBufferSpaceAvailable)){}
                //else{}

                try
                {
                    Client.Shutdown(SocketShutdown.Both);
                    Client.Close();
                }
                catch
                {
                    Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }

                try
                {
                    Client.BeginConnect(ServerIP, AsyncOnConnect, null);
                }
                catch
                {
                    //MessageBox.Show("Failed to BeginLoopConnect");
                }

                return;//Neglect the BeginLoopReceive, cause it will crash too
            }

            try
            {
                Client.BeginReceive(data, 0, data.Length, SocketFlags.None, AsyncOnReceive, null);
            }
            catch
            {
                //MessageBox.Show("Failed to BeginLoopReceive");
            }
        }

        private void HandleReceivedData()
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

        private void SendMyFile(string filePath)
        {
            //Start the Handler
            sendHandler = new MyFile(filePath);

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

        #region Wireless :: Connection

        public void OnConnect(IAsyncResult ar)
        {
            try
            {
                Client.EndConnect(ar);

                txtMessage.Invoke(new GoToThread(ConnectEvents));
            }
            catch
            {
                try
                {
                    if (Client != null && !Client.Connected)
                        Client.BeginConnect(ServerIP, AsyncOnConnect, null);
                }
                catch
                {
                }
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
                if (txtMessage.Text == "")
                    return;

                sendHandler = new MyStrMessage(txtMessage.Text);

                ChatMaster.AddSomeText(rtxtChatBox, "\r\nMe(" + DateTime.Now.ToLongTimeString() + "): " + txtMessage.Text);

                txtMessage.Text = "";

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


        private void btnConnect_Click(object sender, EventArgs e)
        {
            ServerIP = new IPEndPoint(IPAddress.Parse(txtServerIP.Text), ChatMaster.Port);

            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                Client.BeginConnect(ServerIP, AsyncOnConnect, null);
            }
            catch
            {
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Client != null && Client.Connected)
                {
                    Client.Shutdown(SocketShutdown.Both);
                    Client.Close();
                }
            }
            catch
            {
            }

        }

        
        private void txtServerIP_TextChanged(object sender, EventArgs e)
        {
            IPAddress MyServerIP;

            try
            {
                MyServerIP = IPAddress.Parse(txtServerIP.Text);
            }
            catch
            {
                //MessageBox.Show("This isn't a proper IPAdress format,\r\nPlease enter it again");
                return;
            }

            ServerIP = new IPEndPoint(MyServerIP, ChatMaster.Port);
        }

        private void btnClearChatBox_Click(object sender, EventArgs e)
        {
            rtxtChatBox.Clear();
        }

        private void btnChangeDownloadLocation_Click(object sender, EventArgs e)
        {
            ChatMaster.ChangeDownloadLocation();
        }


        private void ConnectEvents()
        {
            txtMessage.Enabled = true;
            btnDisconnect.Enabled = true;
            btnSendFile.Enabled = true;

            btnConnect.Enabled = false;

            ChatMaster.AddSomeText(rtxtChatBox, "\r\nConnected ... " + DateTime.Now.ToString());
        }

        private void DisconnectEvents()
        {
            txtMessage.Enabled = false;
            btnDisconnect.Enabled = false;
            btnSendFile.Enabled = false;

            btnConnect.Enabled = true;

            sendHandler = null;

            ChatMaster.CollectGarbage();

            ChatMaster.AddSomeText(rtxtChatBox, "\r\nDisconnected ... " + DateTime.Now.ToString());
        }

        #endregion
       
        delegate void GoToThread();

        private void MyClient_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void MyClient_DragDrop(object sender, DragEventArgs e)
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

        private void MyClient_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void MyClient_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            Location = new Point(Location.X + e.X - lastLocation.X, Location.Y + e.Y - lastLocation.Y);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}