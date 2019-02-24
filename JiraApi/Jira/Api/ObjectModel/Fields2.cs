using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.Api.ObjectModel
{
    public class Fields2
    {
        public string summary { get; set; }
        public Status status { get; set; }
        public Priority priority { get; set; }
        public Issuetype issuetype { get; set; }
    }
}
