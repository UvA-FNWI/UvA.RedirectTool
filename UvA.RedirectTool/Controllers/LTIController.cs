using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace UvA.RedirectTool.Controllers
{
    public class LTIController : ApiController
    {
        static string Key = ConfigurationManager.AppSettings["Key"];
        static HMACSHA1 Hash = new HMACSHA1(Encoding.ASCII.GetBytes(Key));

        [HttpPost]
        public IHttpActionResult Post(LTIData data)
        {
            return Redirect(data.custom_url.Replace("{id}", data.custom_id) + $"&hash={Convert.ToBase64String(Hash.ComputeHash(Encoding.ASCII.GetBytes(data.custom_id)))}");
        }
    }

    public class LTIData
    {
        public string custom_url { get; set; }
        public string custom_id { get; set; }
    }

}
