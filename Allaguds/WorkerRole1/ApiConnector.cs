using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace WorkerRole1
{
    class ApiConnector
    {
        

        public void validateLogin(String param)
        {
            String responseMessage = " ";
            WorkerQueue q = new WorkerQueue();

            //We splitstring the messagebody to differentiate the username(substring[0]) from the password(substring[1])
            char delimitor = '-';
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

            q.sendMessage(responseMessage);
        }


    }
}
