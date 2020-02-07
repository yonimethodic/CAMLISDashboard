using System;
using System.Collections.Generic;
using CHAI.LISDashboard.CoreDomain.Admins;

namespace CHAI.LISDashboard.Modules.Admin.Views
{
    public interface ITabEditView
    {
        string GetTabId { get; }
        string GetNodeId { get; }
        string GetModuleId { get; }
        string GetTabName { get; }
        string GetDescription { get; }
        
        void BindTab();
        void BindPopupMenus();
        void BindTaskPans();
        void BindRoles();
        void SetRoles(Tab node);
    }
}




