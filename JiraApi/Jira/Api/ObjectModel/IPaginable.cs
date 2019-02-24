using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.Api.ObjectModel
{
    interface IPaginable<TK>
    {
        int? StartAt { get; set; }
        int? MaxResults { get; set; }
        int? Total { get; set; }
        List<TK> Issues { get; set; }
    }
}
