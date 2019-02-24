using System.Collections.Generic;

namespace Jira.Api
{
    public class ChangeLogMapper
    {
        public List<Transition> Map(Jira.Api.ObjectModel.History history)
        {
            var transitions = new List<Transition>();

            for (int i = 0; i < history.items.Count; i++)
            {


                var transition = new Transition();

                if (history.author != null)
                {
                    transition.Author = history.author.displayName;
                }

                transition.Field = history.items[i].Field;

                transition.Date = history.created;
                if (history.items[i].fromString != null)
                {
                    transition.From = history.items[i].fromString;

                }
                else
                {
                    transition.From = history.items[i].from;
                }

                if (history.items[i].toString != null)
                {
                    transition.To = history.items[i].toString;

                }
                else
                {
                    transition.To = history.items[i].to;
                }
                transitions.Add(transition);
            }



            return transitions;
        }
    }
}
