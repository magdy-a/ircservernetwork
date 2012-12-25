using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chatting
{
    public interface IChat
    {
        void OnReceive(IAsyncResult ar);
        void OnSend(IAsyncResult ar);
    }

    public interface IChatSever :IChat
    {
        void OnAccept(IAsyncResult ar);
    }

    public interface IChatClient
    {
        void OnConnect(IAsyncResult ar);
    }
}
