using System;
using System.Data;
using System.Data.SqlClient;

public partial class AdminWifiMonitor : System.Web.UI.Page
{
    string connectionString = "Data Source=.;Initial Catalog=cyber_crime_test;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        {
            LoadDevices();
            LoadSuspicious();
            LoadLogs();
            LoadUrlScanLogs();
            LoadAttackCounter();
            LoadAttackGraph();

        }
    }

    // -------------------------------
    // LOAD WIFI DEVICES
    // -------------------------------
    void LoadDevices()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT ip_address, device_name, operating_system, risk_score FROM WifiDevices", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridViewDevices.DataSource = dt;
            GridViewDevices.DataBind();
        }
    }

    // -------------------------------
    // LOAD SUSPICIOUS DEVICES
    // -------------------------------
    void LoadSuspicious()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT ip_address, reason, detected_time FROM SuspiciousDevices", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridViewSuspicious.DataSource = dt;
            GridViewSuspicious.DataBind();
        }
    }

    // -------------------------------
    // LOAD CONNECTION LOGS
    // -------------------------------
    void LoadLogs()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT ip_address, request_count, log_time FROM ConnectionLogs", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            Response.Write("<br>Logs Count: " + dt.Rows.Count);

            GridViewLogs.DataSource = dt;
            GridViewLogs.DataBind();
        }
    }

    // -------------------------------
    // LOAD URL SCAN LOGS
    // -------------------------------
    void LoadUrlScanLogs()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT ip_address, url_attempted, detected_time FROM UrlScanLogs", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridViewUrlScan.DataSource = dt;
            GridViewUrlScan.DataBind();
        }
    }

    // -------------------------------
    // LOAD ATTACK COUNT
    // -------------------------------
    void LoadAttackCounter()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            SqlCommand cmd = new SqlCommand(
            "SELECT COUNT(*) FROM SuspiciousDevices", con);

            int attackCount = (int)cmd.ExecuteScalar();

            lblAttackCount.Text = "Total Attacks Detected: " + attackCount;
        }
    }

    // -------------------------------
    // LOAD GRAPH DATA
    // -------------------------------
    void LoadAttackGraph()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlDataAdapter da = new SqlDataAdapter(
            "SELECT ip_address, COUNT(*) as attack_count FROM SuspiciousDevices GROUP BY ip_address", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            AttackChart.Series["Attacks"].Points.DataBindXY(
            dt.DefaultView, "ip_address", dt.DefaultView, "attack_count");
        }
    }


}