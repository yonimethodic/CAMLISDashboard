using System;
using System.Web;

namespace CHAI.LISDashboard.Shared.Navigation
{
    public class RedirectNavigationService : INavigationService
    {
        public void Navigate(string view)
        {
            HttpContext.Current.Response.Redirect(view, true);
        }
    }
}
