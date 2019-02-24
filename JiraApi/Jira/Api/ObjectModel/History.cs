using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.Api.ObjectModel
{
    public class History
    {
        public string id { get; set; }
        public Author author { get; set; }
        public DateTime created { get; set; }
        public List<Item> items { get; set; }
    }
}
