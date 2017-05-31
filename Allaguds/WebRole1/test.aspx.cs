using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.ComponentModel;
using DotNetOpenAuth.Configuration;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using System.Web.Security;

namespace WebRole1
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var openid = new OpenIdRelyingParty();
            var response = openid.GetResponse();
            //Checks whether user is authenticated or not
            if (response != null && response.Status == AuthenticationStatus.Authenticated && response.Provider.Uri == new Uri("https://www.google.com/accounts/o8/ud"))
            {
                var fetch = response.GetExtension<FetchResponse>();
                string email = String.Empty;
                if (fetch != null)
                {
                    email = fetch.GetAttributeValue(WellKnownAttributes.Contact.Email); //Fetching requested emailid

                }
                //To make it more secure you can use response.ClaimedIdentifier as user identity instead of email.
                FormsAuthentication.RedirectFromLoginPage(email.Trim(), false);
                // You can maintain your custom session here for login purpose
                //instead of FormsAuthentication, email is took here as user identity.

            }
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

            String message = "validateinfo*" + username + "-" + password;

            WebQueue q = new WebQueue();
            q.sendMessage(message);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (OpenIdRelyingParty openid = new OpenIdRelyingParty())
            {
                var request = openid.CreateRequest("https://www.google.com/accounts/o8/id");

                var fetch = new FetchRequest();
                fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Email); // Request for email id
                request.AddExtension(fetch); // Adding in request obj
                request.RedirectToProvider();
            }
        }
    }
}