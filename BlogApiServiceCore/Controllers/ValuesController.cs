using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogApiServiceCore.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiServiceCore.Controllers
{
    
    
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Content> Get()
        {
            return DataFetcherService.Get(null);
        }

        [HttpGet]
        [Route("api/[controller]/GetByCategory")]
        public IEnumerable<Content> GetByCategory([FromQuery] string selectedCategory)
        {
            return DataFetcherService.Get(selectedCategory);
        }

        [HttpGet]
        [Route("api/[controller]/GetCategories")]
        public IEnumerable<string> GetCategories()
        {
            return DataFetcherService.GetCategories();
        }

        [HttpGet]
        [Route("api/[controller]/GetResume")]
        public string GetResume()
        {
            return Constants.resumePath;
        }
    }
}
