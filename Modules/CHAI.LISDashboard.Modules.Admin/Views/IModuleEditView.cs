using System;
using System.Collections.Generic;
using System.Text;

namespace CHAI.LISDashboard.Modules.Admin.Views
{
    public interface IModuleEditView
    {
        string GetModuleId { get; }
        string GetName { get; }
        string GetFolderPath { get; }
    }
}




