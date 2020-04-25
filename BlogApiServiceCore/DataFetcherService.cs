using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApiServiceCore.DTO;

namespace BlogApiServiceCore
{
    public static class DataFetcherService
    {
        public static IEnumerable<Content> Get(string selectedCategory)
        {
            List<Content> contents = new List<Content>();
            ContentWrapper contentWrapper = new ContentWrapper();
            FileNameExtractor fileNameExtractor = new FileNameExtractor();
            ReadFileFromUrl read = new ReadFileFromUrl();
            int id = 0;
            string category = string.Empty;
            string title = string.Empty;

            string files = read.Reader(Constants.s3Path);

            List<string> fileNames = fileNameExtractor.Extractor(files).ToList();

            if (selectedCategory != null)
                fileNames = fileNames.Where(c => c.Contains(selectedCategory)).ToList();

            foreach (string fileName in fileNames)
            {
                string filePath = string.Concat(Constants.s3Path, fileName);

                if (!filePath.Contains(".md"))
                    continue;

                string content = read.Reader(filePath);

                var parser = new MarkdownSharp.Markdown();
                if (fileName.Contains(".md"))
                    content = parser.Transform(content.Trim());

                if (fileName.Contains("/"))
                {
                    string[] fileDir = fileName.Split("/");
                    category = fileDir[0];
                    title = fileDir[1].Split(".")[0];
                }
                else
                    title = fileName.Split(".")[0];

                contents.Add(contentWrapper.Wrapper(content, ++id, title, category));
            }
            return contents;
        }

        public static IEnumerable<string> GetCategories()
        {
            HashSet<string> categories = new HashSet<string>();
            FileNameExtractor fileNameExtractor = new FileNameExtractor();
            ReadFileFromUrl read = new ReadFileFromUrl();

            string files = read.Reader(Constants.s3Path);
            List<string> fileNames = fileNameExtractor.Extractor(files).ToList();

            foreach (string fileName in fileNames)
            {
                if (fileName.Contains("/"))
                {
                    categories.Add(fileName.Split("/")[0]);
                }
            }
            return categories.ToList();
        }
    }
}
