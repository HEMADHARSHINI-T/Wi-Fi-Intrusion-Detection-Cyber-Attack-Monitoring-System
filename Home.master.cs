using System;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (string.IsNullOrEmpty(ip))
            ip = Request.ServerVariables["REMOTE_ADDR"];

        string userAgent = Request.UserAgent;

        // IP
        lblIP.Text = ip;

        // Browser
        if (userAgent.Contains("Edg/"))
            lblBrowser.Text = "Microsoft Edge";
        else if (userAgent.Contains("Chrome"))
            lblBrowser.Text = "Chrome";
        else if (userAgent.Contains("Firefox"))
            lblBrowser.Text = "Firefox";
        else
            lblBrowser.Text = "Unknown";

        // OS
        if (userAgent.Contains("Windows"))
            lblOS.Text = "Windows";
        else if (userAgent.Contains("Android"))
            lblOS.Text = "Android";
        else if (userAgent.Contains("Mac"))
            lblOS.Text = "MacOS";
        else
            lblOS.Text = "Unknown";

        // Request Count
        string connectionString = "Data Source=.;Initial Catalog=cyber_crime_test;Integrated Security=True";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM ConnectionLogs WHERE ip_address=@ip", con);

            cmd.Parameters.AddWithValue("@ip", ip);

            int requestCount = (int)cmd.ExecuteScalar();

            lblRequests.Text = requestCount.ToString();
        }
    }
}