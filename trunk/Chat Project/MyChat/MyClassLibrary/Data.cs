using System;
using System.Collections.Generic;

namespace Chatting
{
    public class MyData
    {
        /*  Old File:            (1-Byte = MessageType)(128-Bytes = FileName)(4-Bytes = FileLength)(FileLength = File) */
        /*  Old StrMessage:      (1-Byte = MessageType)(4-Bytes = StrMessageLength)(StrMessageLength = StrMessage)     */

        /*  New File:            (1-Byte = MessageType)(4-Bytes = MessageLength)(    (4-Bytes = FileNameLength)(FileNameLength = FileName)(4-Bytes = FileLength)(FileLength = File)   )  */
        /*  New StrMessage:      (1-Byte = MessageType)(4-Bytes = MessageLength)(MessageLength = StrMessage)                                                                             */

        /*  Very New File:            (4-Bytes = MessageType)(4-Bytes = MessageLength)(    (4-Bytes = FileNameLength)(FileNameLength = FileName)(4-Bytes = FileLength)(FileLength = File)   )  */
        /*  Very New StrMessage:      (4-Bytes = MessageType)(4-Bytes = MessageLength)(MessageLength = StrMessage)                                                                             */

        //  Now I listen here for the MessageType & MessageLength, then I'll give the Handler to each Object throw the AddRange Virtual Function, so rewrite each Class to handle it's own data

        #region Attributes

        /// <summary>
        /// ByteArr, Main Content of the Message
        /// </summary>
        protected List<byte> message;

        /// <summary>
        /// Length of the Message
        /// </summary>
        protected int length;

        /// <summary>
        /// Current Part of the encoded file being processed
        /// </summary>
        private MessagePart currentMessagePart;

        /// <summary>
        /// The number of bytes I should read once, to understand MessageEncrypting
        /// </summary>
        protected int minimumLengthToEnter;

        /// <summary>
        /// The type of the Message I am receiving right now
        /// </summary>
        private MessageType type;

        /// <summary>
        /// A tmp Message for IncomingData
        /// </summary>
        private MyData tmpMessage;

        /// <summary>
        /// Messages that arrived sucessfully
        /// </summary>
        private List<MyData> completedMessages;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// The type of this Message
        /// </summary>
        public virtual MessageType Type
        {
            get { return type; }
        }

        /// <summary>
        /// ByteArr MainContent of the Message
        /// </summary>
        public List<byte> Message
        {
            get { return message; }
        }

        /// <summary>
        /// Messages that arrived sucessfully
        /// </summary>
        public List<MyData> CompletedMessages
        {
            get { return completedMessages; }
        }

        /// <summary>
        /// Length of the Message
        /// </summary>
        public int Length
        {
            get { return length; }
        }

        /// <summary>
        /// Integer Length in Bytes, Exists in Encoded Messages
        /// </summary>
        protected static int L_IntLength
        {
            get { return 4; }
        }

        #endregion Properties

        #region Consturctors

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public MyData()
        {
            message = new List<byte>();
            completedMessages = new List<MyData>();

            // Start with clear values
            resetCounter();
        }

        #endregion Consturctors

        #region Virtual Functions

