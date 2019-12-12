using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP_5101_FINAL_PatelKrishna
{
    public partial class culture_update : System.Web.UI.Page
    {
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
        protected void update_culture(object sender, EventArgs e)
        {
            blogDB db = new blogDB();
            string btnID = Session["culture_id"].ToString();
            string Culture_title = culture_title.Text;
            string Culture_about = culture_about.InnerText;
            string Menu_list = menu_list.Text;

            
            db.update_culture(Culture_title, Culture_about, Menu_list, btnID);
            Response.Redirect("~/culture_list.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var db = new blogDB();
                dropdownmenu(db);
                string btnID = Session["culture_id"].ToString();
                string query = "select * from culture_description where culture_id = " + btnID;
                List<Dictionary<String, String>> result = db.List_Query(query);

                foreach (Dictionary<String, String> row in result)
                {
                    string Culture_Id = row["culture_id"];
                    string Culture_Title = row["culture_title"];
                    string Culture_Body = row["culture_body"];
                    string Menu_Id = row["menu_id"];
                    culture_title.Text = Culture_Title;
                    culture_about.Value = Culture_Body;

                }

            }



        }
    }
}