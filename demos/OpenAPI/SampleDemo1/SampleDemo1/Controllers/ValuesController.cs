using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleDemo1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static List<string> _list;

        static ValuesController()
        {
            _list = new List<string>()
             {
                 "uno",
                 "dos",
                 "tres",
                 "cuatro"
             };
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return _list.Find(v => v == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _list.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]string value)
        {
            var current =_list.Where(v => v == id).First();
            _list.Remove(current);
            _list.Add(value);          
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _list.Remove(id);
        }
    }
}
