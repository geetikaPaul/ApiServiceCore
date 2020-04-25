using BlogApiServiceCore.Controllers;
using BlogApiServiceCore.DTO;
using System;

namespace BlogApiServiceCore
{
    public class ContentWrapper
    {
        public Content Wrapper(string content, int id, string title, string category)
        {
            if(content.Contains("<h5>"))
            {
                string[] bodies = content.Split("<h5>",2);

                return new Content() { Id = id, Category = category, Body = bodies[0], ExtendedBody = string.Concat("<h5>",bodies[1]), Title = title };
            }
            else if (content.Length > 1000)
            {
                string body = content.Substring(0, 1000);
                String extendedBody = content.Substring(content.Length - (content.Length - 1000));

                return new Content() { Id = id, Category = category, Body = body, ExtendedBody = extendedBody, Title = title };
            }
            else
                return new Content() { Id = id, Category = category, Body = content, ExtendedBody = "", Title = title };
        }
    }
}
