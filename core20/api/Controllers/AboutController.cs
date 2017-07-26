using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    //[Route("about")]
    [Route("company/[controller]/[action]")]
    public class AboutController
    {
        //[Route("phone")]
        //[Route("[action]")]
        public string Phone()
        {
            return "1+555-555-555";
        }

        //[Route("address")]
        //[Route("[action]")]
        public string Address()
        {
            return "USA";
        }
    }
}
