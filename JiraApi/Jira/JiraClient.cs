using System;
using System.Collections.Generic;
using System.IO;
using Jira.Api;
using Jira.Api.ObjectModel;

namespace Jira
{
    public class JiraClient
    {
        private JiraApi api = null;

        public JiraClient(String server, JiraCredentials credentials)
        {
            
            Server = server;
            Credentials = credentials;
            api = new JiraApi(server, credentials);
        }

        public string Server { get; set; }
        public JiraCredentials Credentials { get; set; }

    public List<Issue> ExecuteRequest(ApiRequest request)
        {
            

            var results = new List<Issue>();
            SearchResultsBean combinedResponseList = new SearchResultsBean();
            
            

            var queryResult = RetrieveAllPages(request);

            queryResult = GetMissingChangeLogs(queryResult);

            results = MapToSimpleModel(queryResult);

            return results;
        }//jiraIssus.Dump();

        public List<Jira.Issue> LoadMultipleAtlassianJsonFiles(string sourceDirectory)
        {
            JsonTools jsonParser = new JsonTools();
            List<Jira.Issue> issueList = new List<Jira.Issue>();

            IssueMapper issueMapper = new IssueMapper();

            var files = Directory.GetFiles(sourceDirectory);

            SearchResultsBean jiraIssus = null;
            

            foreach (var file in files)
            {
                jiraIssus = jsonParser.LoadAtlassianJsonFromFile(file);

                //jiraIssus.Dump();

                foreach (var jiraIssue in jiraIssus.Issues)
                {
                    var convertedIssue = issueMapper.Map(jiraIssue);
                    issueList.Add(convertedIssue);
                }
            }

            return issueList;
        }

        private SearchResultsBean RetrieveAllPages(ApiRequest request)
        {
            JsonTools jsonTools = new JsonTools();
            SearchResultsBean result = null;

            int runningTotal = 0;
            int total;
            do
            {
                var jsonResponse = api.ExecuteRequest(request);

                var responseCollection = jsonTools.ConvertToAtlassianObjects(jsonResponse);

                result = CombineResponse(result, responseCollection);

                runningTotal += Convert.ToInt32(responseCollection.MaxResults);
                total = Convert.ToInt32(responseCollection.Total);
                request.startAt = runningTotal;

            } while (runningTotal <= total);

            return result;
        }
        /*
        private object RetrieveAllChangeLogsForIssue(string issueKey)
        {
            ApiRequestBuilder requestBuilder = new ApiRequestBuilder();
            JsonTools jsonTools = new JsonTools();


            requestBuilder.WithCommand(new GetChangeLogCommand(issueKey));
            requestBuilder.WithVersion(2);



            var jsonResponse = api.ExecuteRequest(requestBuilder);
        }
        */
        private SearchResultsBean CombineResponse(SearchResultsBean result, SearchResultsBean responseCollection)
        {
            if (null == result)
            {
                return responseCollection;
            }
            else
            {
                result.Issues.AddRange(responseCollection.Issues);
            }

            return result;
        }

        private SearchResultsBean GetMissingChangeLogs(SearchResultsBean queryResponse)
        {
            
            foreach (var issue in queryResponse.Issues)
            {
                if (issue.Changelog.Total > issue.Changelog.MaxResults)
                {
                    //var changeLogs = RetrieveAllChangeLogsForIssue(issue.Key);
                }
            }
            


            return queryResponse;
        }

        


        List<Issue> MapToSimpleModel(SearchResultsBean queryResponse)
        {
            List<Issue> issues = new List<Issue>();
            IssueMapper issueMapper = new IssueMapper();

            
            var issueList = queryResponse.Issues;

            foreach (Api.ObjectModel.Issue issue in issueList)
            {
                issues.Add(issueMapper.Map(issue));
            }
            

            return issues;
        }
    }
}
