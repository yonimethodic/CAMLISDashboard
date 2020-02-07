using System;
using System.Collections.Generic;
using CHAI.LISDashboard.Enums;

namespace CHAI.LISDashboard.Shared.Events
{
    public class MessageEventArgs : EventArgs
    {
        private AppMessage _message;
        public MessageEventArgs(AppMessage message)
        {
            _message = message;
        }

        public MessageEventArgs(string msg, RMessageType mtype)
        {
            _message = new AppMessage(msg, mtype);
        }

        public AppMessage Message
        {
            get { return _message; }
        }
    }
}
