using System;
using System.Data.SqlClient;

public partial class VerifyOTP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // ❌ DO NOTHING HERE
        // OTP logic should NOT be in Page_Load
    }

    //-------------------------------------------------
    // ✅ VERIFY BUTTON CLICK
    //-------------------------------------------------
    protected void btnVerify_Click(object sender, EventArgs e)
    {
        string userOtp = txtOtp.Text;

        //-------------------------------------------------
        // 1️⃣ CHECK OTP EXISTS
        //-------------------------------------------------
        if (Session["otp"] == null)
        {
            lblMsg.Text = "Session expired. Try again.";
            return;
        }

        //-------------------------------------------------
        // 2️⃣ CHECK OTP MATCH
        //-------------------------------------------------
        if (userOtp != Session["otp"].ToString())
        {
            lblMsg.Text = "❌ Invalid OTP";
            return;
        }

        //-------------------------------------------------
        // 3️⃣ CHECK OTP EXPIRY (5 min)
        //-------------------------------------------------
        DateTime otpTime = Convert.ToDateTime(Session["otp_time"]);

        if ((DateTime.Now - otpTime).TotalMinutes > 5)
        {
            lblMsg.Text = "⏰ OTP expired";
            return;
        }

        //-------------------------------------------------
        // 4️⃣ GET IP
        //-------------------------------------------------
        string ip = Request.QueryString["ip"];

        if (string.IsNullOrEmpty(ip))
        {
            lblMsg.Text = "IP not found";
            return;
        }

        string conStr = "Data Source=.;Initial Catalog=cyber_crime_test;Integrated Security=True";

        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();

            //-------------------------------------------------
            // 5️⃣ REMOVE BLOCK
            //-------------------------------------------------
            SqlCommand cmd = new SqlCommand(
            "DELETE FROM BlockedIPs WHERE ip_address=@ip", con);

            cmd.Parameters.AddWithValue("@ip", ip);
            cmd.ExecuteNonQuery();

            //-------------------------------------------------
            // 6️⃣ UPDATE STATUS
            //-------------------------------------------------
            SqlCommand cmd2 = new SqlCommand(
            "UPDATE UnlockRequests SET status='Approved' WHERE ip_address=@ip", con);

            cmd2.Parameters.AddWithValue("@ip", ip);
            cmd2.ExecuteNonQuery();
        }

        //-------------------------------------------------
        // 7️⃣ CLEAR SESSION
        //-------------------------------------------------
        Session["otp"] = null;
        Session["otp_time"] = null;

        //-------------------------------------------------
        // 8️⃣ REDIRECT
        //-------------------------------------------------
        Response.Redirect("Home.aspx");
    }
}