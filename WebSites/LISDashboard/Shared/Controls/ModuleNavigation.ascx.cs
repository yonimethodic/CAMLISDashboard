using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.ObjectBuilder;
using System.Linq;
using CHAI.LISDashboard.Shared;
using CHAI.LISDashboard.CoreDomain.Admins;
using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.Services;
using CHAI.LISDashboard.CoreDomain.Users;
using System.Security.Cryptography;
//using RSACryptography;

namespace CHAI.LISDashboard.Modules.Shell.Views
{
    public partial class ModuleNavigation : Microsoft.Practices.CompositeWeb.Web.UI.UserControl
    {
        private BaseMaster GetMaster()
        {
            return Page.Master as BaseMaster;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BuildNavigation();
        }
        

        private void BuildNavigation()
        {
            HtmlGenericControl mainList = new HtmlGenericControl("ul");

            mainList.Attributes["Id"] = "navigation";
            mainList.Attributes["class"] = "sf-navbar sf-js-enabled";

            HtmlGenericControl listItem = new HtmlGenericControl("li");
            HyperLink hpl = new HyperLink();
            hpl.NavigateUrl = this.Page.ResolveUrl(string.Format("~/Default.aspx?{0}=0", AppConstants.TABID));

            //RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            ////string encryptedURL = Crypto.RSA.Encrypt(string.Format("{0}=0", AppConstants.TABID),
            ////    rsaProvider.ToXmlString(false), 1024);
            //string encryptedURL = CryptographyHelper.Encrypt( string.Format("{0}=0", AppConstants.TABID));
            //hpl.NavigateUrl = this.Page.ResolveUrl(String.Format("~/Default.aspx?{0}", encryptedURL));

            //string encryptedURL = CryptographyHelper.DESEncrypt(string.Format("{0}=0", AppConstants.TABID));
            //hpl.NavigateUrl = this.Page.ResolveUrl(String.Format("~/Default.aspx?{0}", encryptedURL));

            //hpl.Text = "Dashboard";
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.Attributes["class"] = "menu-item-parent";
            span.InnerText = "Home";
            //span.InnerText = "ዳሽቦርድ";
            HtmlGenericControl inline = new HtmlGenericControl("i");
            inline.Attributes["class"] = "fa fa-lg fa-fw fa-home";
            hpl.Controls.Add(inline);
            hpl.Controls.Add(span);

            listItem.Controls.Add(hpl);
            mainList.Controls.Add(listItem);
            
            //mainList.Controls.Add(BuildListItemForHomeTab("Home", listItem));
            foreach (Tab tab in  GetMaster().Presenter.GetListOfAllTabs())
            {
                if (tab.ViewAllowed(GetMaster().Presenter.CurrentUser))
                {
                    mainList.Controls.Add(BuildListItemFromTab(tab,mainList));
                }
            }

            if (GetMaster().Presenter.CurrentUser != null && GetMaster().Presenter.CurrentUser.HasPermission(AccessLevel.Administrator))
                
            {
                //HtmlGenericControl listItem = new HtmlGenericControl("li");
                //HyperLink hpl = new HyperLink();
                //hpl.NavigateUrl = this.Page.ResolveUrl(string.Format("~/Admin/Default.aspx?{0}=0", AppConstants.TABID));
                //hpl.Text = "Admin";
                //listItem.Controls.Add(hpl);
                //mainList.Controls.Add(listItem);
            }
          
            this.plhNavigation.Controls.Add(mainList);
        }
       