        /// <summary>
        /// Add a new Range of arrived Bytes, to understand and decrypt it
        /// </summary>
        /// <param name="incomingBytes">ByteArr contains the IncomingBytes</param>
        public virtual void AddRange(List<byte> incomingBytes)
        {
            //  I am tracking the Messages using two Vars, (CurrentMessagePart & Type), with these Var, I can decide the nextNeededBytes
            message.AddRange(incomingBytes);

            while (minimumLengthToEnter <= message.Count)
            {
                if (message.Count == 0)
                    break;

                switch (currentMessagePart) //  Switch for the Part of the Message
                {
                    case MessagePart.Code:      // If new Message, Create one

                        // Set the nextMessagePart to Length
                        currentMessagePart = MessagePart.Length;

                        // Next Needed Bytes are for the Message Length (4bytes)
                        minimumLengthToEnter = L_IntLength;

                        //  Create New Object & Set the MessageType the Command of the IncomingBytes
                        type = CreateNewObject(getCommand(incomingBytes));

                        //  Remove the first Int (the 4-Bytes I just read)
                        message.RemoveRange(0, L_IntLength);

                        break;
                    case MessagePart.Length:    //  If Length, the length should be ready, cause I restrict it in the while up there

                        //  If Length isn't ready yet, wait ...
                        if (message.Count < L_IntLength)
                            return;

                        //  Get Message Length, then remove it from the BigBuffer, then Remove it
                        length = BitConverter.ToInt32(message.GetRange(0, L_IntLength).ToArray(), 0);
                        message.RemoveRange(0, L_IntLength);

                        if (type == MessageType.StrMessage)
                            tmpMessage.length = length;

                        //  Check for MessageCompleteness
                        if (length == 0)
                            MessageIsComplete();
                        else
                        {
                            currentMessagePart = MessagePart.Message;
                            minimumLengthToEnter = 0;
                        }

                        break;
                    case MessagePart.Message:

                        //  Not all bytes availabe
                        if (length > message.Count)
                        {
                            AddObjectRange(message, type);
                            length -= message.Count;
                            message.Clear();
                        }
                        else//  Elsif all bytes are available
                        {
                            AddObjectRange(message.GetRange(0, length), type);
                            message.RemoveRange(0, length);
                            length = 0;

                            MessageIsComplete();
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Encrypts the Message, in the same ByteArr
        /// </summary>
        public virtual void Encrypt()
        {
        }

        /// <summary>
        /// Adds the Message to the CompletedMessages List
        /// </summary>
        protected virtual void MessageIsComplete()
        {
            tmpMessage.MessageIsComplete();

            completedMessages.Add(tmpMessage);

            // Reset the Counters
            resetCounter();
        }

        #endregion Virtual Functions

        #region Helping Functions

        /// <summary>
        /// Resets the Counters of this Object
        /// </summary>
        private void resetCounter()
        {
            // Set the current MessagePart to MessageType
            currentMessagePart = MessagePart.Code;

            // Set MessageType to nothing
            type = MessageType.Nothing;

            // Set min length of byte to enter to the length of messageType in bytes
            minimumLengthToEnter = L_IntLength;
        }

        /// <summary>
        /// Intiates the tmpMessage Object to the Type in mType
        /// </summary>
        /// <param name="mType">Type to set the object to</param>
        /// <returns>It returns the same parameter mType, to use it is setting the another object in one line (if needed)</returns>
        private MessageType CreateNewObject(MessageType mType)
        {
            if (tmpMessage != null)
                tmpMessage = null;

            switch (mType)
            {
                case MessageType.Login:
                    throw new NotImplementedException();
                case MessageType.Logout:
                    throw new NotImplementedException();
                case MessageType.ClientList:
                    throw new NotImplementedException();
                case MessageType.StrMessage:
                    tmpMessage = new MyStrMessage();
                    break;
                case MessageType.File:
                    tmpMessage = new MyFile();
                    break;
            }

            return mType;
        }

        /// <summary>
        /// Add some bytes to the tmpMessage Object, but in a certain Type
        /// </summary>
        /// <param name="range">List of Bytes to Add</byte></param>
        /// <param name="mType">Type to Cast the Object to</param>
        private void AddObjectRange(List<byte> range, MessageType mType)
        {
            switch (mType)
            {
                case MessageType.Login:
                    throw new NotImplementedException();
                case MessageType.Logout:
                    throw new NotImplementedException();
                case MessageType.ClientList:
                    throw new NotImplementedException();
                case MessageType.StrMessage:
                    ((MyStrMessage)tmpMessage).AddRange(message);
                    break;
                case MessageType.File:
                    ((MyFile)tmpMessage).AddRange(message);
                    break;
                default:
                    throw new Exception("SomeThing !! is going wrong in decrypting the received part");
            }
        }

        /// <summary>
        /// Decrpts the Type of this Message
        /// </summary>
        /// <param name="number">The number of the value in MessageType</param>
        /// <returns>MessageType value</returns>
        public static MessageType getCommand(int number)
        {
            return (MessageType)number;
        }

        /// <summary>
        /// Decrpts the Type of this Message
        /// </summary>
        /// <param name="MyMessage">Byte Arr, first 4 bytes hold the int of MessagePart</param>
        /// <returns>MessagePart value</returns>
        public static MessageType getCommand(byte[] MyMessage)
        {
            return (MessageType)BitConverter.ToInt32(MyMessage, 0);
        }

        /// <summary>
        /// Decrpts the Type of this Message
        /// </summary>
        /// <param name="MyMessage">Byte Arr, first 4 bytes hold the int of MessagePart</param>
        /// <returns>MessagePart value</returns>
        public static MessageType getCommand(List<byte> MyMessage)
        {
            return (MessageType)BitConverter.ToInt32(MyMessage.GetRange(0, L_IntLength).ToArray(), 0);
        }

        /// <summary>
        /// Encrypts the Type of this Message
        /// </summary>
        /// <param name="mType">MessagePart value</param>
        /// <returns>Byte Arr, 4 bytes hold the int of MessagePart</returns>
        public static byte[] getCommand(MessageType mType)
        {
            return BitConverter.GetBytes((int)mType);
        }

        #endregion Helping Functions
    }

    public enum MessageType
    {
        /// <summary>
        /// LoginMessage, with it's Data
        /// </summary>
        Login,
        /// <summary>
        /// LogoutMessage
        /// </summary>
        Logout,
        /// <summary>
        /// ClientList in the Server
        /// </summary>
        ClientList,
        /// <summary>
        /// StringMessage to be represented
        /// </summary>
        StrMessage,
        /// <summary>
        /// File to be saved
        /// </summary>
        File,
        /// <summary>
        /// MessageType is Unknown
        /// </summary>
        Nothing
    }

    public enum MessagePart
    {
        /// <summary>
        /// The Code of the Message, ex: codeFile, codeStrMessage
        /// </summary>
        Code,
        /// <summary>
        /// The Length of the Message
        /// </summary>
        Length,
        /// <summary>
        /// The Message itself, if a File or a StrMessage
        /// </summary>
        Message,
    }
}