using System;
using System.IO;
using System.Net;

namespace Jira.Api
{
    public class JiraApi
    {
        public string Server { get; set; }
        public JiraCredentials Credentials { get; set; }

        public JiraApi(string server, JiraCredentials credentials)
        {
            Server = server;
            Credentials = credentials;
        }



        public string ExecuteRequest(   ApiRequest apiRequest,
                                        string data = null,
                                        string method = "GET")
        {
            string url = null;
            HttpWebRequest request = null;


            url = BuildUrl(apiRequest.ToString());

            request = BuildHttpRequest(url, method, data, Credentials);

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            string result = string.Empty;

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

       

        private HttpWebRequest BuildHttpRequest(    string url, 
                                                    string method, 
                                                    string data, 
                                                    JiraCredentials credentials)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = method;

            if (data != null)
            {
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(data);
                }
            }

            string base64Credentials = credentials.Encode();

            request.Headers.Add("Authorization", "Basic " + base64Credentials);

            return request;
        }

        private string BuildUrl(string apiRequest)
        {
            return $"{Server}/{apiRequest}";
        }

    }

   
}
