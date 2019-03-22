using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace AmazonCloudSearch
{
    public class RestObject
    {
        // This is a very basic method to send and get a response from Amazon CloudSearch via the endpoint

        public string PingPage(string arg)
        {
            string s = "";

            if (arg == null)
            {
                throw new ApplicationException("Specify the URI of the resource to retrieve.");
            }
            WebClient client = new WebClient();

            // Add a user agent header
            client.Headers.Add("user-agent", "ralpharama");

            Stream data = client.OpenRead(arg);
            StreamReader reader = new StreamReader(data);
            s = reader.ReadToEnd();
            //Debug.WriteLine("Got:" + s);
            data.Close();
            reader.Close();

            return s;
        }
    }
}