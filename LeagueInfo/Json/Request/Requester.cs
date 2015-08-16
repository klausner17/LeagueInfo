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
        public delegate void GettingJsonEventHandler(int status);
        public static event GettingJsonEventHandler OnGettingData;
        public string url;
        const string REGION = "br";
        const string VERSION = "v1.2";
        const string KEY = @"8eee2093-91d0-4a8f-bc85-c366e7de1c33";
        public string Campo { get; set; }
        private WebRequest requester;
        private String json { get; set; }
        private static ManualResetEvent allDone = new ManualResetEvent(false);
        bool go = false;

        public const int BEGINDOWNLOAD = 0;
        public const int ENDDOWNLOAD = 1;

        public Requester(string url)
        {
            this.url = url;
        }

        private async Task StartWebRequest()
        {
            requester = (HttpWebRequest)WebRequest.Create(url);
            requester.BeginGetResponse(new AsyncCallback(FinishWebRequest), null);
            GettingData(BEGINDOWNLOAD);
            while (!go)
                await Task.Delay(1000);
            GettingData(ENDDOWNLOAD);
        }

        private void FinishWebRequest(IAsyncResult result)
        {
            HttpWebResponse response = requester.EndGetResponse(result) as HttpWebResponse;
            json = string.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
                json = reader.ReadToEnd();
            go = true;
        }

        public async Task<string> GetJson()
        {
            await StartWebRequest();
            return json;
        }

        public void GettingData(int status)
        {
            if (OnGettingData != null)
                OnGettingData(status);
        }
    }
}
