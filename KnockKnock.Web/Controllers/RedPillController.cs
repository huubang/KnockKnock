using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KnockKnock.Core;

namespace KnockKnock.Web.Controllers
{
    [RoutePrefix("api/red-pill")]
    public class RedPillController : ApiController
    {
        private readonly IRedPillService redPillService;

        public RedPillController()
        {
            redPillService = new RedPillService();
        }

        [Route("token")]
        public string GetToken()
        {
            return redPillService.GetToken();
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
