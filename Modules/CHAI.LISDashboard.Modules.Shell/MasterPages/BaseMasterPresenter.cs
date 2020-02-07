using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using Microsoft.Practices.CompositeWeb.Interfaces;
using System.Linq;
using System.Linq.Expressions;

using CHAI.LISDashboard.CoreDomain.DataAccess;
using CHAI.LISDashboard.CoreDomain.Admins;
using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.Services;


namespace CHAI.LISDashboard.Modules.Shell.MasterPages
{
    public class BaseMasterPresenter : Presenter<IBaseMasterView>
    {
        private ShellController _controller;
        private int _tabId;
        
        public BaseMasterPresenter()
        {
        }

        public override void OnViewLoaded()
        {
            View.CurrentUser = _controller.GetCurrentUser();
            if (!Int32.TryParse(View.TabId, out _tabId))
                _tabId = -1;
        }

        [CreateNew]
        public ShellController Controller
        {
            get
            {
                return _controller;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                this._controller = value;
            }
        }

        public int TabId
        {
            get { return _tabId; }
        }

        
        public IHttpContext CurrentContext
        {
            get { return Controller.GetCurrentContext(); }
        }

        public AppUser CurrentUser
        {
            get
            {
                return Controller.GetCurrentUser();
            }
        }
        
        public bool UserIsAuthenticated
        {
            get { return Controller.UserIsAuthenticated;}
        }

        public void Navigate(string url)
        {
            Controller.Navigate(url);
        }
        
        public Tab ActiveTab
        {
            get { return Controller.ActiveTab(_tabId); }
        }

        public IEnumerable<Tab> GetListOfAllTabs()
        {
            using(var vr = WorkspaceFactory.CreateReadOnly())
            {
                //Added by wwp 06-12-2018
                return vr.Query<Tab>(null, x => x.PocModule, x => x.TabRoles.Select(z => z.Role), x => x.TaskPans, x => x.TaskPans.Select(y => y.TaskPanNodes.Select(w => w.Node).Select(e => e.NodeRoles.Select(r => r.Role))), x => x.TaskPans.Select(y => y.TaskPanNodes.Select(w => w.Node).Select(z => z.PocModule))).OrderBy(a => a.Position).OrderBy(x => x.Position).ToList();
            }
        }
        
    }
}
