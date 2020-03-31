using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogApiServiceCore.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiServiceCore.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private const string s3Path = "https://gpblogs.s3.amazonaws.com/";
        // GET api/values
        [HttpGet]

        public IEnumerable<Content> Get()
        {
            List<Content> contents = new List<Content>();
            ContentWrapper contentWrapper = new ContentWrapper();
            FileNameExtractor fileNameExtractor = new FileNameExtractor();
            ReadFileFromUrl read = new ReadFileFromUrl();
            int id = 0;

            string files = read.Reader(s3Path);
            List<string> fileNames = fileNameExtractor.Extractor(files).ToList();
            foreach(string fileName in fileNames)
            {
                string filePath = string.Concat(s3Path, fileName);
                string content = read.Reader(filePath);

                var parser = new MarkdownSharp.Markdown();
                if (fileName.Contains(".md"))
                 content = parser.Transform(content.Trim());

                string title = fileName;
                int charLocation = fileName.IndexOf('.', StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    title = fileName.Substring(0, charLocation);
                }

                contents.Add(contentWrapper.Wrapper(content, ++id, title));
            }
            return contents;
        }
    }
}