        private HtmlControl BuildListItemFromTab(Tab tab, HtmlGenericControl mainlist)
        {
             HtmlGenericControl listItem = new HtmlGenericControl("li");
             HyperLink hpl = new HyperLink();

             HtmlGenericControl inline = new HtmlGenericControl("i");
            // inline.Attributes["class"] = "fa fa-lg fa-fw fa-home";
            //Added by wwp 20-11-2018
            if (tab.TabName == "Setting") inline.Attributes["class"] = "fa fa-lg fa-fw fa-cogs";
            else if (tab.TabName == "Laboratory") inline.Attributes["class"] = "fa fa-lg fa-fw fa-hospital-o";
            else if (tab.TabName == "Early Infant Diagnosis") inline.Attributes["class"] = "fa fa-lg fa-fw fa-bar-chart-o";
            else if (tab.TabName == "HIV Viral Load") inline.Attributes["class"] = "fa fa-lg fa-fw fa-bar-chart-o";
            else if (tab.TabName == "EID") inline.Attributes["class"] = "fa fa-lg fa-fw fa-file-text-o";
            else if (tab.TabName == "HIV VL") inline.Attributes["class"] = "fa fa-lg fa-fw fa-file-text-o";
            else if (tab.TabName == "Report") inline.Attributes["class"] = "fa fa-lg fa-fw fa-pencil-square-o";
            else inline.Attributes["class"] = "fa fa-lg fa-fw fa-bar-chart-o";
            
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.Attributes["class"] = "menu-item-parent";
            span.InnerText = tab.TabName;

            hpl.Controls.Add(inline);
            
            hpl.Controls.Add(span);

            listItem.Controls.Add(hpl);
            DataBind(tab, listItem);
            mainlist.Controls.Add(listItem);

            //RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();                        
            //CHAI.LISDashboard.Modules.Shell.Views.Crypto.Decrypt();
            //string encryptedURL = Crypto.RSA.Encrypt(string.Format("{0}={1}", AppConstants.TABID, _tab.Id),
            //    rsaProvider.ToXmlString(false), 1024);
            //hpl.NavigateUrl = this.Page.ResolveUrl(String.Format("{0}?{1}", node.NodeUrl, encryptedURL));            

            string tt = GetMaster().TabId;

            if (tab.Id.ToString() == GetMaster().TabId)
            {
                listItem.Attributes.Add("class", "open");
                HtmlGenericControl b = new HtmlGenericControl("b");
                HtmlGenericControl em = new HtmlGenericControl("em");
                b.Attributes.Add("class", "collapse-sign");
                em.Attributes.Add("class", "fa fa-minus-square-o");
                b.Controls.Add(em);
                hpl.Controls.Add(b);
            }

            //hpl.NavigateUrl = this.Page.ResolveUrl(String.Format("~/{0}/Default.aspx?{1}={2}", tab.PocModule.FolderPath, AppConstants.TABID, tab.Id));
            //hpl.Text = tab.TabName;
          
            //listItem.Controls.Add(hpl);

            
            if (tab.PopupMenus.Count > 0)
            {
                listItem.Controls.Add(BuildListFromPopupMenus(tab.PopupMenus.ToList()));
            }
            return listItem;
        }

        private HtmlControl BuildListFromPopupMenus(IList<PopupMenu> pmenus)
        {
            HtmlGenericControl list = new HtmlGenericControl("ul");
            foreach (PopupMenu p in pmenus)
            {
                list.Controls.Add(BuildListItemFromPopupMenu(p));
            }

            return list;
        }
   
        private HtmlControl BuildListItemFromPopupMenu(PopupMenu pm)
        {            
            HtmlGenericControl listItem = new HtmlGenericControl("li");
            HyperLink hpl = new HyperLink();
            hpl.NavigateUrl = this.Page.ResolveUrl(String.Format("{0}?{1}={2}", pm.Node.NodeUrl, AppConstants.TABID, pm.Tab.Id));

            //RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            ////string encryptedURL = Crypto.RSA.Encrypt(string.Format("{0}={1}", AppConstants.TABID, pm.Tab.Id),
            ////    rsaProvider.ToXmlString(false), 1024);
            //string encryptedURL = CryptographyHelper.Encrypt(string.Format("{0}={1}", AppConstants.TABID, pm.Tab.Id));            
            //hpl.NavigateUrl = this.Page.ResolveUrl(String.Format("{0}?{1}", pm.Node.NodeUrl, encryptedURL));

            //string encryptedURL = CryptographyHelper.DESEncrypt(string.Format("{0}={1}", AppConstants.TABID, pm.Tab.Id));
            //hpl.NavigateUrl = this.Page.ResolveUrl(String.Format("{0}?{1}", pm.Node.NodeUrl, encryptedURL));

            hpl.Text = pm.Node.Title;
            listItem.Controls.Add(hpl);
            
            return listItem;
        }

