using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;

namespace LeagueInfo.ClassApi
{
    class Requester
    {
        public delegate void GettingJsonEventHandler(int status);
        public static event GettingJsonEventHandler OnGettingData;
        private String json { get; set; }
        bool go = false;

        public const int BEGINDOWNLOAD = 0;
        public const int ENDDOWNLOAD = 1;

        public async Task<string> GetJson(string url)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_DownloadStringCompleted;
            client.DownloadStringAsync(new Uri(url));
            GettingData(BEGINDOWNLOAD);
            while (!go)
                await Task.Delay(10);
            GettingData(ENDDOWNLOAD);
            return json;
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Result))
            {
                json = e.Result;
                go = true;
            }
        }

        public void GettingData(int status)
        {
            if (OnGettingData != null)
                OnGettingData(status);
        }
    }
}
