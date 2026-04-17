using System;
using System.Data;
using System.Data.SqlClient;

public partial class AdminHoneytrapLogs : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=LAPTOP-TOTUH9FI;Initial Catalog=cyber_crime_test;User ID=sa;Password=saadmin");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadLogs();
        }
    }

    void LoadLogs()
    {
        con.Open();

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HoneytrapLogs ORDER BY logtime DESC", con);

        DataTable dt = new DataTable();
        da.Fill(dt);

        GridView1.DataSource = dt;
        GridView1.DataBind();

        con.Close();
    }
}