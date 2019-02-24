using System.Collections.Generic;

namespace Jira.Api.ObjectModel
{

    public class SearchResultsBean
    {
        public string Expand { get; set; }
        public int? StartAt { get; set; }
        public int? MaxResults { get; set; }
        public int? Total { get; set; }
        public List<Issue> Issues { get; set; }
    }



































}
