using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Admin_modify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-TOTUH9FI;Initial Catalog=cyber_crime;User ID=sa;Password=saadmin");

        //SqlConnection con = new SqlConnection(@"Data source=LAPTOP-TOTUH9FI;Database=cyber_crime;Integrated security=true"); 
        con.Close();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("Select * from img", con);
        DataTable dt = new DataTable();
        da1.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        con.Close();
    }
}