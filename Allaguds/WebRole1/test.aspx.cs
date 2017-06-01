using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebRole1
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String email = Request.Form["SendA"];
            textLabel.Text = email;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String username = userBox.Text.ToString();
            String password = passBox.Text.ToString();

            String message = username + "*" + password;
            ApiConnectorcs api = new ApiConnectorcs();
            String response = api.validateLogin(message);
            if (response.Equals("successLogin"))
            {
                Session["email"] = username;
                Response.Redirect("AppendData.aspx");
            }
            else
            {

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
        }

        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static String MyMethod()
        {
            
            return "Method called!";
        }
        
    }
}