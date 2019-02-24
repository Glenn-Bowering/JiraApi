using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.Api.ObjectModel
{
    public class Fields
    {
        public string summary { get; set; }
        public Issuetype issuetype { get; set; }
        public Creator creator { get; set; }
        public DateTime? created { get; set; }
        public Project project { get; set; }
        public Priority priority { get; set; }
        public Resolution resolution { get; set; }
        public List<object> labels { get; set; }
        public DateTime? resolutiondate { get; set; }
        public Assignee assignee { get; set; }
        public DateTime? updated { get; set; }
        public Status status { get; set; }
        public Parent parent { get; set; }
    }
}
