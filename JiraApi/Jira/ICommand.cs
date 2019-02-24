using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira
{
    public interface ICommand
    {
        string CommandString { get; }
    }
}
