using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Chatting
{
    public class MyFile : MyData
    {
        /*  (4-Bytes = MessageType)(4-Bytes = MessageLength)(    (4-Bytes = FileNameLength)(FileNameLength = FileName)(4-Bytes = FileLength)(FileLength = File)   )  */

        #region Attributes

        /// <summary>
        /// Path of the File
        /// </summary>
        protected string path;

        /// <summary>
        /// Status of the File
        /// </summary>
        protected FileStatus status;
        
        /// <summary>
        /// The Part
        /// </summary>
        protected FilePart currentFilePart;

        /// <summary>
        /// FileStream that reads and writes my files
        /// </summary>
        protected FileStream FS;

        #endregion

        #region Properties

        /// <summary>
        /// Gets Type of this Message
        /// </summary>
        public override MessageType Type
        {
            get { return MessageType.File; }
        }

        /// <summary>
        /// Gets the Status of the File
        /// </summary>
        public FileStatus Status
        {
            get { return status; }
        }

        /// <summary>
        /// Gets the Path of the File
        /// </summary>
        public string Path
        {
            get { return path; }
        }

        /// <summary>
        /// Gets the Name of the File
        /// </summary>
        public string Name
        {
            get { return System.IO.Path.GetFileName(path); }
        }

        /// <summary>
        /// Gets the File Name without the Extension
        /// </summary>
        public string AbstractName
        {
            get { return System.IO.Path.GetFileNameWithoutExtension(path); }
        }

        /// <summary>
        /// Gets the Extension of the File
        /// </summary>
        public string Extension
        {
            get { return System.IO.Path.GetExtension(path); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public MyFile()
        {
            status = FileStatus.Empty;

            currentFilePart = FilePart.NameLength;
            minimumLengthToEnter = L_IntLength;

            this.message = new List<byte>();
            length = 0;

            path = "";

            if (!Directory.Exists(ChatMaster.DownloadLocation))
            {
                Directory.CreateDirectory(ChatMaster.DownloadLocation);
            }
        }

        /// <summary>
        /// Constructor for a file Encrypting, with the ByteArr of the File and the FileName
        /// </summary>
        /// <param name="file">Bytes of the File</param>
        /// <param name="fileName">FileName (with extension), used in saving the file</param>
        public MyFile(byte[] file, string fileName)
        {
            status = FileStatus.Empty;

            message = file.ToList();

            length = file.Length;

            path = fileName;

            status = FileStatus.CompleteAndNotSaved;

            Encrypt();
        }

        /// <summary>
        /// Constructor for a file Encrypting, with the FilePath
        /// </summary>
        /// <param name="filePath">The path of the file</param>
        public MyFile(string filePath)
        {
            message = new List<byte>();

            path = filePath;

            status = FileStatus.Empty;

            try
            {
                FS = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Read the File, Make sure the path exists\r\n\"Error Message: " + ex.Message + "\"");
                status = FileStatus.Corrupted;
                return;
            }

            length = (int)FS.Length;

            status = FileStatus.InComplete;

            Encrypt();

            byte[] file;

            try
            {
                FS = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                length = (int)FS.Length;

                file = new byte[Length];

                //Read the File
                FS.Read(file, 0, file.Length);

                //  Set the Message by the Bytes of the File, then'll add the messageProperties in their coorect position
                message.AddRange(file.ToList());

                FS.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Read the File, Make sure the path exists\r\n\"Error Message: " + ex.Message + "\"");
                status = FileStatus.Corrupted;
                return;
            }
        }

        #endregion

        #region Overrided Functions

        /// <summary>
        /// Add a new Range of arrived FileBytes , to add it to the filePath in tmpFolder
        /// </summary>
        /// <param name="incomingBytes">ByteArr contains the IncomingBytes</param>
        public override void AddRange(List<byte> incomingBytes)
        {

            message.AddRange(incomingBytes);

            while (minimumLengthToEnter <= message.Count)
            {

                if (message.Count == 0)
                    break;

                switch (currentFilePart)
                {
                    case FilePart.NameLength:

                        length = BitConverter.ToInt32(message.GetRange(0, L_IntLength).ToArray(), 0);

                        currentFilePart = FilePart.Name;
                        minimumLengthToEnter = length;

                        message.RemoveRange(0,L_IntLength);

                        break;
                    case FilePart.Name:

                        path = ChatMaster.DownloadLocation + "\\" + Encoding.ASCII.GetString(message.GetRange(0, length).ToArray(), 0, length);

                        currentFilePart = FilePart.FileLength;
                        minimumLengthToEnter = L_IntLength;

                        message.RemoveRange(0, length);

                        while (File.Exists(path))
                        {
                            path = path.Insert(path.Length - Name.Length, "t");
                        }

                        //  Open the FileStream, I'll write any arrived part of the File, until the File is complete, then I'll Close it, once the file is complete
                        FS = new FileStream(path, FileMode.Create);

                        status = FileStatus.InComplete;

                        break;
                    case FilePart.FileLength:

                        length = BitConverter.ToInt32(message.GetRange(0, L_IntLength).ToArray(), 0);

                        currentFilePart = FilePart.File;
                        minimumLengthToEnter = 0;

                        message.RemoveRange(0, L_IntLength);

                        break;
                    case FilePart.File:

                        FS.Write(message.ToArray(), 0, message.Count);

                        message.Clear();

                        break;
                }
            }
        }

        /// <summary>
        /// Closes the FileStream, Sets the FileStatus
        /// </summary>
        protected override void MessageIsComplete()
        {
            FS.Close();
            status = FileStatus.CompleteAndNotSaved;
        }

        /// <summary>
        /// Encrypt the ByteArr Message as a File
        /// </summary>
        public override void Encrypt()
        {
            //Add Type
            message.AddRange(getCommand(MessageType.File));

            //Add Message_Length(NameLength(Int) + Name + FileLength(Int) + File)
            message.AddRange(BitConverter.GetBytes(L_IntLength + Name.Length + L_IntLength + length));

            //Add File_Name_Length
            message.AddRange(BitConverter.GetBytes(Name.Length));

            //Add File_Name
            message.AddRange(Encoding.ASCII.GetBytes(Name));

            //Add File_Length
            message.AddRange(BitConverter.GetBytes(length));
        }

        #endregion

        #region Helping Functions

        public void SendFile(Socket Soc,AsyncCallback Async)
        {
            int tmpLength = length;
            byte[] FPart;

            try
            {
                if (FS == null || !FS.CanRead)
                {
                    FS = new FileStream(path, FileMode.Open);
                }
            }
            catch
            {
                throw new NotImplementedException();
            }

            while (tmpLength > 0)
            {
                if (tmpLength >= ChatMaster.ReceiveBufferLength)
                    FPart = new byte[ChatMaster.ReceiveBufferLength];
                else
                    FPart = new byte[tmpLength];

                FS.Read(FPart, 0, FPart.Length);

                Soc.BeginSend(FPart, 0, FPart.Length, SocketFlags.None, Async, null);

                tmpLength -= FPart.Length;

                ChatMaster.CollectGarbage();
            }

            FS.Close();
        }

        /// <summary>
        /// Saves the file, if the file is complete
        /// </summary>
        public void SaveFile()
        {
            if (status != FileStatus.CompleteAndNotSaved)
                return;

                status = FileStatus.CompleteAndSaved;
        }

        /// <summary>
        /// Saves the file, if the file is complete
        /// </summary>
        /// <param name="filePath">Prespcified Location to save to</param>
        public void SaveFile(string filePath)
        {
            if (status != FileStatus.CompleteAndNotSaved)
                return;

            try
            {
                File.Copy(path, filePath);

                path = filePath;

                status = FileStatus.CompleteAndSaved;
            }
            catch
            {
            }
        }

        #endregion
    }

    public enum FileStatus
    {
        /// <summary>
        /// File is Empty
        /// </summary>
        Empty,
        /// <summary>
        /// File is Complete; File saved succesfully
        /// </summary>
        CompleteAndSaved,
        /// <summary>
        /// File is Complete; File isnt' saved yet
        /// </summary>
        CompleteAndNotSaved,
        /// <summary>
        /// File is InComplete
        /// </summary>
        InComplete,
        /// <summary>
        /// File is Corrupted
        /// </summary>
        Corrupted
    }

    public enum FilePart
    {
        /// <summary>
        /// The Length of the Name
        /// </summary>
        NameLength,
        /// <summary>
        /// The Name of the File
        /// </summary>
        Name,
        /// <summary>
        /// The Length of the File
        /// </summary>
        FileLength,
        /// <summary>
        /// The Bytes of the File
        /// </summary>
        File
    }
}