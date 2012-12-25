using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Chatting
{
    public static class ChatMaster
    {

        /// <summary>
        /// The default bufferSize to use, just for controlling
        /// </summary>
        private static int receiveBufferLength = 5000000;

        /// <summary>
        /// Port Number Used in this Chat Application
        /// </summary>
        private static int port = 8000;

        /// <summary>
        /// The TmpFolder for ReceivedFiles
        /// </summary>
        private static string downloadLocation = "C:\\Chatting Folder";

        /// <summary>
        /// LogFile Location
        /// </summary>
        private static string SaveLogFilePath = "Log_Version_1.txt";

        /// <summary>
        /// States if Log is Saved or not
        /// </summary>
        private static bool LogIsSaved = true;


        /// <summary>
        /// The default bufferSize to use, just for controlling
        /// </summary>
        public static int ReceiveBufferLength
        {
            set { receiveBufferLength = value; }
            get { return receiveBufferLength; }
        }

        /// <summary>
        /// The Location of this program files
        /// </summary>
        public static string ProgramFilesLocation
        {
            get { return "C:\\Program Files\\Chatting Application"; }
        }

        /// <summary>
        /// Location to a .txt file in a specified Folder in ProgramFiles, that carries Important Information for Program StartUp
        /// </summary>
        public static string StartUpDataFileLocation
        {
            get { return ProgramFilesLocation + "\\" + "StartUpData.txt"; }
        }

        /// <summary>
        /// TmpLocation, used to save incomingFiles in it, until it is complete, and moved to other location
        /// </summary>
        public static string DownloadLocation
        {
            set
            {
                if (downloadLocation == value)
                    return;

                if (!Directory.Exists(value))
                    Directory.CreateDirectory(value);

                downloadLocation = value;
            }

            get { return downloadLocation; }
        }

        /// <summary>
        /// Port Number Used By this Chatting Application
        /// </summary>
        public static int Port
        {
            get { return port; }
        }

        /// <summary>
        /// Collects the garbage from the Thread this function was called from
        /// </summary>
        public static void CollectGarbage()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.WaitForFullGCComplete();
        }

        /// <summary>
        /// Add Some Text to a RichTextBox, then refreshes it
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="words"></param>
        public static void AddSomeText(RichTextBox txt, string words)
        {
            txt.Text += words;
            txt.SelectionStart = txt.TextLength;
            txt.SelectionLength = 0;
            txt.ScrollToCaret();
        }

        /// <summary>
        /// Saves the Log in a prespecified Location
        /// </summary>
        public static void SaveLog(object sender, EventArgs e)
        {
            if (LogIsSaved)
                return;

            string Log = "";

            FileStream FS;

            try
            {
                FS = new FileStream(SaveLogFilePath, FileMode.Append);
            }
            catch (Exception ex)
            {
                try
                {
                    MessageBox.Show("Failed to Open File \r\n" + ex.Message);

                    OpenFileDialog OpenFile = new OpenFileDialog();

                    if (OpenFile.ShowDialog() == DialogResult.OK)
                    {
                        SaveLogFilePath = OpenFile.FileName;
                    }

                    FS = new FileStream(SaveLogFilePath, FileMode.Append);
                }
                catch (Exception anotherEx)
                {
                    MessageBox.Show("Failed to handle the error, Will create file in C: Drive\r\n" + anotherEx.Message);
                    FS = new FileStream("C:\\GumstixLatencyTest__At_" + DateTime.Now.Second + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt", FileMode.Append);
                }
            }

            byte[] LogBytes = Encoding.ASCII.GetBytes(Log);

            try
            {
                FS.Write(LogBytes, 0, LogBytes.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to write to File\r\n" + ex.Message);
            }

            try
            {
                FS.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to close the file\r\n" + ex.Message);
            }

            LogIsSaved = true;
        }

        public static void ChangeDownloadLocation()
        {
            FolderBrowserDialog FB = new FolderBrowserDialog();
            if (FB.ShowDialog() == DialogResult.OK)
            {
                ChatMaster.DownloadLocation = FB.SelectedPath;
                File.Delete(ChatMaster.StartUpDataFileLocation);
                File.WriteAllText(ChatMaster.StartUpDataFileLocation, ChatMaster.DownloadLocation);
            }
        }

        /// <summary>
        /// Create the program Folder in ProgramFiles, Set StartUp Data
        /// </summary>
        public static void SetStartUpData()
        {
            if (!Directory.Exists(ChatMaster.ProgramFilesLocation))
            {
                Directory.CreateDirectory(ChatMaster.ProgramFilesLocation);
            }

            if (!File.Exists(ChatMaster.StartUpDataFileLocation))
            {
                File.WriteAllText(ChatMaster.StartUpDataFileLocation, ChatMaster.DownloadLocation);
            }
            else
            {
                string DLocation = File.ReadAllText(ChatMaster.StartUpDataFileLocation);

                if (ChatMaster.DownloadLocation != DLocation)
                {
                    ChatMaster.DownloadLocation = DLocation;
                }
            }
        }
    }
}
