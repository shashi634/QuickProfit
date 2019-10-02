using QuickProfit.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuickProfit
{
    public partial class Downlines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                UsersList.DataSource = DataBaseConnectionRoot.Instance.SelectQueryExecuter("select * from users");
                UsersList.DataBind();
            }
        }
        protected void users_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UsersList.PageIndex = e.NewPageIndex;
            UsersList.DataSource = DataBaseConnectionRoot.Instance.SelectQueryExecuter("select * from users");
            UsersList.DataBind();
        }
    }
}