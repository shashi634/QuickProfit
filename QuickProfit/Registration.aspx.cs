using QuickProfit.Common;
using System;

namespace QuickProfit
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handel User Registration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataBaseConnectionRoot.Instance.UserSignup(txtname.Text, txtUsername.Text, txtPassword.Text, txtPhone.Text, txtEmailId.Text, UserTypes.User))
                {
                    divMsgSuccess.Visible = true;
                    lblMsgSuccess.Text = "Registration Done, Check your Email.";
                }
                else {
                    dvMessage.Visible = true;
                    lblMessage.Text = "Wrong Entry! Try Again.";
                }
            }
            catch (Exception ex)
            {
                DataBaseConnectionRoot.Instance.ExceptionLoggerToDataBase(ex);
            }
        }
    }
}