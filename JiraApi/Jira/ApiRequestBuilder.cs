

namespace Jira
{
    public class ApiRequestBuilder
    {
        private string RestApi { get; set; }
        private int ApiVersion { get; set; }
        private ICommand Command { get; set; }
        private string Expand { get; set; }
        private string Fields { get; set; }
        private string Query { get; set; }
        private int StartAt { get; set; }
        private int MaxResults { get; set; }

        public ApiRequestBuilder CreateRequest()
        {
            RestApi = "/rest/api";
            ApiVersion = -1;
            StartAt = -1;
            MaxResults = -1;
            return this;
        }

        public ApiRequestBuilder WithVersion(int version)
        {
            ApiVersion = version;
            return this;
        }

        public ApiRequestBuilder WithCommand(ICommand command)
        {
            Command = command;
            return this;
        }

        public ApiRequestBuilder WithFields(string fields)
        {
            Fields = fields;
            return this;
        }

        public ApiRequestBuilder WithExpansion(string expand)
        {
            Expand = expand;
            return this;
        }


        public ApiRequestBuilder WithQuery(string query)
        {
            Query = query;
            return this;
        }

        public ApiRequestBuilder StartAtIndex(int startAt)
        {
            StartAt = startAt;
            return this;
        }

        public ApiRequestBuilder WithMaxResults(int maxResults)
        {
            MaxResults = maxResults;
            return this;
        }

        public static implicit operator ApiRequest(ApiRequestBuilder builder)
        {
            return new ApiRequest()
            {
                RestApi = builder.RestApi,
                ApiVersion = builder.ApiVersion,
                Command = builder.Command,
                expand =  builder.Expand,
                fields = builder.Fields,
                Query = builder.Query,
                startAt = builder.StartAt,
                maxResults = builder.MaxResults
            };
        }
    }
}
