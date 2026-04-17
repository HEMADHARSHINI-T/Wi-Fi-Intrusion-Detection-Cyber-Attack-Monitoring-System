using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class User_Request : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=LAPTOP-TOTUH9FI;Initial Catalog=cyber_crime;User ID=sa;Password=saadmin");

    //SqlConnection con = new SqlConnection(@"Data source=LAPTOP-TOTUH9FI;Database=cyber_crime;Integrated security=true");
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd11 = new SqlCommand("select * from reg where s_q='" + TextBox3.Text + "' and s_a='" + TextBox4.Text + "'", con);


        SqlDataReader dr11 = cmd11.ExecuteReader();
        if (dr11.Read())
        {
            string name = dr11["name"].ToString();
            string id = dr11["loginid"].ToString();
            dr11.Close();

            if (id != null)
            {
            SqlCommand cmd= new SqlCommand("insert into Request values('" + id + "','" + name + "','" + TextBox3.Text + "','" + TextBox4.Text + "','Request')", con);
                cmd.ExecuteNonQuery();                
                Response.Write("<script>alert('Your Request Reached to Admin');</script>");
            }
        }
        else 
        {
                
            Response.Write("<script>alert('Not a Valid User......!!!!!,Account Blocked');</script>");
           
        }
        con.Close();
    }
}