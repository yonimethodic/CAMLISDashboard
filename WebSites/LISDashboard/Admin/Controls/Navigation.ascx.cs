using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.ObjectBuilder;
using CHAI.LISDashboard.Shared;
using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.Modules.Admin.Views;
using CHAI.LISDashboard.CoreDomain.Admins;
using CHAI.LISDashboard.Modules.Shell;
using System.Security.Cryptography;
//using RSACryptography;

namespace CHAI.LISDashboard.Modules.Admin.Views
{
    public partial class Navigation : Microsoft.Practices.CompositeWeb.Web.UI.UserControl
    {

        private BaseMaster GetMaster()
        {
            return Page.Master as BaseMaster;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                hplNewTab.NavigateUrl = Page.ResolveUrl(String.Format("~/Admin/TabEdit.aspx?{0}=0&{1}=0", AppConstants.TABID, AppConstants.NODEID));

                //RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
                ////string encryptedURL = Crypto.RSA.Encrypt(string.Format("{0}=0&{1}=0", AppConstants.TABID, AppConstants.NODEID),
                ////    rsaProvider.ToXmlString(false), 1024);
                //string encryptedURL = CryptographyHelper.Encrypt(string.Format("{0}=0&{1}=0", AppConstants.TABID, AppConstants.NODEID));
                //hplNewTab.NavigateUrl = Page.ResolveUrl(String.Format("~/Admin/TabEdit.aspx?{0}", encryptedURL));

                //string encryptedURL = CryptographyHelper.DESEncrypt(string.Format("{0}=0&{1}=0", AppConstants.TABID, AppConstants.NODEID));
                //hplNewTab.NavigateUrl = Page.ResolveUrl(String.Format("~/Admin/TabEdit.aspx?{0}", encryptedURL));
            }

            BuildNavigation();
        }

        private void BuildNavigation()
        {
            HtmlGenericControl mainList = ultabs;

            foreach (Tab tab in GetMaster().Presenter.GetListOfAllTabs())
            {
                mainList.Controls.Add(BuildListItemFromTab(tab));
            }
            
          
            //this.plhTabs.Controls.Add(mainList);
        }

        private HtmlControl BuildListItemFromTab(Tab tab)
        {
            HtmlGenericControl listItem = litabs;
            HyperLink hpl = new HyperLink();

            hpl.NavigateUrl = this.Page.ResolveUrl(String.Format("~/Admin/TabEdit.aspx?{0}=0&{1}={2}", AppConstants.TABID,AppConstants.NODEID, tab.Id));

            //RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            ////string encryptedURL = Crypto.RSA.Encrypt(string.Format("{0}=0&{1}={2}", AppConstants.TABID, AppConstants.NODEID, tab.Id),
            ////    rsaProvider.ToXmlString(false), 1024);
            //string encryptedURL = CryptographyHelper.Encrypt(string.Format("{0}=0&{1}={2}", AppConstants.TABID, AppConstants.NODEID, tab.Id));            

            ////Crypto.RSA.Encrypt();
            //hplNewTab.NavigateUrl = Page.ResolveUrl(String.Format("~/Admin/TabEdit.aspx?{0}", encryptedURL));

            //string encryptedURL = CryptographyHelper.DESEncrypt(string.Format("{0}=0&{1}={2}", AppConstants.TABID, AppConstants.NODEID, tab.Id));
            //hplNewTab.NavigateUrl = Page.ResolveUrl(String.Format("~/Admin/TabEdit.aspx?{0}", encryptedURL));

            hpl.Text = tab.TabName;
            listItem.Controls.Add(hpl);
            return listItem;
        }

    }
}

