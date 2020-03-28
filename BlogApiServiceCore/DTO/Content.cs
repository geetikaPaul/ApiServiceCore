using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiServiceCore.DTO
{
    public class Content
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
        public String ExtendedBody { get; set; }
    }
}
