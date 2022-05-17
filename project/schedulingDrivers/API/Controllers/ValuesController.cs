using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using BLL;
using Newtonsoft.Json;




namespace API.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {
            Bll bll = new Bll();
            return bll.returnAlldriver().ToString();
        }

        //GET api/values/5
        public string Get(string id)
        {
            Bll bll = new Bll();
            Console.WriteLine(bll.returnDrive(id).ToString());
            return bll.returnDrive(id);
        }

        // POST api/values
        public void Post([FromBody] Driver d)
        {
            driversbl bll = new driversbl();
            bll.InsertDriver(d);
        }
        
        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
