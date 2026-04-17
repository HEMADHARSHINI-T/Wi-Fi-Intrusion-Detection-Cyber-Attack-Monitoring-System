using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Admin_modify2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-TOTUH9FI;Initial Catalog=cyber_crime;User ID=sa;Password=saadmin");

        //SqlConnection con = new SqlConnection(@"Data source=LAPTOP-TOTUH9FI;Database=cyber_crime;Integrated security=true"); 
        con.Open();
        string a=Request.QueryString["id"].ToString();
        string b=Request.QueryString["name"].ToString();
        SqlCommand cmd = new SqlCommand("Delete from img where id='" + a + "' and filename='" + b + "'",con);
        cmd.ExecuteNonQuery();
        Response.Write("<script>alert('Record Deleted....')</script>");
        Response.Write("<script>window.location='Admin_modify.aspx'</script>");
        con.Close();
    }
}