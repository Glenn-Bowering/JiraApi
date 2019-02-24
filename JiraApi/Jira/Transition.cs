using System;

namespace Jira
{
    public class Transition
    {
        public string Field { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }

    }
}
