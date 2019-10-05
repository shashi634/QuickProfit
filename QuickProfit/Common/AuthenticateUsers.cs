using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickProfit.Common
{
    public class AuthenticateUsers : System.Web.UI.MasterPage
    {
        protected AuthenticateUsers()
        {
            var currentContext = HttpContext.Current.User.IsInRole("Admin");
        }
    }
}