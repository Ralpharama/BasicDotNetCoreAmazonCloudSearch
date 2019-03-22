# BasicDotNetCoreAmazonCloudSearch

A basic .NET Core console app showing how to get Amazon CloudSearch results and deserialize them into an easy to parse object array

This simply pings the search endpoint with a query and then deserializes the json results in a way that's easy to parse.

I wrote this as I couldn't find any simply way to do this without using the SDK etc.

This assumes you have another way to control the documents in your search engine, this simply gets the results of a search.

Steps:

1. Go to your search engine https://eu-west-1.console.aws.amazon.com/cloudsearch/home?region=eu-west-1
2. Record the search endpoint, then alter the AwsEndPoint var in the program.cs to match this
3. Make a note of the fields, go into 'Indexing Options' and then alter AwsFields in the AwsSearchResult class to match up. 
   e.g.
   [JsonProperty("title")]              <----- the index name used in Amazon
   public string Title { get; set; }    <----- the name you use in code 
   I found it best to use lowercase fields in Amazon, and Capped names for the code variable
4. Alter the query string in program.cs to something that will generate a hit and run the console app.

This ports directly into MVC projects etc, it has no dependencies except Newtonsoft.Json.

Enjoy!

Ralph Capper

