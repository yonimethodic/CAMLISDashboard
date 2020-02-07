using System;
using System.Web.UI;
using Microsoft.Practices.CompositeWeb;
using Microsoft.Practices.CompositeWeb.Interfaces;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb.Web;

using CHAI.LISDashboard.Shared.Events;
using CHAI.LISDashboard.Shared;
using CHAI.LISDashboard.Modules.Shell.MasterPages;
using CHAI.LISDashboard.CoreDomain.Users;
using System.Security.Cryptography;
//using RSACryptography;

namespace CHAI.LISDashboard.Modules.Shell
{
    public class BaseMaster : Microsoft.Practices.CompositeWeb.Web.UI.MasterPage, IBaseMasterView
    {
        public delegate void MessageEventHandler(object sender, MessageEventArgs e);
        public event MessageEventHandler Message;
        private BaseMasterPresenter _presenter;
        public AppUser CurrentUser;
        public BaseMaster()
        {
            
           
            //if (Presenter.CurrentUser == null)
                //Presenter.Navigate("~/UserLogin.aspx");
            //}
            //else if (!Presenter.UserIsAuthenticated)
            //{
                //Presenter.Navigate("~/UserLogin.aspx");
            //}
        }
        
        [CreateNew]
        public BaseMasterPresenter Presenter
        {
            get
            {
                return this._presenter;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                this._presenter = value;
                this._presenter.View = this;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMessage(MessageEventArgs e)
        {
            if (Message != null)
            {
                Message(this, e);
            }
        }
       
        public string TabId
        {
            get {

                //RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
                //string s = Request.QueryString.ToString();
                //string decryptedQueryString = string.Empty;
                //if (!string.IsNullOrEmpty(Request.QueryString.ToString()) && Request.QueryString.ToString().Length >= 127)
                //{
                //    //decryptedQueryString = Crypto1.RSA.Decrypt(Request.QueryString.ToString(), rsaProvider.ToXmlString(true), 1024);
                //    decryptedQueryString = CryptographyHelper1.Decrypt(Request.QueryString.ToString());
                //}
                //string encryptedUsRL = Crypto.RSA.Encrypt(string.Format("{0}=0", AppConstants.TABID),
                //    rsaProvider.ToXmlString(true), 1024);

                //hpl.NavigateUrl = this.Page.ResolveUrl(String.Format("~/Default.aspx?{0}", encryptedURL));

                return Request.QueryString[AppConstants.TABID];
            }
        }
        public string NodeId
        {
            get { return Request.QueryString[AppConstants.NODEID]; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>     
        public void ShowMessage(CHAI.LISDashboard.Shared.AppMessage message)
        {
            MessageEventArgs e = new MessageEventArgs(message);
            OnMessage(e);
        }

        public void TransferMessage(CHAI.LISDashboard.Shared.AppMessage message)
        {
            this.GetRMessaage = message;
        }
        
        protected void CheckTransferdMessage()
        {
            object msgObject =  GetRMessaage;
            if (msgObject != null && (msgObject is CHAI.LISDashboard.Shared.AppMessage))
            {
                ShowMessage((CHAI.LISDashboard.Shared.AppMessage)msgObject);
                this.GetRMessaage = null;
            }
        }

        private object GetRMessaage
        {
            get
            {
                return Presenter.CurrentContext.Session["RMESSAGE"];
            }
            set
            {
                Presenter.CurrentContext.Session["RMESSAGE"] = value;
            }
 
        }



        AppUser IBaseMasterView.CurrentUser
        {
            get
            {
                return CurrentUser;
            }
            set
            {
                CurrentUser = value;
            }
        }
    }
    
}
