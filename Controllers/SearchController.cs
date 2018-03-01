using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Svinx.FindMe.Libraries.Search;

namespace Svinx.FindMe.Services.Search.Controllers
{

    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private IClient _client;

        public SearchController(IClient client)
        {
            _client = client;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //GET api/values/5
        //        [HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        public dynamic Post(string query)
        {
            var queryObject = new Query()
            {
                Category = string.Empty,
                Term = query
            };
            return _client.Search(queryObject);
        }

        // PUT api/values/5
        /*         [HttpPut("{id}")]
                public void Put(int id, [FromBody]string value)
                {
                }
         */
        // DELETE api/values/5
        /*         [HttpDelete("{id}")]
                public void Delete(int id)
                {
                }
         */
    }
}
