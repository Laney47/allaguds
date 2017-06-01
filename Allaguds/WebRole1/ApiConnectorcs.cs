using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebRole1
{
    public class ApiConnectorcs
    {
        public String validateLogin(String param)
        {
            String responseMessage = " ";

            //We splitstring the messagebody to differentiate the username(substring[0]) from the password(substring[1])
            char delimitor = '*';
            String[] substrings = param.Split(delimitor);

            string URL = "http://datacollectapi20170528075302.azurewebsites.net/api/User/Login";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("?mail=" + substrings[0] + "&password=" + substrings[1]).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                responseMessage = "successLogin";


            }
            else
            {
                responseMessage = "failLogin";

            }

            return responseMessage;
        }
        public HttpResponseMessage GetLocationDataForUser(String param)
        {
            String responseMessage = " ";
            String email = param;

            //We splitstring the messagebody to differentiate the username(substring[0]) from the password(substring[1])

            string URL = "http://datacollectapi20170528075302.azurewebsites.net/api/Location/UserCollections";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("?owner=" + email).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                responseMessage = "successLogin";


            }
            else
            {
                responseMessage = "failLogin";

            }

            return response;
        }
        public HttpResponseMessage GetAccelDataForUser(String param)
        {
            String responseMessage = " ";

            //We splitstring the messagebody to differentiate the username(substring[0]) from the password(substring[1])

            String email = param;
            string URL = "http://datacollectapi20170528075302.azurewebsites.net/api/Accelerometer/UserCollections";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("?owner=" + email).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                responseMessage = "successLogin";


            }
            else
            {
                responseMessage = "failLogin";

            }

            return response;
        }
        public HttpResponseMessage GetHeartRateDataForUser(String param)
        {
            String responseMessage = " ";

            //We splitstring the messagebody to differentiate the username(substring[0]) from the password(substring[1])
            String email = param;

            string URL = "http://datacollectapi20170528075302.azurewebsites.net/api/Heartrate/UserCollections";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("?owner=" + email).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                responseMessage = "successLogin";


            }
            else
            {
                responseMessage = "failLogin";

            }

            return response;
        }
    }
}