using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class Admin_upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-TOTUH9FI;Initial Catalog=cyber_crime;User ID=sa;Password=saadmin");

        //SqlConnection con = new SqlConnection(@"Data source=LAPTOP-TOTUH9FI;Database=cyber_crime;Integrated security=true"); 
        //string path1 = "~/uploads/" + FileUpload1.FileName;
        if (FileUpload1.HasFile)
        {
            string extension = Path.GetExtension(FileUpload1.FileName).ToLower();

            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
            {
                string fileName = Path.GetFileName(FileUpload1.FileName);
                string path1 = "~/uploads/" + fileName;

                // Save File
                FileUpload1.SaveAs(Server.MapPath(path1));

                // Insert into Database (Using Parameters - Secure Way)
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into img values('" + TextBox1.Text + "','" + path1 + "')", con);
                cmd1.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Added Successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Only JPG and PNG files are allowed!');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Please select a file!');</script>");
        }
    }
}