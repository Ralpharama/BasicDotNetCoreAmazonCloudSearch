using Newtonsoft.Json;

namespace AmazonCloudSearch
{
    public class AwsSearchResult
    {
        public class AwsFullResult
        {
            [JsonProperty("status")]
            public AwsStatus Status { get; set; }

            [JsonProperty("hits")]
            public AwsHits Hits { get; set; }
        }

        public class AwsStatus
        {
            [JsonProperty("rid")]
            public string Rid { get; set; }

            [JsonProperty("time-ms")]
            public string TimeMS { get; set; }
        }

        public class AwsHits
        {
            [JsonProperty("found")]
            public string Found { get; set; }

            [JsonProperty("start")]
            public string Start { get; set; }

            [JsonProperty("hit")]
            public AwsHit[] Hit { get; set; }
        }

        public class AwsHit
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("fields")]
            public AwsFields Fields { get; set; }
        }

        // todo: Change the below to match the fields in your search engine
        public class AwsFields
        {
            [JsonProperty("pubdate")]
            public string PubDate { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("importance")]
            public string Importance { get; set; }

            [JsonProperty("mainbody")]
            public string MainBody { get; set; }

            [JsonProperty("intro")]
            public string Intro { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("thumbnail")]
            public string Thumbnail { get; set; }
        }
    }
}
