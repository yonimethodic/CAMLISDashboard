using System;
using Microsoft.Practices.ObjectBuilder;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace CHAI.LISDashboard.Modules.Shell.Views
{
    public partial class UserLogin : Microsoft.Practices.CompositeWeb.Web.UI.Page, IUserLoginView
    {
        private UserLoginPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User != null)
            {
                if (Context.User.Identity.IsAuthenticated)
                    Context.Response.Redirect("~/");
            }

            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
                txtUsername.Focus();
            }
            
            this._presenter.OnViewLoaded();
        }

        [CreateNew]
        public UserLoginPresenter Presenter
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
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Just testing
            //String s = CHAI.LISDashboard.Shared.Encryption.StringToMD5Hash("");
            //Console.WriteLine("!!!!!!!!!!!!!!     " + s);

            if (this.txtUsername.Text.Trim().Length > 0 && this.txtPassword.Text.Trim().Length > 0)
            {
                //try
                //{
                    if (_presenter.AuthenticateUser())
                    {
                        //CHAI.LISDashboard.CoreDomain.Users.AppUser currentUser = _presenter.GetUser(_presenter.CurrentUser.Id);
                        //string s = currentUser.UserName + ", " + currentUser.UserLocations.Count;

                        //_presenter.RedirectToRowUrl();
                        Context.Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        this.lblLoginError.Text = "User name or password incorrect";
                        this.lblLoginError.Visible = true;
                    }
                //}
                //catch (Exception ex)
                //{
                //    this.lblLoginError.Text = ex.Message + " The user may be not active user";
                //    this.lblLoginError.Visible = true;
                //}
            }
            else
            {
                this.lblLoginError.Text = "Please enter both a username and password";
                this.lblLoginError.Visible = true;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string strErr = string.Empty;            
            //lblGroupName.CssClass = "input";           
            //lblGroupEmail.CssClass = "input";
            //lblGroupPhone.CssClass = "input";
            //lblGroupMessage.CssClass = "input";

            if (string.IsNullOrEmpty(txtName.Text))
            {
                //lblGroupName.CssClass = "input state-error";
                strErr += (strErr == string.Empty)? "Please enter Name" : ", Name";

                //this.lblLoginError.Text = "Please enter both a username and password";
                //this.lblLoginError.Visible = true;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                //lblGroupEmail.CssClass = "input state-error";
                strErr += (strErr == string.Empty) ? "Please enter Email" : ", Email";
            }            

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                //lblGroupPhone.CssClass = "input state-error";
                strErr += (strErr == string.Empty) ? "Please enter Phone" : ", Phone";
            }
            if (string.IsNullOrEmpty(txtSubject.Text))
            {
                //lblSubject.CssClass = "input state-error";
                strErr += (strErr == string.Empty) ? "Please enter Subject" : ", Subject";
            }
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                //lblGroupMessage.CssClass = "input state-error";
                strErr += (strErr == string.Empty) ? "Please enter Message" : ", Message";
            }

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                //string val = this.GetControlValidationValue(this.ControlToValidate);
                string val = txtEmail.Text.Trim();
                string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
                Match match = Regex.Match(val.Trim(), pattern, RegexOptions.IgnoreCase);

                if (!match.Success)
                {
                    //lblGroupEmail.CssClass = "input state-error";
                    strErr += (strErr == string.Empty) ? "Invalid Email" : ", invalid Email";
                }
            }

            strErr += (strErr == string.Empty) ? "" : ".";
            lblContactUsError.Text = strErr;            

            #region Sending Email

            if (strErr == string.Empty)
            {                
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.Port = 587;

                //client.Host = "mail.napmohs.org";
                //client.Port = 2525;
                //client.Port = 465;

                //client.Host = "smtp.zoho.com";
                //client.Port = 465;

                // setup Smtp authentication
                System.Net.NetworkCredential credentials =
                    new System.Net.NetworkCredential("chai.lims.mm@gmail.com", "095142993");
                client.UseDefaultCredentials = false;
                client.Credentials = credentials;

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("chai.lims.mms@gmail.com");
                msg.To.Add(new MailAddress("chai.lims.mm@gmail.com"));

                msg.Subject = "Sending message via LIMS Dashboard";
                msg.IsBodyHtml = true;
                msg.Body = string.Format("<html><head></head><body><b>" +
                    "Reply Email: " + txtEmail.Text + "<br />" +
                    "Phone: " + txtPhone.Text + "<br />" +
                    "Facility: " + txtFacility.Text + "<br />" +
                    "Subject: " + txtSubject.Text + "<br />" +
                    "Message: " + txtMessage.Text.Trim() +
                    "</b></body>");

                try
                {
                    client.Send(msg);
                    lblContactUsError.CssClass = "txt-color-green";
                    lblContactUsError.Text = "Your message has been sent successfully.";
                }
                catch (Exception ex)
                {
                    lblContactUsError.CssClass = "txt-color-red";
                    lblContactUsError.Text = "Error occured while sending your message." + ex.Message;
                }
            }
            #endregion
        }

        protected void btnContactUs_Click(object sender, EventArgs e)
        {
            Context.Response.Redirect("ContactUs.aspx");
        }

        #region IUserLoginView Members

        public string GetUserName
        {
            get { return txtUsername.Text; }
        }

        public string GetPassword
        {
            get { return txtPassword.Text; }
        }

        public bool PersistLogin
        {
            get { return chkPersistLogin.Checked; }
        }

        #endregion

        #region Sample Form Download
        protected void btnEID_Click(object sender, EventArgs e)
        {
            //string filePath = Path.Combine(HttpContext.Current.Server.MapPath("~"), "Temp", "EID" + Guid.NewGuid().ToString() + ".pdf");
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=EID.pdf");
            Response.TransmitFile(string.Format(Server.MapPath("~/UploadFiles/EID.pdf")));
            Response.End();
        }

        protected void btnVL_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=ViralLoad.pdf");
            Response.TransmitFile(string.Format(Server.MapPath("~/UploadFiles/ViralLoad.pdf")));
            Response.End();
        }
        #endregion              
    }
}

