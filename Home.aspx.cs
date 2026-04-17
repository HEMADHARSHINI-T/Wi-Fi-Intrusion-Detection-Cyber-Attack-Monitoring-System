using System;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        Response.Cache.SetExpires(DateTime.UtcNow.AddSeconds(-1));

        string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (string.IsNullOrEmpty(ip))
            ip = Request.ServerVariables["REMOTE_ADDR"];

        string connectionString = "Data Source=.;Initial Catalog=cyber_crime_test;Integrated Security=True";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            //-------------------------------------------------
            //  URL SCAN DETECTION 
            //-------------------------------------------------
            string scanParam = Request.QueryString["scan"];

            if (!string.IsNullOrEmpty(scanParam))
            {
                if (scanParam.ToLower().Contains("admin") ||
                    scanParam.ToLower().Contains("config"))
                {
                    //  Log suspicious scan
                    SqlCommand scanCmd = new SqlCommand(
"INSERT INTO UrlScanLogs (ip_address, url_attempted, detected_time) VALUES (@ip,@scan,GETDATE())", con);
                    scanCmd.Parameters.AddWithValue("@ip", ip);
                    scanCmd.Parameters.AddWithValue("@scan", scanParam);

                    scanCmd.ExecuteNonQuery();

                    // Increase risk score
                    SqlCommand riskCmd = new SqlCommand(
                    "UPDATE WifiDevices SET risk_score = ISNULL(risk_score,0) + 2 WHERE ip_address=@ip", con);

                    riskCmd.Parameters.AddWithValue("@ip", ip);
                    riskCmd.ExecuteNonQuery();

                    Response.Write("<br>🚨 Reconnaissance Scan Detected!");
                }
            }

            //-------------------------------------------------
            //  DEVICE DETECTION
            //-------------------------------------------------
            string userAgent = Request.UserAgent;

            string browser = "Unknown";
            if (userAgent.Contains("Edg")) browser = "Edge";
            else if (userAgent.Contains("Chrome")) browser = "Chrome";
            else if (userAgent.Contains("Firefox")) browser = "Firefox";

            string os = "Unknown";
            if (userAgent.Contains("Windows")) os = "Windows";
            else if (userAgent.Contains("Android")) os = "Android";
            else if (userAgent.Contains("Mac")) os = "Mac";

            //-------------------------------------------------
            // INSERT / UPDATE DEVICE
            //-------------------------------------------------
            SqlCommand deviceCmd = new SqlCommand(@"
IF EXISTS (SELECT 1 FROM WifiDevices WHERE ip_address=@ip)
    UPDATE WifiDevices 
    SET device_name=@browser, operating_system=@os
    WHERE ip_address=@ip
ELSE
    INSERT INTO WifiDevices (ip_address, device_name, operating_system, risk_score)
    VALUES (@ip, @browser, @os, 0)
", con);

            deviceCmd.Parameters.AddWithValue("@ip", ip);
            deviceCmd.Parameters.AddWithValue("@browser", browser);
            deviceCmd.Parameters.AddWithValue("@os", os);

            deviceCmd.ExecuteNonQuery();

            //-------------------------------------------------
            // 1 BLOCK CHECK
            //-------------------------------------------------
            SqlCommand blockCheck = new SqlCommand(
            "SELECT COUNT(*) FROM BlockedIPs WHERE ip_address=@ip", con);

            blockCheck.Parameters.AddWithValue("@ip", ip);

            int blocked = (int)blockCheck.ExecuteScalar();

            if (blocked > 0)
            {
                string[] symbols = { "🔴", "🔵" };
                string[] colorNames = { "red", "blue" };

                string seq = "";
                for (int i = 0; i < 5; i++)
                {
                    seq += symbols[i % 2] + " ";
                }

                string answer = colorNames[5 % 2];
                Session["captcha_answer"] = answer;

                Response.Write(@"
<div style='text-align:center;margin-top:50px;'>

<h2 style='color:red;'>🚫 Access Blocked</h2>

<p>Complete the sequence:</p>
<h3>" + seq + @" → ?</h3>

<form method='post' action='UnlockRequest.aspx'>

<input type='hidden' name='ip' value='" + ip + @"' />

<input type='text' name='captcha' placeholder='Enter next symbol' required />

<br><br>

<button style='padding:10px 20px;background:green;color:white;border:none;'>
Submit
</button>

</form>

</div>
");

                Response.End();
            }

            //-------------------------------------------------
            // 2️ LOG REQUEST
            //-------------------------------------------------
            SqlCommand logCmd = new SqlCommand(
            "INSERT INTO ConnectionLogs (ip_address,request_count,log_time) VALUES (@ip,1,GETDATE())", con);

            logCmd.Parameters.AddWithValue("@ip", ip);
            logCmd.ExecuteNonQuery();

            //-------------------------------------------------
            // 3️ TOTAL REQUEST COUNT 
            //-------------------------------------------------
            SqlCommand countCmd = new SqlCommand(
            "SELECT COUNT(*) FROM ConnectionLogs WHERE ip_address=@ip", con);

            countCmd.Parameters.AddWithValue("@ip", ip);

            int requestCount = (int)countCmd.ExecuteScalar();

            //-------------------------------------------------
            // 4️ ATTACK DETECTION
            //-------------------------------------------------
            if (requestCount > 30)
            {
                Response.Write("<br>🚨 ATTACK DETECTED");

                SqlCommand suspiciousCmd = new SqlCommand(
                "INSERT INTO SuspiciousDevices (ip_address,reason,detected_time) VALUES (@ip,'Rapid requests detected',GETDATE())", con);

                suspiciousCmd.Parameters.AddWithValue("@ip", ip);
                suspiciousCmd.ExecuteNonQuery();

                //-------------------------------------------------
                // 5️ BLOCK IP
                //-------------------------------------------------
                SqlCommand blockCmd = new SqlCommand(
                "INSERT INTO BlockedIPs (ip_address,blocked_time) VALUES (@ip,GETDATE())", con);

                blockCmd.Parameters.AddWithValue("@ip", ip);
                blockCmd.ExecuteNonQuery();
            }
        }
    }
}