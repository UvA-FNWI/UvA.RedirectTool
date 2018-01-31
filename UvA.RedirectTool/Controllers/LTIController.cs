using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UvA.RedirectTool.Controllers
{
    public class LTIController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(LTIData data)
        {
            return Redirect(data.custom_url.Replace("{id}", data.custom_id));
        }
    }

    public class LTIData
    {
        public string custom_url { get; set; }
        public string custom_id { get; set; }
    }

}
