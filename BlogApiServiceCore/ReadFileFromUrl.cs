using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogApiServiceCore
{
    public class ReadFileFromUrl
    {
        public string Reader(string url)
        {
            WebClient myBotNewVersionClient = new WebClient();
            Stream stream = myBotNewVersionClient.OpenRead(url);
            StreamReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();

            return content;

        }
    }
}
