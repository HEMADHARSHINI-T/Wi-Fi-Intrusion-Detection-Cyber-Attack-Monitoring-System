using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Userlogin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=LAPTOP-TOTUH9FI;Initial Catalog=cyber_crime_test;User ID=sa;Password=saadmin");

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        //-------------------------------------------------
        // 🔹 Honeypot Detection (Bot Trap)
        //-------------------------------------------------
        if (!string.IsNullOrEmpty(username_confirm.Text))
        {
            con.Open();

            SqlCommand honeypotCmd = new SqlCommand(
            "INSERT INTO HoneytrapLogs(ipaddress,username_entered) VALUES(@ip,@user)", con);

            honeypotCmd.Parameters.AddWithValue("@ip", Request.UserHostAddress);
            honeypotCmd.Parameters.AddWithValue("@user", TextBox1.Text);

            honeypotCmd.ExecuteNonQuery();

            con.Close();

            Response.Redirect("Blocked.aspx");
            return;
        }

        string user = TextBox1.Text.Trim();
        string pass = TextBox2.Text.Trim();
        string ipaddress = Request.UserHostAddress;

        con.Open();

        //-------------------------------------------------
        // 🔹 CHECK LOGIN SUCCESS
        //-------------------------------------------------
        SqlCommand cmd = new SqlCommand("SELECT * FROM reg WHERE loginid=@u AND password=@p", con);
        cmd.Parameters.AddWithValue("@u", user);
        cmd.Parameters.AddWithValue("@p", pass);

        SqlDataReader dr = cmd.ExecuteReader();

        bool loginFailed = true;

        if (dr.Read())
        {
            loginFailed = false;

            Session["loginid"] = dr["loginid"].ToString();
            Session["mailid"] = dr["mailid"].ToString();
            Session["Name"] = dr["name"].ToString();
        }
        dr.Close();

        //-------------------------------------------------
        // 🔹 IF LOGIN FAILED → INCREMENT FAILED_ATTEMPTS
        //-------------------------------------------------
        if (loginFailed)
        {
            // Increase failed_attempts
            SqlCommand updateCmd = new SqlCommand(
            "UPDATE reg SET failed_attempts = ISNULL(failed_attempts,0) + 1 WHERE loginid=@user", con);

            updateCmd.Parameters.AddWithValue("@user", user);
            updateCmd.ExecuteNonQuery();

            //-------------------------------------------------
            // 🔍 GET CURRENT ATTEMPTS
            //-------------------------------------------------
            SqlCommand checkCmd = new SqlCommand(
            "SELECT failed_attempts FROM reg WHERE loginid=@user", con);

            checkCmd.Parameters.AddWithValue("@user", user);

            int attempts = Convert.ToInt32(checkCmd.ExecuteScalar());

            //-------------------------------------------------
            // 🚨 REDIRECT TO DECOY AFTER 3 ATTEMPTS
            //-------------------------------------------------
            if (attempts >= 3)
            {
                // store IP for decoy tracking


                Session["decoy_mode"] = true;
                Session["attack_ip"] = ipaddress;

                Session["Name"] = user;



                con.Close();

                Response.Redirect("DecoyHome.aspx?user=" + user);
                return;
            }
        }
        else
        {
            //-------------------------------------------------
            // 🔹 RESET FAILED ATTEMPTS ON SUCCESS
            //-------------------------------------------------
            SqlCommand resetCmd = new SqlCommand(
            "UPDATE reg SET failed_attempts = 0 WHERE loginid=@user", con);

            resetCmd.Parameters.AddWithValue("@user", user);
            resetCmd.ExecuteNonQuery();

            con.Close();

            Response.Redirect("UserHome.aspx");
            return;
        }

        //-------------------------------------------------
        // 🔹 LOG LOGIN ATTEMPT
        //-------------------------------------------------
        SqlCommand logCmd = new SqlCommand(
        "INSERT INTO LoginAttempts (LoginId,IPAddress,IsSuccess) VALUES (@u,@ip,@s)", con);

        logCmd.Parameters.AddWithValue("@u", user);
        logCmd.Parameters.AddWithValue("@ip", ipaddress);
        logCmd.Parameters.AddWithValue("@s", false);

        logCmd.ExecuteNonQuery();

        con.Close();

        Response.Write("<script>alert('Wrong Username or Password')</script>");
    }

    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    //-------------------------------------------------
    // 🔹 SECURITY QUESTION
    //-------------------------------------------------
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (TextBox4.Text == Session["answer"].ToString())
        {
            con.Open();

            SqlCommand cmd1 = new SqlCommand("update reg set w_entry='0' where loginid=@u", con);
            cmd1.Parameters.AddWithValue("@u", TextBox1.Text);

            cmd1.ExecuteNonQuery();

            con.Close();

            Response.Write("<script>alert('Answer is Correct....your Password is : " + Session["password"].ToString() + "')</script>");
        }
        else
        {
            con.Open();

            SqlCommand cmd1 = new SqlCommand("update reg set w_entry='7' where loginid=@u", con);
            cmd1.Parameters.AddWithValue("@u", TextBox1.Text);

            cmd1.ExecuteNonQuery();

            con.Close();

            Response.Write("<script>alert('Your Account is Blocked')</script>");
        }
    }
}