using System;
using Microsoft.Practices.ObjectBuilder;
using CHAI.LISDashboard.Modules.Shell;
using CHAI.LISDashboard.Shared;
using CHAI.LISDashboard.Enums;

namespace CHAI.LISDashboard.Modules.Shell.Views
{
    public partial class RMessageBox : BaseMessageControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindMessage();
        }

        public void BindMessage()
        {
           // this.imgIcon.ImageUrl = Message.IconFileName;
            this.ltrMessage.Text = Message.MessageText;

            if (Message.MessageType == RMessageType.Info)
                this.panMessage.Attributes.Add("class", "alert alert-success fade in");
            else
                this.panMessage.Attributes.Add("class", "alert alert-danger fade in");
        }
    }
}

