using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira
{
    public class ApiRequest
    {
        public string RestApi { get; set; }
        public int ApiVersion { get; set; }
        public ICommand Command { get; set; }
        public string expand { get; set; }
        public string fields { get; set; }
        public string Query { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }

        public ApiRequest()
        {
        }

        public ApiRequest(  string restApi,
                            int apiVersion,
                            ICommand command,
                            string expand,
                            string fields,
                            string query,
                            int startAt,
                            int maxResults )
        {
            RestApi = restApi;
            ApiVersion = apiVersion;
            Command = command;
            this.expand = expand;
            this.fields = fields;
            Query = query;
            this.startAt = startAt;
            this.maxResults = maxResults;
        }
        

        public override string ToString()
        {
            var apiRequest = new StringBuilder();
            int numberOfParameters = 0;
            apiRequest.Append(String.Format("{0}/{1}/{2}", RestApi, ApiVersion, Command.CommandString));

            if (!String.IsNullOrEmpty(expand))
            {
                apiRequest.Append(String.Format("{0}expand={1}", GetQuerySeparator(numberOfParameters), expand));
                numberOfParameters++;
            }

            if (!String.IsNullOrEmpty(Query))
            {
                apiRequest.Append(String.Format("{0}jql={1}", GetQuerySeparator(numberOfParameters), Query));
                numberOfParameters++;
            }

            if (!String.IsNullOrEmpty(fields))
            {
                apiRequest.Append(String.Format("{0}fields={1}", GetQuerySeparator(numberOfParameters), fields));
                numberOfParameters++;
            }

            if (startAt >= 0)
            {
                apiRequest.Append(String.Format("{0}startAt={1}", GetQuerySeparator(numberOfParameters), startAt));
                numberOfParameters++;
            }
            
            if (maxResults >= 0)
            {
                apiRequest.Append(String.Format("{0}maxResults={1}", GetQuerySeparator(numberOfParameters), maxResults));
                numberOfParameters++;
            }

            return apiRequest.ToString();
        }

        private string GetQuerySeparator(int numberOfParameters)
        {
            string seperator = String.Empty;

            if (0 == numberOfParameters)
            {
                seperator = "?";
            }
            else
            {
                seperator = "&";
            }

            return seperator;
        }
    }
}