        // public void BindPanel()
        //{
        //    if (_tab != null)
        //    {
        //        this.rptPanel.DataSource = _tab.TaskPans;
        //        this.rptPanel.DataBind();
        //    }
        //}
                

        private void BuildSubMenuNavigation(IList<TaskPanNode> iList,HtmlGenericControl parentlistItem)
        {
            HtmlGenericControl mainlist = new HtmlGenericControl("ul");

            //added by ZaySoe on 13-Mar-2019
            iList = iList.OrderBy(p => p.Position).ToList();

            foreach (TaskPanNode pn in iList)
            {
                if (pn.Node.ViewAllowed(GetMaster().Presenter.CurrentUser))
                {
                    //Added by ZaySoe on 14_Jan_2019
                    AppUser user = GetMaster().Presenter.CurrentUser;
                    if (user.AppUserRoles != null && user.AppUserRoles.Count > 0
                        //&& user.AppUserRoles[0].Role.Name != "Administrator"
                        && !this.ViewAllow(pn.Node.NodeRoles, user.AppUserRoles[0]))
                    {
                        continue;                     
                    }                   

                    BuildSubMenuListItemFromNode(pn.Node, pn.TaskPan.Tab.Id, mainlist);
                }
            }
           parentlistItem.Controls.Add(mainlist);
            //parentlistItem.Controls.Add(mainlist);
        }

        //Added by ZaySoe on 14_Jan_2019
        private bool ViewAllow(IList<NodeRole> tpNodeRoles, AppUserRole userRole)
        {            
            foreach(NodeRole nr in tpNodeRoles)
            {
                if(nr.Role.Id == userRole.Role.Id)                
                    return true;                
            }
            return false;
        }
        
        private HtmlControl BuildSubMenuListItemFromNode(Node node, int TabId, HtmlGenericControl parentlistItem)
        {
            HtmlGenericControl listItem = new HtmlGenericControl("li");
            HyperLink hpl = new HyperLink();
            hpl.NavigateUrl = this.Page.ResolveUrl(String.Format("{0}?{1}={2}&{3}={4}", node.NodeUrl, AppConstants.TABID, TabId, AppConstants.NODEID, node.Id));

            //RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            ////string encryptedURL = Crypto.RSA.Encrypt(string.Format("{0}={1}&{2}={3}", AppConstants.TABID, TabId, AppConstants.NODEID, node.Id),
            ////    rsaProvider.ToXmlString(false), 1024);
            //string encryptedURL = CryptographyHelper.Encrypt(string.Format("{0}={1}&{2}={3}", AppConstants.TABID, TabId, AppConstants.NODEID, node.Id));
            //hpl.NavigateUrl = this.Page.ResolveUrl(String.Format("{0}?{1}", node.NodeUrl, encryptedURL));

            //string encryptedURL = CryptographyHelper.DESEncrypt(string.Format("{0}={1}&{2}={3}", AppConstants.TABID, TabId, AppConstants.NODEID, node.Id));
            //hpl.NavigateUrl = this.Page.ResolveUrl(String.Format("{0}?{1}", node.NodeUrl, encryptedURL));

            hpl.Text = node.Title;

            //zay soe
            string currentNodeId = GetMaster().NodeId;

            if (node.Id.ToString() == GetMaster().NodeId)
            {
                listItem.Attributes.Add("class", "active");
            }
            listItem.Controls.Add(hpl);
            parentlistItem.Controls.Add(listItem);
            return parentlistItem;
        }

        private void DataBind(Tab tab, HtmlGenericControl li)
        {           
            foreach(TaskPan pan in tab.TaskPans)
                if (pan != null)
                {
                    //Literal ltr = ltrTitle;
                    //ltr.Text = pan.Title;

                    //PlaceHolder plh = plhNode;
                    BuildSubMenuNavigation(pan.TaskPanNodes.ToList(),li);
                }
        }
    }
}

