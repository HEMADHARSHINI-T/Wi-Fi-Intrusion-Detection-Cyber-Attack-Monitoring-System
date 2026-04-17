using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adminlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (TextBox3.Text == "Admin" && TextBox4.Text == "Admin")
        {

            Response.Redirect("Adminhome.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Incorrect Username and password');", true);
        }
    }
}