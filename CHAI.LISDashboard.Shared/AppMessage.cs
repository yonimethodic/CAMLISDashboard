using System;
using System.Collections.Generic;
using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.Shared.Settings;

namespace CHAI.LISDashboard.Shared
{
    public class AppMessage
    {
        private string _messageText;
        private RMessageType _messageType;

        public AppMessage(string message, RMessageType mtype)
        {
            _messageText = message;
            _messageType = mtype;
        }

        private AppMessage()
        {
        }

        public string MessageText
        {
            get { return _messageText; }
        }

        public RMessageType MessageType
        {
            get { return _messageType; }
        }

        public string IconFileName
        {
            get
            {
                return String.Format(UserSettings.GetMessageIcon, _messageType);
            }
        }
    }
}
