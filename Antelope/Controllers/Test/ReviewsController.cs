using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Antelope.Controllers.Test
{
    public class ReviewsController : ApiController
    {
        // GET api/reviews
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/reviews/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/reviews
        public void Post([FromBody]string value)
        {
        }

        // PUT api/reviews/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/reviews/5
        public void Delete(int id)
        {
        }
    }
}
