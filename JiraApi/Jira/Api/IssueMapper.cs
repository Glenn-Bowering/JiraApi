using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jira;

namespace Jira.Api
{
    public class IssueMapper
    {
        public Jira.Issue Map(Jira.Api.ObjectModel.Issue apiIssue)
        {
            var changelogMapper = new ChangeLogMapper();

            Jira.Issue issue = new Jira.Issue();

            if (null != apiIssue.Fields)
            {
                if (apiIssue.Fields.assignee != null)
                {
                    issue.Assignee = apiIssue.Fields.assignee.displayName;
                }

                if (apiIssue.Fields.creator != null)
                {
                    issue.Creator = apiIssue.Fields.creator.displayName;
                }

                if (apiIssue.Fields.issuetype != null)
                {
                    issue.IssueType = apiIssue.Fields.issuetype.name;
                }

                if (apiIssue.Fields.priority != null)
                {
                    issue.Prioroty = apiIssue.Fields.priority.name;
                }

                if (apiIssue.Fields.resolution != null)
                {
                    issue.Resolution = apiIssue.Fields.resolution.description;
                }

                if (apiIssue.Fields.status != null)
                {
                    issue.Status = apiIssue.Fields.status.name;
                }

                if (apiIssue.Fields.parent != null)
                {
                    issue.ParentKey = apiIssue.Fields.parent.key;
                }

                issue.Project = apiIssue.Fields.project.name;
                issue.Created = apiIssue.Fields.created;
                issue.Summary = apiIssue.Fields.summary;
                issue.ResolutionDate = apiIssue.Fields.resolutiondate;
                issue.Updated = apiIssue.Fields.updated;
                issue.Key = apiIssue.Key;

                


                for (int i = 0; i < apiIssue.Fields.labels.Count; i++)
                {
                    issue.Labels.Add(Convert.ToString(apiIssue.Fields.labels[i]));
                }

                if (apiIssue.Changelog != null && apiIssue.Changelog.Histories != null)
                {
                    for (int i = 0; i < apiIssue.Changelog.Histories.Count; i++)
                    {
                        issue.Transitions.AddRange(changelogMapper.Map(apiIssue.Changelog.Histories[i]));
                    }
                }

            }

            return issue;
        }
    }
}
