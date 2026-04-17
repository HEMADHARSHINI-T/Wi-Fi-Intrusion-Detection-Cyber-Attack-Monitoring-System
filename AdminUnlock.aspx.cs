using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class AdminUnlock : System.Web.UI.Page
{
    string conStr = "Data Source=.;Initial Catalog=cyber_crime_test;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadRequests();
        }
    }

    //-------------------------------------------------
    // LOAD ALL UNLOCK REQUESTS
    //-------------------------------------------------
    void LoadRequests()
    {
        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(@"
SELECT 
    u.ip_address,
    w.device_name AS browser,
    w.operating_system AS os,
    u.request_time,
    u.status
FROM UnlockRequests u
LEFT JOIN WifiDevices w 
ON u.ip_address = w.ip_address
", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridViewUnlock.DataSource = dt;
            GridViewUnlock.DataBind();
        }
    }

    //-------------------------------------------------
    // 🔓 UNLOCK BUTTON CLICK
    //-------------------------------------------------
    protected void GridViewUnlock_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Unlock")
        {
            string ip = e.CommandArgument.ToString();

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                //-------------------------------------------------
                // 🔥 1️⃣ GET CURRENT STATUS
                //-------------------------------------------------
                SqlCommand getStatusCmd = new SqlCommand(
                "SELECT status FROM UnlockRequests WHERE ip_address=@ip", con);

                getStatusCmd.Parameters.AddWithValue("@ip", ip);

                string status = Convert.ToString(getStatusCmd.ExecuteScalar());

                //-------------------------------------------------
                // ❌ BLOCK UNLOCK IF SUSPICIOUS
                //-------------------------------------------------
                if (status == "Suspicious")
                {
                    // Do NOT unlock
                    return;
                }

                //-------------------------------------------------
                // 🔥 2️⃣ COOLDOWN CHECK (ATTACK DETECTION)
                //-------------------------------------------------
                SqlCommand cooldownCmd = new SqlCommand(
                "SELECT COUNT(*) FROM UnlockRequests WHERE ip_address=@ip AND request_time > DATEADD(MINUTE,-1,GETDATE())", con);

                cooldownCmd.Parameters.AddWithValue("@ip", ip);

                int recentRequests = (int)cooldownCmd.ExecuteScalar();

                if (recentRequests > 3)
                {
                    // Mark as attacker
                    SqlCommand markCmd = new SqlCommand(
                    "UPDATE UnlockRequests SET status='Attacker' WHERE ip_address=@ip", con);

                    markCmd.Parameters.AddWithValue("@ip", ip);
                    markCmd.ExecuteNonQuery();

                    return; // ❌ DO NOT UNLOCK
                }

                //-------------------------------------------------
                // ✅ 3️⃣ REMOVE FROM BLOCKED LIST
                //-------------------------------------------------
                SqlCommand cmd1 = new SqlCommand(
                "DELETE FROM BlockedIPs WHERE ip_address=@ip", con);

                cmd1.Parameters.AddWithValue("@ip", ip);
                cmd1.ExecuteNonQuery();

                //-------------------------------------------------
                // ✅ 4️⃣ UPDATE STATUS
                //-------------------------------------------------
                SqlCommand cmd2 = new SqlCommand(
                "UPDATE UnlockRequests SET status='Approved' WHERE ip_address=@ip", con);

                cmd2.Parameters.AddWithValue("@ip", ip);
                cmd2.ExecuteNonQuery();
            }

            //-------------------------------------------------
            // 🔄 REFRESH GRID
            //-------------------------------------------------
            LoadRequests();
        }
    }
}