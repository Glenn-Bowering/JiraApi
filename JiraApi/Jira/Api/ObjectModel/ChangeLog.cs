using System.Collections.Generic;

namespace Jira.Api.ObjectModel
{
    public class Changelog
    {
        public int? StartAt { get; set; }
        public int? MaxResults { get; set; }
        public int? Total { get; set; }
        public List<History> Histories { get; set; }
    }

    
}
