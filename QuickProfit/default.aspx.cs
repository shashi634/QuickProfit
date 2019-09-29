using QuickProfit.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuickProfit
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"select publicId from users where username='"+txtUsername.Text+"' and password='"+txtPassword.Text+"'";
                var response  = DataBaseConnectionRoot.Instance.SelectQueryExecuter(query);
                if (response.Rows.Count > 0)
                {
                    // redirecting to somewhere
                }
                else {
                    lblMessage.Text = "Wrong Username and password!";
                    dvMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                DataBaseConnectionRoot.Instance.ExceptionLoggerToDataBase(ex);
                lblMessage.Text = "Something Wrong with input!";
                dvMessage.Visible = true;
            }
        }
    }
}