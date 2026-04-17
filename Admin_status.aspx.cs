using System;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;

public partial class Admin_status : System.Web.UI.Page
{

SqlConnection con = new SqlConnection("Data Source=LAPTOP-TOTUH9FI;Initial Catalog=cyber_crime_test;User ID=sa;Password=saadmin");

protected void Page_Load(object sender, EventArgs e)
{
if (!IsPostBack)
{
LoadAttackTypeChart();
LoadTimelineChart();
LoadTopIPChart();   // NEW GRAPH FUNCTION
}
}

void LoadAttackTypeChart()
{
int failed = 0;
int success = 0;
int honeypot = 0;
int decoy = 0;


con.Open();

SqlCommand cmd = new SqlCommand(
"SELECT SUM(CASE WHEN IsSuccess = 0 THEN 1 ELSE 0 END) AS FailedLogins, " +
"SUM(CASE WHEN IsSuccess = 1 THEN 1 ELSE 0 END) AS SuccessfulLogins " +
"FROM LoginAttempts", con);

SqlDataReader dr = cmd.ExecuteReader();

if (dr.Read())
{
    if (dr["FailedLogins"] != DBNull.Value)
        failed = Convert.ToInt32(dr["FailedLogins"]);

    if (dr["SuccessfulLogins"] != DBNull.Value)
        success = Convert.ToInt32(dr["SuccessfulLogins"]);
}

dr.Close();

SqlCommand honeypotCmd = new SqlCommand("SELECT COUNT(*) FROM HoneytrapLogs", con);
honeypot = Convert.ToInt32(honeypotCmd.ExecuteScalar());

SqlCommand decoyCmd = new SqlCommand("SELECT COUNT(*) FROM attack", con);
decoy = Convert.ToInt32(decoyCmd.ExecuteScalar());

con.Close();

ChartAttackTypes.Series["AttackTypes"].Points.Clear();

ChartAttackTypes.Series["AttackTypes"].Points.AddXY("Brute Force", failed);
ChartAttackTypes.Series["AttackTypes"].Points.AddXY("Successful Login", success);
ChartAttackTypes.Series["AttackTypes"].Points.AddXY("Honeypot Trigger", honeypot);
ChartAttackTypes.Series["AttackTypes"].Points.AddXY("Decoy Redirect", decoy);

ChartAttackTypes.Series["AttackTypes"].Points[0].Color = System.Drawing.Color.Red;
ChartAttackTypes.Series["AttackTypes"].Points[1].Color = System.Drawing.Color.Green;
ChartAttackTypes.Series["AttackTypes"].Points[2].Color = System.Drawing.Color.Orange;
ChartAttackTypes.Series["AttackTypes"].Points[3].Color = System.Drawing.Color.Blue;

}

void LoadTimelineChart()
{
con.Open();


SqlCommand cmd = new SqlCommand(
"SELECT DATEPART(HOUR, AttemptTime) AS Hour, COUNT(*) AS Attempts " +
"FROM LoginAttempts GROUP BY DATEPART(HOUR, AttemptTime) ORDER BY Hour", con);

SqlDataReader dr = cmd.ExecuteReader();

ChartTimeline.Series["Timeline"].Points.Clear();

while (dr.Read())
{
    ChartTimeline.Series["Timeline"].Points.AddXY(
    dr["Hour"].ToString(),
    Convert.ToInt32(dr["Attempts"]));
}

dr.Close();
con.Close();


}

void LoadTopIPChart()
{
con.Open();


SqlCommand cmd = new SqlCommand(
"SELECT TOP 5 IPAddress, COUNT(*) AS Attempts " +
"FROM LoginAttempts " +
"WHERE IsSuccess = 0 " +
"GROUP BY IPAddress " +
"ORDER BY Attempts DESC", con);

SqlDataReader dr = cmd.ExecuteReader();

ChartTopIPs.Series["IPAttacks"].Points.Clear();

while (dr.Read())
{
    ChartTopIPs.Series["IPAttacks"].Points.AddXY(
    dr["IPAddress"].ToString(),
    Convert.ToInt32(dr["Attempts"]));
}

dr.Close();
con.Close();


}

}
