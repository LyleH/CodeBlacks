using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class TestRunCompare : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string rawId = Request.QueryString["TestName"];
		if (!String.IsNullOrEmpty(rawId))
		{
			title.Text = rawId;
		}
		else
		{
			Debug.Fail("ERROR : We should never get to TestRunCompare.aspx without a valid TestName.");
			Response.Redirect("Default.aspx");
		}
		
    }
}