using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP_5101_FINAL_PatelKrishna
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void list_page(object sender, EventArgs e)
        {
            Response.Redirect("~/culture_list.aspx");
        }
    }
}