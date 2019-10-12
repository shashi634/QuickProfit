using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuickProfit.Admino
{
    public partial class AdvanceTemplate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["qpadminSession"] == null)
                {
                    Response.Redirect("/");
                }
                else
                {
                    var adminDetails = Session["qpadminSession"].ToString().Split('~');
                    
                }
            }
        }
    }
}