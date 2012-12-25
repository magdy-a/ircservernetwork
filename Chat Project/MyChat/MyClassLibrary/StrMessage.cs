using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Chatting
{
    public class MyStrMessage : MyData
    {

        /*  (4-Bytes = MessageType)(4-Bytes = MessageLength)(MessageLength = StrMessage) */

        /// <summary>
        /// The StrMessage which is in the ByteArr
        /// </summary>
        public string StrMessage
        {
            get
            {
                //  In case of EncryptedMessage, if the arr was, the length of bytes + 4bytes for messageType + 4bytes for messageLength
                if (message.Count == length + L_IntLength * 2)
                {
                    return Encoding.ASCII.GetString(message.ToArray(), L_IntLength * 2, (int)length);
                }

                //  else
                return Encoding.ASCII.GetString(message.ToArray(), 0, message.Count);
            }
        }

        /// <summary>
        /// Type of the Message
        /// </summary>
        public override MessageType Type
        {
            get { return MessageType.StrMessage; }
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public MyStrMessage()
        {
            this.message = new List<byte>();
            length = 0;
        }

        /// <summary>
        /// Constructor for a StrMessage Encrypting
        /// </summary>
        /// <param name="message">string Message to be sent</param>
        public MyStrMessage(string StrMessageToSend)
        {
            //  Set the Message by the Bytes of the StrMessage, then'll add the messageProperties in their coorect position
            message = Encoding.ASCII.GetBytes(StrMessageToSend).ToList();
            length = StrMessageToSend.Length;
            Encrypt();
        }

        /// <summary>
        /// Add a new Range of arrived StrMessageBytes , to append it to the arrived Bytes of the Message
        /// </summary>
        /// <param name="incomingBytes">ByteArr contains the IncomingBytes</param>
        public override void AddRange(List<byte> incomingBytes)
        {
            message.AddRange(incomingBytes);
        }

        /// <summary>
        /// DoesNoting
        /// </summary>
        protected override void MessageIsComplete()
        {
            //  Nothing To do here !
        }

        /// <summary>
        /// Encrypt the ByteArr StrMessage as a TextMessage
        /// </summary>
        public override void Encrypt()
        {
            int lastIndex = 0;

            // Add Type
            message.InsertRange(lastIndex, BitConverter.GetBytes((int)MessageType.StrMessage));
            // Add the length of integer
            lastIndex += L_IntLength;

            // Add MessageLength
            message.InsertRange(lastIndex, BitConverter.GetBytes(length));
        }
    }
}
