using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class user_download2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Image1.ImageUrl=Request.QueryString["img"].ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        string file = Request.QueryString["img"].ToString();
        string output = Server.MapPath(file);


        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(output));
        Response.WriteFile(output);
        //Response.Flush();
        Response.End();
    }
}