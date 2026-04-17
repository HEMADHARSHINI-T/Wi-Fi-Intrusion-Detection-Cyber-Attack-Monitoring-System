using System;

public partial class Captcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Random rnd = new Random();

            int num1 = rnd.Next(1, 9);
            int num2 = rnd.Next(1, 9);

            Session["captcha_answer"] = num1 + num2;

            lblCaptcha.Text = num1 + " + " + num2 + " = ?";
        }
    }

    protected void btnVerify_Click(object sender, EventArgs e)
    {
        if (txtCaptcha.Text == Session["captcha_answer"].ToString())
        {
            Response.Redirect("Userlogin.aspx");
        }
        else
        {
            Response.Write("<script>alert('Wrong CAPTCHA')</script>");
        }
    }
}