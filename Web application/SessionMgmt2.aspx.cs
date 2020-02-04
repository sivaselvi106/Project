using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SessionMgmt2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Clicks"] == null)
                {
                    Session["Clicks"] = 0;
                }
                CountTextBox.Text = Session["Clicks"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int ClickCount = (int)Session["Clicks"] + 1;
            CountTextBox.Text = ClickCount.ToString();
            Session["Clicks"] = ClickCount;
        }
    }
}