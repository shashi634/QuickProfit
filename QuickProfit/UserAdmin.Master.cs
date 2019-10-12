using System;
using QuickProfit.Common;

namespace QuickProfit
{
    public partial class UserAdmin : AuthenticateUsers
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["qpuserSession"] == null)
                {
                    Response.Redirect("/");
                }
            }
        }
    }
}