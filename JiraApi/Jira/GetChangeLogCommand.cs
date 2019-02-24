using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jira;

namespace Jira
{
    class GetChangeLogCommand : ICommand
    {
        public string CommandString { get; private set; }

        public GetChangeLogCommand(string issueKey)
        {
            CommandString = String.Format("issue/{0}/Changelog", issueKey);
        }
    }
}
