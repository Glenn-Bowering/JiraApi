using System;
using System.IO;


namespace Jira
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string server = "https://facilmova.atlassian.net";
            var credentials = new JiraCredentials("facilmova@gmail.com", "RHeegwodyovci5O");
            //JiraTools.JiraApi api = new JiraTools.JiraApi(server, credentials);

            JiraClient client = new JiraClient(server, credentials);

            ApiRequestBuilder builder = new ApiRequestBuilder();
            var command = new SearchCommand();

            builder.CreateRequest();
            builder.WithVersion(2);
            builder.WithCommand(command);
            builder.WithExpansion("Changelog");
            builder.WithFields("issuetype,project,resolution,resolutiondate,created,lastviewed,priority,labels,assignee,updated,status,summary,creator");
            builder.WithQuery("project = \"TEST\" ORDER BY updated DESC");
            builder.WithMaxResults(50);



            client.Server = server;
            client.Credentials = credentials;
            var response = client.ExecuteRequest(builder);

            Console.In.ReadLine();

        }
    }
}
