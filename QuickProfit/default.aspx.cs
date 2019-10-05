using System;
using QuickProfit.Common;
using static QuickProfit.Common.DataBaseConnectionRoot;

namespace QuickProfit
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Making Query to get data from DataBAse
                // TODO: Here we need to encrypt password as we are doing while registration.
                var query = @"select publicId,UserRole,Name,ActivationDate from users where username='"+txtUsername.Text+"' and password='"+txtPassword.Text+"'";
                if (Instance == null) return;
                var response  = Instance.SelectQueryExecuter(query);
                if (response.Rows.Count > 0)
                {
                    ///////////////////////////////////////////////////////////////////////////////
                    ///////////////////// First we will check if user is activated ////////////////
                    ///////////////////// Then we will check if this is admin role ////////////////
                    ///////////////////// If all condition satisfied then redirect ////////////////
                    ///////////////////////////////////////////////////////////////////////////////
                    if (string.IsNullOrEmpty(Convert.ToString(response.Rows[0]["ActivationDate"])))
                    {
                        lblMessage.Text = "Account is not activated! Contact Admin.";
                        dvMessage.Visible = true;
                    }
                    else
                    {
                        var userRoleValue = 0;
                        switch (Convert.ToString(response.Rows[0]["UserRole"]))
                        {
                            case "1":
                                Session["qpadminSession"] = response.Rows[0]["publicId"] +"~"+ response.Rows[0]["Name"];
                                userRoleValue = (int) UserTypes.Admin;
                                break;
                            case "2":
                                Session["qpuserSession"] = response.Rows[0]["publicId"] + "~" + response.Rows[0]["Name"];
                                userRoleValue = (int) UserTypes.User;
                                break;
                        }
                        
                        Response.Redirect(userRoleValue == 1 ? "/Admino" : "dashboard.aspx");
                    }
                }
                else {
                    lblMessage.Text = "Wrong Username and password!";
                    dvMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Instance?.ExceptionLoggerToDataBase(ex);
                lblMessage.Text = "Something Wrong with input!";
                dvMessage.Visible = true;
            }
        }
    }
}