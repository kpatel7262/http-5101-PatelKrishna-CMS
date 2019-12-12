using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP_5101_FINAL_PatelKrishna
{
    public partial class culture_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            blogDB db = new blogDB();
            dropdownmenu(db);
        }

        protected void add_culture(object sender, EventArgs e)
        {
            blogDB db = new blogDB();
            string Culture_title = culture_title.Text;
            string Culture_about = culture_about.InnerText;
            string Menu_list = menu_list.Text;
            db.add_culture(Culture_title, Culture_about, Menu_list);
            Response.Redirect("~/culture_list.aspx");
        }

        protected void dropdownmenu(blogDB db)
        {

            string query = "select * from menu";
            List<Dictionary<String, String>> result = db.List_Query(query);
            foreach (Dictionary<String, String> row in result)
            {
                string menuitem = row["menu_title"];
                String menuid = row["menu_id"];
                ListItem menuOpt = new ListItem(menuitem, menuid);
                menu_list.Items.Add(menuOpt);
            }
        }

    }
}