﻿using System;
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
        // GET api/values
        [HttpGet]
        /*public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }*/
        public IEnumerable<Content> Get()
        {
            List<Content> contents = new List<Content>();
            ContentWrapper contentWrapper = new ContentWrapper();
            ReadFileFromUrl read = new ReadFileFromUrl();
            int id = 0;
            /*string path = string.Concat(Directory.GetCurrentDirectory(), "\\Blogs");
            foreach (string file in Directory.EnumerateFiles("https://github.com/geetikaPaul/ApiServiceCore/tree/master/BlogApiServiceCore/Blogs", " *.txt"))
            {
                string content = System.IO.File.ReadAllText(file);
                if (content.Length > 1000)
                {
                    string body = content.Substring(0, 1000);
                    String extendedBody = content.Substring(content.Length - (content.Length - 1000));

                    contents.Add(new Content() { Id = ++id, Body = body, ExtendedBody = extendedBody, Title = Path.GetFileName(file) });
                }
                else
                   contents.Add(new Content() { Id = ++id, Body = content, ExtendedBody = "", Title = Path.GetFileName(file) });
            }*/


            string content = read.Reader("https://gpblogs.s3.amazonaws.com/file1.txt");
            contents.Add(contentWrapper.Wrapper(content, 1, "file1"));
            content = read.Reader("https://gpblogs.s3.amazonaws.com/file2.txt");
            contents.Add(contentWrapper.Wrapper(content, 2, "file2"));

            return contents;
            /*return new List<Content>() { new Content() { Id = 1, Body = "body 1", ExtendedBody = "Extended body 1", Title = "title1" },
             new Content() { Id = 2, Body = "body 2", ExtendedBody = "Extended body 2", Title = "title2" } };*/
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
