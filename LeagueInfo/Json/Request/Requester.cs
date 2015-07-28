using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;

namespace LeagueInfo.Json.Request
{
    class Requester
    {
        const string URLAPI = @"https://global.api.pvp.net/api/lol/static-data/br/v1.2/champion?champData=all&api_key=8eee2093-91d0-4a8f-bc85-c366e7de1c33";
        const string REGION = "br";
        const string VERSION = "v1.2";
        const string KEY = @"8eee2093-91d0-4a8f-bc85-c366e7de1c33";
        public string Campo { get; set; }
        private static ManualResetEvent allDone = new ManualResetEvent(false);

        public void ExecuteRequest()
        {
            // Create a new HttpWebRequest object.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.contoso.com/example.aspx");

            request.ContentType = "application/x-www-form-urlencoded";

            // Set the Method property to 'POST' to post data to the URI.
            request.Method = "POST";

            // start the asynchronous operation
            request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);

            // Keep the main thread from continuing while the asynchronous 
            // operation completes. A real world application 
            // could do something useful such as updating its user interface. 
            allDone.WaitOne();
        }

        private void GetRequestStreamCallback(IAsyncResult ar)
        {
            HttpWebRequest request = (HttpWebRequest)ar.AsyncState;

            // End the operation
            Stream postStream = request.EndGetRequestStream(ar);

            Console.WriteLine("Please enter the input data to be posted:");
            string postData = Console.ReadLine();

            // Convert the string into a byte array. 
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Write to the request stream.
            postStream.Write(byteArray, 0, postData.Length);
            postStream.Close();

            // Start the asynchronous operation to get the response
            request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
        }

        private void GetResponseCallback(IAsyncResult ar)
        {
            HttpWebRequest request = (HttpWebRequest)ar.AsyncState;

            // End the operation
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(ar);
            Stream streamResponse = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            string responseString = streamRead.ReadToEnd();
            Console.WriteLine(responseString);
            // Close the stream object
            streamResponse.Close();
            streamRead.Close();

            // Release the HttpWebResponse
            response.Close();
            allDone.Set();
        }
    }
}
