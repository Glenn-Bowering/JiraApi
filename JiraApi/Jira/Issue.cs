using System;
using System.Collections.Generic;
using System.Linq;

namespace Jira
{
    public class Issue
    {
        public string Key { get; set; }
        public string Summary { get; set; }
        public string IssueType { get; set; }
        public string Creator { get; set; }
        public DateTime? Created { get; set; }
        public string Project { get; set; }
        public string Prioroty { get; set; }
        public string Resolution { get; set; }
        public List<string> Labels { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public string Assignee { get; set; }
        public DateTime? Updated { get; set; }
        public String Status { get; set; }
        public List<Transition> Transitions { get; set; }
        public List<Issue> SubIssues { get; set; }
        public string ParentKey { get; set; }

        public Issue()
        {
            Transitions = new List<Transition>();
            Labels = new List<string>();
            SubIssues = new List<Issue>();
        }

        public string GetStatusOnDate(DateTime date)
        {
            string status = null;

            var statusChanges = from statusChange in Transitions
                where statusChange.Field == "status"
                select statusChange;

            if (statusChanges.ToList().Count == 0)
            {
                status = "to do";
            }
            else if (statusChanges.ToList().Count == 1)
            {
                if (date > statusChanges.ToList()[0].Date)
                {
                    status = statusChanges.ToArray()[0].To;
                }
                else
                {
                    status = "to do";
                }
            }
            else
            {
                var statusChangeArray = statusChanges.ToArray();

                for (int i = 0; i < statusChangeArray.Length; i++)
                {

                    if (date > statusChangeArray[i].Date && date < statusChangeArray[i + 1].Date)
                    {

                    }
                }
            }


            return status;
        }

        public TimeSpan LeadTime
        {

            get
            {
                if (ResolutionDate == null)
                {
                    return (TimeSpan) (DateTime.Now - this.Created);
                }
                else
                {
                    return (TimeSpan)(ResolutionDate - Created);
                }
            }
        }


        public TimeSpan CycleTime
        {
            get
            {
                return CalculateCycleTime(Transitions);
                
            }
        }

       
        private TimeSpan CalculateCycleTime(List<Transition> transitions)
        {
            Transition openTransition = null;
            Transition closeTransition = null;
            TimeSpan cycleTime = TimeSpan.Zero;

            foreach (var transition in transitions)
            {
                if (transition.Field == "Sprint" && openTransition == null)
                {
                    if (transition.From == null && transition.To != null)
                    {
                        openTransition = transition;
                    }
                }
                if (transition.From == "Open" && openTransition == null)
                {
                    openTransition = transition;
                }

                if (transition.To == "Closed" || transition.To == "Rejected")
                {
                    closeTransition = transition;
                }
            }

            if (null == closeTransition)
            {
                closeTransition = new Transition {Date = DateTime.Now};
            }

            if (null != openTransition)
            {

                cycleTime = closeTransition.Date - openTransition.Date;
            }

            return cycleTime;
        }

        
    }
}
