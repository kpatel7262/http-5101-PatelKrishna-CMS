using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP_5101_FINAL_PatelKrishna
{
    public partial class culture_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new blogDB();
            string query = "Select culture_id,culture_title, culture_body, menu_title from culture_description inner join menu on menu.menu_id = culture_description.menu_id";
            List<Dictionary<String, String>> result = db.List_Query(query);


            foreach (Dictionary<String, String> row in result)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl createDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.Attributes["class"] = "controls_container";

                string Culture_id = row["culture_id"];
                string Culture_title = row["culture_title"];
                string Culture_body = row["culture_body"];
                string Menu_title = row["menu_title"];

                culture_items.InnerHtml += "<div>" + Culture_title + "</div>";
                about_items.InnerHtml += "<div>" + Culture_body + "</div>";
                menu_items.InnerHtml += "<div>" + Menu_title + "</div>";

                Button BtnUpdate = new Button()
                {
                    Text = "Update",
                    ID = "Update/" + Culture_id,
                    CssClass = "crud_button"
                };

                Button BtnDelete = new Button()
                {
                    Text = "Delete",
                    ID = "Delete/" + Culture_id,
                    CssClass = "crud_button",
                    OnClientClick = "return ValidateDelete()"
                };

                createDiv.Controls.Add(BtnUpdate);
                createDiv.Controls.Add(BtnDelete);
                list_controls.Controls.Add(createDiv);
                BtnUpdate.Click += new EventHandler(UpdateData);
                BtnDelete.Click += new EventHandler(DeleteData);

            }
        }

        protected void add(object sender, EventArgs e)
        {
            Response.Redirect("~/culture_add.aspx");
        }

        protected void UpdateData(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string[] numButtonID = button.ID.Split('/');
            Session["culture_id"] = numButtonID[1];
            Response.Redirect("~/culture_update.aspx");

        }

        protected void DeleteData(object sender, EventArgs e)
        {
            blogDB db = new blogDB();
            Button button = (Button)sender;
            //James in July 2,2013 https://stackoverflow.com/questions/17421375/how-to-get-numbers-from-a-string-and-store-it-in-a-variable-in-c-sharp
            string[] numButtonID = button.ID.Split('/');
            //string buttonId = button.CssClass;       
            var query = "DELETE FROM culture_description WHERE culture_id =" + numButtonID[1];

            List<Dictionary<String, String>> rs = db.List_Query(query);
            //Debug.WriteLine(query);
            Response.Redirect("~/culture_list.aspx");
            //Debug.WriteLine(buttonId);
            //Debug.WriteLine("End of Delete");
        }

    }

}