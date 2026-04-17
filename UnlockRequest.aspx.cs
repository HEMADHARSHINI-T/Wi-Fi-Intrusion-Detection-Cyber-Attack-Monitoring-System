using System;
using System.Data.SqlClient;
using System.Net.Mail;

public partial class UnlockRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userAnswer = Request.Form["captcha"];

        // ✅ CAPTCHA CHECK
        if (Session["captcha_answer"] == null ||
            userAnswer != Session["captcha_answer"].ToString())
        {
            lblMsg.Text = "❌ Wrong answer";
            return;
        }

        string answer = userAnswer.Trim().ToLower();
        string correct = Session["captcha_answer"].ToString().ToLower();

        // allow both text + emoji
        if (!(answer == correct || answer == "blue"))
        {
            lblMsg.Text = "❌ Wrong answer";
            return;
        }

        string ip = Request.Form["ip"];

        string conStr = "Data Source=.;Initial Catalog=cyber_crime_test;Integrated Security=True";

        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();

            //-------------------------------------------------
            // 🛑 RATE LIMIT CHECK (ADD HERE)
            //-------------------------------------------------
            SqlCommand rateCmd = new SqlCommand(
            "SELECT COUNT(*) FROM UnlockRequests WHERE ip_address=@ip AND request_time > DATEADD(MINUTE,-5,GETDATE())", con);

            rateCmd.Parameters.AddWithValue("@ip", ip);

            int attempts = (int)rateCmd.ExecuteScalar();

            if (attempts > 3)
            {
                lblMsg.Text = "❌ Too many attempts. Try again later.";
                return;
            }

            //-------------------------------------------------
            // 🔐 GENERATE OTP
            //-------------------------------------------------
            Random rnd = new Random();
            string otp = rnd.Next(100000, 999999).ToString();

            Session["otp"] = otp;
            Session["otp_time"] = DateTime.Now;

            //-------------------------------------------------
            // 📧 SEND EMAIL
            //-------------------------------------------------
            MailMessage mail = new MailMessage();
            mail.To.Add("hemathaniga5@gmail.com"); // 🔥 CHANGE THIS
            mail.From = new MailAddress("dotnetinetz@gmail.com");
            mail.Subject = "OTP for Unlock";
            mail.Body = "Your OTP is: " + otp;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            

           smtp.Credentials = new System.Net.NetworkCredential(
    "hemathaniga5@gmail.com",
    "gsfqbwyjmjnmjzxq"   // ← App Password (NO spaces)
);
         
            

            smtp.Send(mail);

            //-------------------------------------------------
            // 💾 STORE REQUEST (IMPORTANT FOR RATE LIMIT)
            //-------------------------------------------------
            SqlCommand insertCmd = new SqlCommand(
            "INSERT INTO UnlockRequests (ip_address, request_time, status) VALUES (@ip, GETDATE(), 'Pending')", con);

            insertCmd.Parameters.AddWithValue("@ip", ip);
            insertCmd.ExecuteNonQuery();
        }

        //-------------------------------------------------
        // 🔁 REDIRECT
        //-------------------------------------------------
        Response.Redirect("VerifyOTP.aspx?ip=" + ip);
    }
}