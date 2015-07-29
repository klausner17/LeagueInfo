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
        private WebRequest requester;

        private void StartWebRequest()
        {
            requester = WebRequest.Create(URLAPI);
            requester.BeginGetResponse(new AsyncCallback(FinishWebRequest), null);
            StreamReader stream = (StreamReader) requester.BeginGetRequestStream(new AsyncCallback(BeginGetStream), null);
        }

        private void BeginGetStream(IAsyncResult ar)
        {
            requester.EndGetResponse(ar);
        }

        private void FinishWebRequest(IAsyncResult result)
        {
            requester.EndGetResponse(result);
        }
    }
}
