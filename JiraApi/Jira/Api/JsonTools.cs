using System.IO;
using System.Web.Script.Serialization;
using Jira.Api.ObjectModel;

namespace Jira.Api
{
    public class JsonTools
    {

        public SearchResultsBean ConvertToAtlassianObjects(string json)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            var obj = jsonSerializer.Deserialize<SearchResultsBean>(json);

            return obj;
        }

        public string ConvertToAtlassianJson(SearchResultsBean obj)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            var json = jsonSerializer.Serialize(obj);

            return json;
        }

        public string ConvertToAtlassianJson(Issue obj)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            var json = jsonSerializer.Serialize(obj);

            return json;
        }

        public SearchResultsBean LoadAtlassianJsonFromFile(string filename)
        {
            var json = File.ReadAllText(filename);
            return ConvertToAtlassianObjects(json);
        }
    }
}
