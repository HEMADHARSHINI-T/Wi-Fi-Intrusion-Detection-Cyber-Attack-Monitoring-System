using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Text;
using System.Data.SqlClient;

public partial class Admin_request2 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=LAPTOP-TOTUH9FI;Initial Catalog=cyber_crime;User ID=sa;Password=saadmin");


    //SqlConnection con = new SqlConnection(@"Data source=LAPTOP-TOTUH9FI;Database=cyber_crime;Integrated security=true");
    SqlCommand cmd;
    string Mobile=null;
    string num=null;
    string password = null;
    string login = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        login = Request.QueryString["loginid"];
        cmd=new SqlCommand("Select mobile from reg where loginid='"+login+"'",con);
        SqlDataReader dr=cmd.ExecuteReader();
        if(dr.Read())
        {
            Mobile=dr["mobile"].ToString();
            string Number = generatepassword1();
       
        }        
    }
    public string SendMessage(string number)
    {
        string url = "http://login.bulksmsgateway.in/sendmessage.php";
        string result = "";
        String strPost = "?user=indnaren&password=technologies123&sender=Fabsys&mobile=" + Mobile + "&type=3&message=" + number;
        StreamWriter myWriter = null;
        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strPost);
        objRequest.Method = "POST";
        objRequest.ContentLength = Encoding.UTF8.GetByteCount(strPost);
        objRequest.ContentType = "application/x-www-form-urlencoded";
        try
        {
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(strPost);
            myWriter.Close();
            //MessageBox.Show("Message Success");
        }
        catch (Exception e)
        {
            return e.Message;
            //MessageBox.Show("Message Not Send");
        }
        finally
        {

        }
        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
        {
            result = sr.ReadToEnd();
            // Close and clean up the StreamReader sr.Close();
        }
        return result;
       
    }

    private string generatepassword1()
    {
        string paswordchar = "abcdefghijklmnopqrstuvwxyz0123456789!@$&#+ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        Random rand = new Random((int)DateTime.Now.Second & 0x0000FFFF);
        for (int i = 0; i <= 6; i++)
        {
            int irand = rand.Next(0, paswordchar.Length - 1);
            password += paswordchar.Substring(irand, 1);
            SendMessage(password);
        }
        return password;
    }

    public void Update()
    {
        con.Open();
        cmd= new SqlCommand("Update set OTP='"+password+"' where loginid='"+login+"'",con);
    }
}