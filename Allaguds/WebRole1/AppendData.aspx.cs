using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;


namespace WebRole1
{
    public partial class AppendData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String mail = (String)(Session["mail"]);
            ApiConnectorcs api = new ApiConnectorcs();
            //HttpResponseMessage Accelresponse = api.GetAccelDataForUser(mail);
           // HttpResponseMessage Locationresponse = api.GetLocationDataForUser(mail);
            HttpResponseMessage HeartRateresponse = api.GetHeartRateDataForUser(mail);
            String text = HeartRateresponse.ToString();
            testLabel.Text = text;
            


        }
    }
}