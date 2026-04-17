using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class user_disease : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-TOTUH9FI;Initial Catalog=cyber_crime;User ID=sa;Password=saadmin");

        //SqlConnection con = new SqlConnection(@"Data source=LAPTOP-TOTUH9FI;Database=cyber_crime;Integrated security=true"); 
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from img", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.EmptyDataText = "No Data Found";
        GridView1.DataBind();
        con.Close();
    }
}