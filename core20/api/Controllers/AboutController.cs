using Microsoft.AspNetCore.Mvc;
using Serilog;
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
        private ILogger _logger;

        public AboutController(ILogger logger)
        {
            _logger = logger;
        }

        //[Route("phone")]
        //[Route("[action]")]
        public string Phone()
        {
            try
            {
                throw new InsufficientMemoryException("Dette er en kjempestor feil!!");
            } catch (Exception e)
            {
                _logger.Error(e, "sdfwsf");
            }
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
