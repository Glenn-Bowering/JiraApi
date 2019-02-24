using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira
{

    //RHeegwodyovci5O
    //facilmova@gmail.com
    //"/rest/api/2/search?expand=Changelog&jql="

    public class JiraCredentials
    {
        protected string Username { get; set; }
        protected string Password { get; set; }

        public JiraCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Encode()
        {
            string mergedCredentials = string.Format("{0}:{1}", Username, Password);

            byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);

            return Convert.ToBase64String(byteCredentials);
        }
    }
}
