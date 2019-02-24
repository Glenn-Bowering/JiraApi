using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jira;

namespace Jira
{
    public class SearchCommand : ICommand
    {
        public string CommandString {get; private set; }

        public SearchCommand()
        {
            CommandString = "search";
        }


    }
}
