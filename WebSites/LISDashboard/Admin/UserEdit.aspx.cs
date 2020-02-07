using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Microsoft.Practices.ObjectBuilder;
using CHAI.LISDashboard.Shared;
using CHAI.LISDashboard.Shared.Settings;
using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain.Setting;

namespace CHAI.LISDashboard.Modules.Admin.Views
{
    public partial class UserEdit : Microsoft.Practices.CompositeWeb.Web.UI.Page, IUserEditView
    {
        private UserEditPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();

                BindProvince();
                Bindlaboratories();
                BindUserControls();
                BindRoles();
                hidTAB.Value = "#s1";
            }
            this._presenter.OnViewLoaded();
            TreeView1.Attributes.Add("onclick", "postBackByObject()");
            TreeView2.Attributes.Add("onclick", "postBackByObject()");
        }

        [CreateNew]
        public UserEditPresenter Presenter
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



        private void BindUserControls()
        {
            if (_presenter.CurrentUser.Id > 0)
            {
                this.txtUsername.Visible = false;
                this.lblUsername.Text = _presenter.CurrentUser.UserName;
                this.lblUsername.Visible = true;
                this.rfvUsername.Enabled = false;
                BindUserLocation();
            }
            else
            {
                this.txtUsername.Text = _presenter.CurrentUser.UserName;
                this.txtUsername.Visible = true;
                this.lblUsername.Visible = false;
                this.rfvUsername.Enabled = true;
                if (TreeView1.Nodes.Count > 0)
                {
                    TreeNode root = TreeView1.Nodes[0];
                    root.Expand();
                }
            }
            this.txtFirstname.Text = _presenter.CurrentUser.FirstName;
            this.txtLastname.Text = _presenter.CurrentUser.LastName;

            this.txtEmail.Text = _presenter.CurrentUser.Email;


            this.chkActive.Checked = _presenter.CurrentUser.IsActive;
            this.btnDelete.Visible = (_presenter.CurrentUser.Id > 0);
            this.btnDelete.Attributes.Add("onclick", "return confirm(\"Are you sure you want to delete this user?\")");
        }

        private void BindRoles()
        {
            IList<Role> roles = _presenter.GetRoles();
            FilterAnonymousRoles(roles);
            this.rptRoles.ItemDataBound += new RepeaterItemEventHandler(rptRoles_ItemDataBound);
            this.rptRoles.DataSource = roles;
            this.rptRoles.DataBind();
        }

        private void FilterAnonymousRoles(IList<Role> roles)
        {
            int roleCount = roles.Count;
            for (int i = roleCount - 1; i >= 0; i--)
            {
                Role role = roles[i];
                if (role.PermissionLevel == (int)AccessLevel.Anonymous)
                {
                    roles.Remove(role);
                }
            }
        }

        private void SetRoles()
        {
            _presenter.RemoveUserRoles();

            foreach (RepeaterItem ri in rptRoles.Items)
            {
                CheckBox chkRole = (CheckBox)ri.FindControl("chkRole");
                if (chkRole.Checked)
                {

                    int roleId = (int)this.ViewState[ri.UniqueID];

                    Role role = _presenter.GetRoleById(roleId);
                    AppUserRole urole = new AppUserRole()
                    {
                        AppUser = _presenter.CurrentUser,
                        Role = role
                    };

                    _presenter.CurrentUser.AppUserRoles.Add(urole);
                }
            }

            string adminRole = UserSettings.GetAdministratorRole;
            if (_presenter.CurrentUser.UserName == UserSettings.GetSuperUser
                && !_presenter.CurrentUser.IsInRole(adminRole))
            {
                throw new Exception(String.Format("The user '{0}' must be the '{1}' role."
                    , _presenter.CurrentUser.UserName, adminRole));
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SetRoles();
                    GetAllCheckedNodes();
                    if (TreeView1.CheckedNodes.Count > 0 && TreeView2.CheckedNodes.Count > 0)
                    {
                        Master.ShowMessage(new AppMessage("User can only be either a  lab user or facility uset, not both", CHAI.LISDashboard.Enums.RMessageType.Error));
                    }
                    else
                    {
                        SaveUserLocation();
                        if (_presenter.CurrentUser.Id == 0)
                        {
                            if (_presenter.CurrentUser.UserLocations.Count > 0)
                            {
                                _presenter.SaveOrUpdateUser();
                                Master.TransferMessage(new AppMessage("User created successfully", CHAI.LISDashboard.Enums.RMessageType.Info));
                                _presenter.RedirectPage(String.Format("~/Admin/UserEdit.aspx?{0}=0&{1}={2}", AppConstants.TABID, AppConstants.USERID, _presenter.CurrentUser.Id));
                            }
                            else
                            {
                                Master.ShowMessage(new AppMessage("Please assign User Location", CHAI.LISDashboard.Enums.RMessageType.Error));
                            }
                        }
                        else
                        {
                            _presenter.SaveOrUpdateUser();
                            Master.ShowMessage(new AppMessage("User saved", CHAI.LISDashboard.Enums.RMessageType.Info));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Master.ShowMessage(new AppMessage("Error: " + ex.Message, CHAI.LISDashboard.Enums.RMessageType.Error));
                }
            }
        }

        #region IUserEditView Members

        public string GetUserId
        {
            get { return Request.QueryString[AppConstants.USERID]; }
        }

        public string GetUserName
        {
            get { return this.txtUsername.Text; }
        }

        public string GetFirstName
        {
            get { return this.txtFirstname.Text; }
        }

        public string GetLastName
        {
            get { return this.txtLastname.Text; }
        }

        public string GetEmail
        {
            get { return this.txtEmail.Text; }
        }

        public bool GetIsActive
        {
            get
            {
                return this.chkActive.Checked;
            }
        }

        public string GetPassword
        {
            get
            {
                return this.txtPassword1.Text;
            }
        }

        #endregion

        protected void rptRoles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Role role = e.Item.DataItem as Role;
            if (role != null)
            {
                CheckBox chkView = (CheckBox)e.Item.FindControl("chkRole");
                chkView.Checked = this._presenter.CurrentUser.IsInRole(role);

                // Add RoleId to the ViewState with the ClientID of the repeateritem as key.
                this.ViewState[e.Item.UniqueID] = role.Id;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            _presenter.CancelPage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _presenter.DeleteUser();
                Master.TransferMessage(new AppMessage("User was deleted", CHAI.LISDashboard.Enums.RMessageType.Info));
                _presenter.CancelPage();
            }
            catch (Exception ex)
            {
                Master.ShowMessage(new AppMessage("Error: " + ex.Message, CHAI.LISDashboard.Enums.RMessageType.Error));
            }
        }

        private void BindProvince()
        {
            //int index = 1;
            //TreeView1.Nodes.Add(new TreeNode("National ", "0"));
            //foreach (Province pr in _presenter.GetProvinces())
            //{
            //    TreeView1.Nodes.Add(new TreeNode(pr.ProvinceName + " (State/Region)", pr.Id.ToString()));
            //    BindDistrict(index, pr.Id);
            //    index++;
            //}

            //Updated by ZaySoe on 6-Nov-2018
            int index = 0;
            TreeNode root = new TreeNode("National ", "0");
            TreeView1.Nodes.Add(root);
            foreach (Province pr in _presenter.GetProvinces())
            {
                root.ChildNodes.Add(new TreeNode(pr.ProvinceName + " (State/Region)", pr.Id.ToString()));
                BindDistrict(root.ChildNodes, index, pr.Id);
                index++;
            }
        }
        private void Bindlaboratories()
        {
            foreach (Laboratory lab in _presenter.GetLabratories())
            {
                TreeView2.Nodes.Add(new TreeNode(lab.LaboratoryName, lab.LabCode));

            }
        }
        //private void BindDistrict(int index, int provinceId)
        //{
        //    int indexd = 0;
        //    foreach (District ds in _presenter.GetDistricts(provinceId))
        //    {
        //        TreeView1.Nodes[index].ChildNodes.Add(new TreeNode(ds.DistrictName + " (District)", ds.Id.ToString()));
        //        BindLLG(TreeView1.Nodes[index].ChildNodes, indexd, ds.Id);
        //        indexd++;
        //    }
        //}

        //Changed by ZaySoe on 6-Nov-2018
        private void BindDistrict(TreeNodeCollection Node, int index, int provinceId)
        {
            int indexd = 0;
            foreach (District ds in _presenter.GetDistricts(provinceId))
            {
                Node[index].ChildNodes.Add(new TreeNode(ds.DistrictName + " (District)", ds.Id.ToString()));
                BindLLG(Node[index].ChildNodes, indexd, ds.Id);
                indexd++;
            }
        }
        private void BindLLG(TreeNodeCollection Node, int index, int districtId)
        {
            int indexl = 0;
            foreach (LLG llg in _presenter.GetLLGs(districtId))
            {
                Node[index].ChildNodes.Add(new TreeNode(llg.LLGName + " (Township)", llg.Id.ToString()));
                BindFacilities(Node[index].ChildNodes, indexl, llg.Id);
                indexl++;
            }
        }
        private void BindFacilities(TreeNodeCollection Node, int index, int LLGId)
        {
            foreach (Facility fac in _presenter.GetFacilities(LLGId))
            {
                Node[index].ChildNodes.Add(new TreeNode(fac.FacilityName + " (Facility)", fac.Id.ToString()));

            }
        }
        private List<TreeNode> AllCheckedNodes = new List<TreeNode>();

        private void GetAllCheckedNodes()
        {
            for (int i = 0; i < TreeView1.CheckedNodes.Count; i++)
            {
                AllCheckedNodes.Add(TreeView1.CheckedNodes[i]);
            }

            Session["AllCheckedNodes"] = AllCheckedNodes;
        }

        #region "SaveUserLocation - Yonathan"
        //private void SaveUserLocation()
        //{
        //    _presenter.CurrentUser.RemoveUserLocation(1);
        //    IList<TreeNode> CheckedNodes = Session["AllCheckedNodes"] as List<TreeNode>;
        //    IList<UserLocation> UserLocations = _presenter.CurrentUser.UserLocations;
        //    if (TreeView2.CheckedNodes.Count == 0)
        //    {
        //        foreach (TreeNode node in CheckedNodes)
        //        {
        //            if (node.Depth == 3 && node.Parent.Checked == false && node.Parent.Parent.Checked == false && node.Parent.Parent.Parent.Checked == false)
        //            {
        //                if (_presenter.CurrentUser.GetUserLocationbyFacility(Convert.ToInt32(node.Value)) == null)
        //                    {
        //                        UserLocation ul = new UserLocation();
        //                        ul.province = _presenter.GetProvince(Convert.ToInt32(node.Parent.Parent.Parent.Value));
        //                        ul.District = _presenter.GetDistrict(Convert.ToInt32(node.Parent.Parent.Value));
        //                        ul.LLG = _presenter.GetLLG(Convert.ToInt32(node.Parent.Value));
        //                        ul.Facility = _presenter.GetFacility(Convert.ToInt32(node.Value));
        //                        ul.User = _presenter.GetUser(_presenter.CurrentUser.Id);
        //                        _presenter.CurrentUser.UserLocations.Add(ul);
        //                    }

        //            }
        //            else if (node.Depth == 2 && node.Parent.Checked == false && node.Parent.Parent.Checked == false)
        //            {

        //                    if (_presenter.CurrentUser.GetUserLocationbyLLG(Convert.ToInt32(node.Value)) == null)
        //                    {
        //                        UserLocation ul = new UserLocation();
        //                        ul.province = _presenter.GetProvince(Convert.ToInt32(node.Parent.Parent.Value));
        //                        ul.District = _presenter.GetDistrict(Convert.ToInt32(node.Parent.Value));
        //                        ul.LLG = _presenter.GetLLG(Convert.ToInt32(node.Value));
        //                        ul.User = _presenter.GetUser(_presenter.CurrentUser.Id);
        //                        _presenter.CurrentUser.UserLocations.Add(ul);
        //                    }

        //            }
        //            else if (node.Depth == 1 && node.Parent.Checked == false)
        //            {

        //                    if (_presenter.CurrentUser.GetUserLocationbyDistrict(Convert.ToInt32(node.Value)) == null)
        //                    {
        //                        UserLocation ul = new UserLocation();
        //                        ul.province = _presenter.GetProvince(Convert.ToInt32(node.Parent.Value));
        //                        ul.District = _presenter.GetDistrict(Convert.ToInt32(node.Value));
        //                        ul.User = _presenter.GetUser(_presenter.CurrentUser.Id);
        //                        _presenter.CurrentUser.UserLocations.Add(ul);                                
        //                    }

        //            }
        //            else if (node.Depth == 0)
        //            {
        //                if (node.Value == "0")
        //                {

        //                        if (_presenter.CurrentUser.GetUserLocationbyProvince(Convert.ToInt32(node.Value)) == null)
        //                        {
        //                            UserLocation ul = new UserLocation();
        //                            ul.province = null;
        //                            ul.User = _presenter.GetUser(_presenter.CurrentUser.Id);
        //                            _presenter.CurrentUser.UserLocations.Add(ul);
        //                        }

        //                }
        //                else
        //                {

        //                        if (_presenter.CurrentUser.GetUserLocationbyProvince(Convert.ToInt32(node.Value)) == null)
        //                        {
        //                            UserLocation ul = new UserLocation();
        //                            ul.province = _presenter.GetProvince(Convert.ToInt32(node.Value));
        //                            ul.User = _presenter.GetUser(_presenter.CurrentUser.Id);
        //                            _presenter.CurrentUser.UserLocations.Add(ul);
        //                        }

        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (TreeView2.CheckedNodes.Count > 1)
        //        {
        //            Master.ShowMessage(new AppMessage("You can only assign user with one Laboratory", CHAI.LISDashboard.Enums.RMessageType.Error));
        //        }
        //        else
        //        {
        //            foreach (TreeNode nodelab in TreeView2.CheckedNodes)
        //            {

        //                if (_presenter.CurrentUser.GetUserLocationbyLab(nodelab.Value) == null)
        //                {
        //                    UserLocation ul = new UserLocation();
        //                    ul.LabCode = nodelab.Value;
        //                    ul.User = _presenter.CurrentUser;
        //                    _presenter.CurrentUser.UserLocations.Add(ul);
        //                }
        //            }
        //        }
        //    }
        //}
        #endregion

        //Updated by ZaySoe on 07-Dec-2018
        private void SaveUserLocation()
        {
            //_presenter.CurrentUser.RemoveUserLocation(1);
            IList<TreeNode> CheckedNodes = Session["AllCheckedNodes"] as List<TreeNode>;
            IList<UserLocation> UserLocations = _presenter.CurrentUser.UserLocations;
            if (TreeView2.CheckedNodes.Count == 0)
            {
                foreach (TreeNode node in CheckedNodes)
                {
                    if (node.Depth == 4)
                    {
                        List<UserLocation> list = _presenter.CurrentUser.GetUserLocationbyFacility(Convert.ToInt32(node.Value));
                        if (list != null && list.Count == 0)
                        {
                            UserLocation ul = new UserLocation();
                            ul.province = _presenter.GetProvince(Convert.ToInt32(node.Parent.Parent.Parent.Value));
                            ul.District = _presenter.GetDistrict(Convert.ToInt32(node.Parent.Parent.Value));
                            ul.LLG = _presenter.GetLLG(Convert.ToInt32(node.Parent.Value));
                            ul.Facility = _presenter.GetFacility(Convert.ToInt32(node.Value));
                            ul.User = _presenter.GetUser(_presenter.CurrentUser.Id);
                            _presenter.CurrentUser.UserLocations.Add(ul);
                        }

                    }
                }
            }
            else
            {
                //Updated by ZaySoe on 12-Jun-2019 to allow more than one lab for LabUser                
                //if (TreeView2.CheckedNodes.Count > 1)
                //{
                //    Master.ShowMessage(new AppMessage("You can only assign user with one Laboratory", CHAI.LISDashboard.Enums.RMessageType.Error));
                //}
                //else
                //{
                    foreach (TreeNode nodelab in TreeView2.CheckedNodes)
                    {

                        if (_presenter.CurrentUser.GetUserLocationbyLab(nodelab.Value) == null)
                        {
                            UserLocation ul = new UserLocation();
                            ul.LabCode = nodelab.Value;
                            ul.User = _presenter.CurrentUser;
                            _presenter.CurrentUser.UserLocations.Add(ul);
                        }
                    }
                //}
            }
        }

        #region BindUserLocation - Yonathan
        //private void BindUserLocation()
        //{
        //    if (_presenter.GetUser(_presenter.CurrentUser.Id).UserLocations != null)
        //    {
        //        IList<UserLocation> uls = _presenter.GetUser(_presenter.CurrentUser.Id).UserLocations;
        //        if (uls.Count != 0)
        //        {
        //            if (String.IsNullOrEmpty(uls[0].LabCode))
        //            {
        //                foreach (TreeNode parent in TreeView1.Nodes)
        //                {
        //                    foreach (UserLocation ul in uls)
        //                    {
        //                        if (ul.province == null)
        //                        {
        //                            if (parent.Value == "0")
        //                            {
        //                                parent.Checked = true;
        //                                parent.ToolTip = ul.Id.ToString();
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (parent.Value == ul.province.Id.ToString())
        //                            {
        //                                parent.Checked = true;
        //                                parent.ToolTip = ul.Id.ToString();
        //                            }
        //                        }

        //                    }


        //                    foreach (TreeNode child in parent.ChildNodes)
        //                    {
        //                        foreach (UserLocation ul in uls)
        //                        {
        //                            if (ul.District != null)
        //                            {
        //                                if (child.Value == ul.District.Id.ToString())
        //                                {
        //                                    child.Checked = true;
        //                                    parent.Expand();
        //                                    child.Expand();
        //                                    child.ToolTip = ul.Id.ToString();
        //                                }
        //                            }
        //                        }
        //                        foreach (TreeNode grandchild in child.ChildNodes)
        //                        {
        //                            foreach (UserLocation ul in uls)
        //                            {
        //                                if (ul.LLG != null)
        //                                {
        //                                    if (grandchild.Value == ul.LLG.Id.ToString())
        //                                    {
        //                                        grandchild.Checked = true;
        //                                        parent.Expand();
        //                                        grandchild.Expand();
        //                                        grandchild.ToolTip = ul.Id.ToString();
        //                                    }
        //                                }
        //                            }
        //                            foreach (TreeNode grandgrandchild in grandchild.ChildNodes)
        //                            {
        //                                foreach (UserLocation ul in uls)
        //                                {
        //                                    if (ul.Facility != null)
        //                                    {
        //                                        if (grandgrandchild.Value == ul.Facility.Id.ToString())
        //                                        {
        //                                            grandgrandchild.Checked = true;
        //                                            parent.Expand();
        //                                            grandgrandchild.Expand();
        //                                            grandgrandchild.ToolTip = ul.Id.ToString();
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }

        //                }
        //            }
        //            else
        //            {
        //                // Lab user

        //                foreach (TreeNode parent in TreeView2.Nodes)
        //                {
        //                    foreach (UserLocation ul in uls)
        //                    {
        //                        if (parent.Value == ul.LabCode.ToString())
        //                        {
        //                            parent.Checked = true;
        //                            parent.ToolTip = ul.Id.ToString();
        //                        }


        //                    }
        //                }
        //            }
        //        }

        //    }
        //}
        #endregion

        //Updated by ZaySoe on 07-Nov-2018
        private void BindUserLocation()
        {
            //if (TreeView1.Nodes.Count > 0)
            //{
            TreeNode root = TreeView1.Nodes[0];
            root.Expand();
            //}

            if (_presenter.GetUser(_presenter.CurrentUser.Id).UserLocations != null)
            {
                IList<UserLocation> uls = _presenter.GetUser(_presenter.CurrentUser.Id).UserLocations;
                if (uls.Count != 0)
                {
                    if (String.IsNullOrEmpty(uls[0].LabCode))
                    {                    
                        #region Province Level
                        int pCount = 0;
                        int dCount = 0;
                        int tCount = 0;
                        int fCount = 0;
                        bool hasFacility = false;
                        foreach (TreeNode pNode in root.ChildNodes)
                        {
                            #region District Level
                            dCount = 0;
                            hasFacility = false;
                            foreach (TreeNode dNode in pNode.ChildNodes)
                            {
                                #region LLG Level
                                tCount = 0;
                                foreach (TreeNode tNode in dNode.ChildNodes)
                                {
                                    #region Facility Level
                                    fCount = 0;
                                    foreach (TreeNode fNode in tNode.ChildNodes)
                                    {
                                        foreach (UserLocation ul in uls)
                                        {
                                            if (ul.Facility != null && Convert.ToInt32(fNode.Value) == ul.Facility.Id)
                                            {
                                                fNode.Checked = true;
                                                fNode.ToolTip = ul.Facility.Id.ToString();
                                                fCount++;
                                                hasFacility = true;
                                            }
                                        }
                                    }
                                    if (fCount != 0 && tNode.ChildNodes.Count == fCount)
                                    {
                                        tNode.Checked = true;
                                        tNode.Expand();
                                        tCount++;
                                    }
                                    else if (hasFacility)
                                        tNode.Expand();
                                    #endregion
                                }
                                if (tCount != 0 && dNode.ChildNodes.Count == tCount)
                                {
                                    dNode.Checked = true;
                                    dNode.Expand();
                                    dCount++;
                                }
                                else if (hasFacility)
                                    dNode.Expand();
                                #endregion
                            }
                            if (dCount != 0 && pNode.ChildNodes.Count == dCount)
                            {
                                pNode.Checked = true;
                                pNode.Expand();
                                pCount++;
                            }
                            else if (hasFacility)
                                pNode.Expand();
                            #endregion
                        }
                        if (pCount != 0 && root.ChildNodes.Count == pCount)
                        {
                            root.Checked = true;
                            root.Expand();
                        }
                        else if (hasFacility)
                            root.Expand();
                        #endregion                        
                    }
                    else
                    {
                        // Lab code
                        foreach (TreeNode parent in TreeView2.Nodes)
                        {
                            foreach (UserLocation ul in uls)
                            {
                                if (parent.Value == ul.LabCode.ToString())
                                {
                                    parent.Checked = true;
                                    parent.ToolTip = ul.Id.ToString();
                                }
                            }
                        }
                    }
                }
            }            
        }

        protected void TreeView2_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            //if (!String.IsNullOrEmpty(e.Node.ToolTip))
            //{
            if (e.Node.Checked == false)
            {
                //UserLocation ul = _presenter.CurrentUser.GetUserLocation(Convert.ToInt32(e.Node.ToolTip));
                //_presenter.CurrentUser.RemoveUserLocation(Convert.ToInt32(e.Node.ToolTip), e.Node.Depth, true);

                UserLocation ul = _presenter.CurrentUser.GetUserLocationByLabCode(e.Node.Value);
                if (ul != null)
                {
                    _presenter.CurrentUser.RemoveUserLocation(Convert.ToInt32(e.Node.Value), e.Node.Depth, true);
                    _presenter.Delete(ul);
                }
            }
            //}
            hidTAB.Value = "#s2";
        }

        protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            //if (!String.IsNullOrEmpty(e.Node.ToolTip))
            //{
            if (e.Node.Checked == false)
            {
                //UserLocation ul = _presenter.CurrentUser.GetUserLocation(Convert.ToInt32(e.Node.ToolTip));
                //_presenter.CurrentUser.RemoveUserLocation(Convert.ToInt32(e.Node.ToolTip));

                //UserLocation ul = _presenter.CurrentUser.GetUserLocation(Convert.ToInt32(e.Node.Value));
                List<UserLocation> list = null;                
                if (e.Node.Depth == 0) {
                    list = _presenter.CurrentUser.GetUserLocationbyNational();
                } else if (e.Node.Depth == 1)
                    list = _presenter.CurrentUser.GetUserLocationbyProvince(Convert.ToInt32(e.Node.Value));                
                else if (e.Node.Depth == 2)
                    list = _presenter.CurrentUser.GetUserLocationbyDistrict(Convert.ToInt32(e.Node.Value));                
                else if (e.Node.Depth == 3)
                    list = _presenter.CurrentUser.GetUserLocationbyLLG(Convert.ToInt32(e.Node.Value));                
                else if (e.Node.Depth == 4)
                    list = _presenter.CurrentUser.GetUserLocationbyFacility(Convert.ToInt32(e.Node.Value));

                if (list != null && list.Count > 0)
                {
                    _presenter.CurrentUser.RemoveUserLocation(Convert.ToInt32(e.Node.Value), e.Node.Depth, false);
                    foreach (UserLocation ul in list)
                    {
                        _presenter.Delete(ul);
                    }
                }

                this.NestedTreeNodeChecked(e.Node.ChildNodes, false);
                e.Node.CollapseAll();
            }
            else
            {
                //Added by Zay Soe on 6-Dec-2018
                this.NestedTreeNodeChecked(e.Node.ChildNodes, true);
                e.Node.ExpandAll();
            }
            //}
            hidTAB.Value = "#s2";
        }

        //protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        //{
        //    //if (!String.IsNullOrEmpty(e.Node.ToolTip))
        //    //{
        //    if (e.Node.Checked == false)
        //    {
        //        UserLocation ul = _presenter.CurrentUser.GetUserLocation(Convert.ToInt32(e.Node.ToolTip));
        //        _presenter.CurrentUser.RemoveUserLocation(Convert.ToInt32(e.Node.ToolTip));
                          
        //        if (ul != null)
        //        {
        //            _presenter.CurrentUser.RemoveUserLocation(Convert.ToInt32(e.Node.Value), e.Node.Depth, false);
        //            _presenter.Delete(ul);
        //        }

        //        this.NestedTreeNodeChecked(e.Node.ChildNodes, false);
        //        e.Node.CollapseAll();
        //    }            
        //    //}
        //    hidTAB.Value = "#s2";
        //}

        //This method is added by Zay Soe on 6-Dec-2018
        private void NestedTreeNodeChecked(TreeNodeCollection childNodes, bool isChecked)
        {
            if (childNodes.Count == 0)
                return;
            foreach (TreeNode node in childNodes)
            {
                node.Checked = isChecked;
                this.NestedTreeNodeChecked(node.ChildNodes, isChecked);
            }

        }
    }
}

