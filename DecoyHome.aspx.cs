using System;
using System.Data.SqlClient;

public partial class DecoyHome : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=LAPTOP-TOTUH9FI;Initial Catalog=cyber_crime_test;User ID=sa;Password=saadmin");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] != null)
        {
            lblUser.Text = "Hello, " + Session["Name"].ToString();
        }
        else
        {
            lblUser.Text = "Hello, Guest";
        }
    }

    protected void LogAction(object sender, EventArgs e)
    {
        string action = ((System.Web.UI.WebControls.Button)sender).Text;
        string ip = Request.UserHostAddress;

        con.Open();

        //-------------------------------------------------
        // 1️⃣ LOG ATTACK (already existing)
        //-------------------------------------------------
        SqlCommand cmd = new SqlCommand(
        "INSERT INTO attack (loginid, ipaddress, attacktime, attacktype) VALUES (@u,@ip,GETDATE(),@type)", con);

        cmd.Parameters.AddWithValue("@u", "DECOY_USER");
        cmd.Parameters.AddWithValue("@ip", ip);
        cmd.Parameters.AddWithValue("@type", "Decoy Interaction: " + action);

        cmd.ExecuteNonQuery();

        //-------------------------------------------------
        // 2️⃣ INCREASE RISK SCORE
        //-------------------------------------------------
        SqlCommand riskCmd = new SqlCommand(
        "UPDATE WifiDevices SET risk_score = ISNULL(risk_score,0) + 2 WHERE ip_address=@ip", con);

        riskCmd.Parameters.AddWithValue("@ip", ip);
        riskCmd.ExecuteNonQuery();

        //-------------------------------------------------
        // 3️⃣ GET UPDATED RISK SCORE
        //-------------------------------------------------
        SqlCommand getCmd = new SqlCommand(
        "SELECT ISNULL(risk_score,0) FROM WifiDevices WHERE ip_address=@ip", con);

        getCmd.Parameters.AddWithValue("@ip", ip);

        int risk = Convert.ToInt32(getCmd.ExecuteScalar());

        //-------------------------------------------------
        // 4️⃣ CHECK BLOCK CONDITION
        //-------------------------------------------------
        if (risk > 5)
        {
            //-------------------------------------------------
            // BLOCK USER
            //-------------------------------------------------
            SqlCommand blockCmd = new SqlCommand(
            "INSERT INTO BlockedIPs (ip_address,blocked_time) VALUES (@ip,GETDATE())", con);

            blockCmd.Parameters.AddWithValue("@ip", ip);
            blockCmd.ExecuteNonQuery();

            con.Close();

            //-------------------------------------------------
            // REDIRECT TO CAPTCHA + OTP FLOW
            //-------------------------------------------------
            Response.Redirect("Home.aspx");
            return;
        }

        con.Close();

        //-------------------------------------------------
        // 5️⃣ NORMAL DECOY RESPONSE
        //-------------------------------------------------
        Response.Write("<script>alert('Monitoring activity...');</script>");
    }
}