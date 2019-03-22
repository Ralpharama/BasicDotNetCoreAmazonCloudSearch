using System;
using Newtonsoft.Json;

namespace AmazonCloudSearch
{
    // By Ralph Capper - freeware

    // Note that you will get a forbidden error from Amazon if you have not added your IP address to the access policy, or 
    // have a policy that allows open access

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Basic search results using DeserializeObject for an Amazon CloudSearch engine.");
            Console.WriteLine();

            var query = "brexit";   // Search term

            // Your Aws Search Endpoint, you can find this in the Aws control panel https://eu-west-1.console.aws.amazon.com/cloudsearch/
            var AwsEndPoint = "http://search-ENGINENAME-2222nnnnnnnnhhhhhkkkkk3333.eu-west-1.cloudsearch.amazonaws.com/2013-01-01/";

            // Set up our query. Note this returns 10 results, the first page. Add a &start=20 to get the second page etc
            var endPoint =
                AwsEndPoint + "search?format=json&q.parser=structured&q=(and '" +
                query + "')&sort=_score%20desc";
            Console.WriteLine("Query: "+ endPoint);
            Console.WriteLine();

            // Get results
            var restObj = new RestObject();
            var searchResults = restObj.PingPage(endPoint);

            // Serialize into an array for parsing on view page
            var searchResultsObject = JsonConvert.DeserializeObject<AwsSearchResult.AwsFullResult>(searchResults);

            // Results
            if (searchResultsObject != null)
            {
                Console.WriteLine("Results: "+ searchResultsObject.Hits.Found);
                Console.WriteLine("Page: " + searchResultsObject.Hits.Start);
                Console.WriteLine();

                foreach (var h in searchResultsObject.Hits.Hit)
                {
                    DateTime d2 = DateTime.Parse(h.Fields.PubDate, null, System.Globalization.DateTimeStyles.RoundtripKind);
                    Console.WriteLine(h.Fields.Title);
                    Console.WriteLine(h.Fields.Url);
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }
    }
}
