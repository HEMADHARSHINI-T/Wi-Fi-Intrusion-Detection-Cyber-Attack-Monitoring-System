using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class register : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=LAPTOP-TOTUH9FI;Initial Catalog=cyber_crime;User ID=sa;Password=saadmin");

    //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Write("Hii");
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from reg where loginid='" + loginid.Text + "'", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Response.Write("<script>alert('Sorry....Another user already used in login id')</script>");
        }
        else
        {
            try
            {
                con.Close();
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into reg values('" + loginid.Text + "','" + password.Text + "','" + fname.Text + "','" + gender.Text + "','" + dob.Text + "','" + country.Text + "','" + address.Text + "','" + mailid.Text + "','" + mobile.Text + "','"+s_q.Text +"','"+s_a.Text+"','0')", con);
                cmd1.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Register....Success')</script>");
                Response.Write("<script>window.location='Userlogin.aspx'</script>");
            }
            catch (Exception ex)
            {
                Label6.Text = "Error :" + ex;
            }
        }
        fname.Text = "";
        //Lname.Text = "";
        mailid.Text = "";
        loginid.Text = "";
        password.Text = "";
    }
}