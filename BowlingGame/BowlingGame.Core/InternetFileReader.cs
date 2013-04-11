using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BowlingGame.Core
{
    public class InternetFileReader : IFileReader
    {
        private FileState _state;

        public InternetFileReader(string serverName)
        {
            ServerName = serverName;
            _state = FileState.NotLoaded;
        }

        public FileState State
        {
            get { return _state; }
        }

        public string ServerName { get; set; }

        public string ReadFile(string path)
        {
            string entries = null;

            var uriString = string.Format("http://{0}/{1}", ServerName, path);

            var request = (HttpWebRequest) WebRequest.Create(uriString);

            var response = (HttpWebResponse) request.GetResponse();

            var httpStatus = response.StatusCode;

            // If it can't be found...
            if (httpStatus == HttpStatusCode.NotFound)
            {
                _state = FileState.NotFound;
            }
            // If it can't be accessed...
            else if (httpStatus == HttpStatusCode.Unauthorized)
            {
                _state = FileState.CantBeAccessed;
            }
            // If its valid...
            else
            {
                // "Parse" the stream.
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    entries = reader.ReadToEnd();
                }
            }

            return entries;
        }
    }
}
